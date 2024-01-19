using System.IO.Compression;
using System.Text;
using DisasterApiService.Common;
using DisasterApiService.Entity;
using DisasterApiService.Entity.PublicShelterTypes;
using Hangfire;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace DisasterApiService.Batch;

/// <summary>
///  一日に一回実行されるタスク
/// </summary>
public class OneDateOnceExecution{

    private DisasterDbContext _context;

    /// <summary>
    /// DI
    /// </summary>
    /// <param name="context"></param>
    public OneDateOnceExecution(DisasterDbContext context){
        _context = context;
    }
    //１時間設定する
    [DisableConcurrentExecution(timeoutInSeconds: 60 * 60)]
    public void ExecuteMethods(){

        UpdateDisasterTable().Wait();

        
    }

    /// <summary>
    ///     指定緊急避難所登録処理
    /// </summary>
    private async Task UpdateDisasterTable(){
        await DiscordSendMessages.SendMessageAsync(CommonParameter.TextId,"緊急避難所取り込み開始");
        byte[] data ;
        using(HttpClient httpClient = new HttpClient()){
            HttpResponseMessage response = await httpClient.GetAsync(CommonParameter.EmergencyShelterCsvUrl);

            if(response.IsSuccessStatusCode){
                data = await response.Content.ReadAsByteArrayAsync();
            }else{
                await DiscordSendMessages.SendMessageAsync(CommonParameter.TextId,"指定緊急避難所取り込み処理エラー発生。CSVのダウンロード用URLに問題があります");
                return;
            }

            using(MemoryStream memoryStream = new MemoryStream(data))
            using(ZipArchive archive = new ZipArchive(memoryStream)){
                StructureTypeEntity? strct = _context.StructureTypeEntity.Where(i => i.StructName == "特定緊急避難所").SingleOrDefault() ;
                if(strct == null){
                    strct = new StructureTypeEntity(){
                        StructName = "特定緊急避難所",
                        StructNote = "自動インポート情報"
                    };
                }
                foreach(ZipArchiveEntry entry in archive.Entries){
                     CsvImportTable(entry, strct);
                }
            }

            await DiscordSendMessages.SendMessageAsync(CommonParameter.TextId,"指定緊急避難所取り込み処理が正常に終了しました。");

            httpClient.CancelPendingRequests();
            
        }
    }

    /// <summary>
    ///     CSVをテーブルに取り込む処理
    /// </summary>
    private bool CsvImportTable(ZipArchiveEntry archive, StructureTypeEntity strct)
    {
        using(Stream csvStream = archive.Open())
        using(StreamReader reader = new StreamReader(csvStream, Encoding.UTF8)){
            string csvData = reader.ReadToEnd();
            List<OrganizationEntity>? insertList = GenerateOrganizationEntity(csvData, strct);

            if(insertList == null){
                return false;;
            }

            return true;
        }
    }


 private List<OrganizationEntity>? GenerateOrganizationEntity(String csv, StructureTypeEntity strct){
        List<OrganizationEntity> organizations = new();
        List<string> record = new List<string>(csv.Split(new[] { Environment.NewLine }, StringSplitOptions.None));

        bool first = true;
        foreach(string row in record){
            List<string> column = row.Split(',').ToList();
            
            if(first){
                first = false;
                continue;
            }

            OrganizationEntity entity ;
            try{
                entity = new(){
                    Lon = double.Parse(column[14]),
                    Lat = double.Parse(column[15]),
                    OrgName = column[3]
                };
            }catch(Exception){
                //不正な文字列だった場合飛ばす
                if(row == ""){
                    break;
                }else{
                    return null;
                }
            }
                
            // 一意性チェック
            var existingEntity = _context.OrganizationEntity
                            .FirstOrDefault(e => e.Lon == entity.Lon && e.Lat == entity.Lat && e.OrgName == entity.OrgName);

            if(existingEntity == null){
                entity.OrgName = column[3];
                entity.OrgNote = column[16];
                entity.StructureType = strct;
                int i = 0;
                foreach(string col in column){
                    if(i > 4 && col == "1"){
                        SetValue(entity,i);
                    }
                    
                    i++;
                }
                // 新しいエンティティを追加
                organizations.Add(entity); 
            } else {
                // 既存のエンティティに関連するEmergencyShelterエンティティを追加
                //現在は何もしない、更新処理を入れる予定
            }
        }

        _context.OrganizationEntity.AddRange(organizations);
        _context.SaveChanges();

        return organizations;
    } 

    public OrganizationEntity SetValue(OrganizationEntity entity, int colNum){
        switch(colNum){
            case 5:
                //洪水
                entity.FloodFlg = new();
            break;

            case 6:
                //土砂崩れ
                entity.SliderFlg = new();
            break;

            case 7:
                //高潮
                entity.StormsurgeFlg = new();
            break;

            case 8:
                //地震
                entity.EarthquakeFlg = new();

            break;

            case 9:
                //津波
                entity.TsunamiFlg = new ();

            break;
    
            case 10:
                //大規模な火事
                entity.BuringFlg = new();

            
            break;

            case 11:
                // 内水氾濫
                entity.InlandFlg = new();
            break;

            case 12:
            //火山現象
            entity.VolcanoFlg = new ();

            break;

            case 13:
            //指定避難所
            entity.SpecifiedFlg = new ();
            break;
        }

        return entity;
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DisasterApiService.Entity;

[Table("equipament_table")]
public class EquipamentEntity{

    [Key]
    [ForeignKey("Organization")]
    public int OrgNo { get; set; }

    /// <summary>
    ///     外部参照
    /// </summary>
    public virtual OrganizationEntity? Organization { get; set; }

    /// <summary>
    ///     水道
    /// </summary>
    public Boolean WaterFlg{get;set;}

    /// <summary>
    ///     電気
    /// </summary>
    public Boolean ElectricityFlg{get;set;}

    /// <summary>
    ///  フリーWifi
    /// </summary>
    public Boolean FreeWifiFlg{get;set;}

    /// <summary>
    ///  電話回線
    /// </summary>
    public Boolean PhoneNetFlg{get;set;}

    /// <summary>
    ///  空調
    /// </summary>
    public Boolean AirConditioningFlg{get;set;}

    /// <summary>
    /// 避難人数
    /// </summary>
    public int EvacuationCount{get;set;}
    /// <summary>
    /// 医療体制
    /// </summary>
    public Boolean MedicalSystemFlg{get;set;}

    /// <summary>
    /// ガス
    /// </summary>
    public Boolean GasFlg{get;set;}

    /// <summary>
    ///  デフォルトで更新日時が更新されるようになっている
    /// </summary>
    public DateTime UpdateTime{get;set;}= DateTime.Now;
}
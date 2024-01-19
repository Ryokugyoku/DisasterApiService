using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DisasterApiService.Entity.PublicShelterTypes;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;

namespace DisasterApiService.Entity;

/// <summary>
///  災害情報モジュール基底テーブル
/// </summary>
[Table("organization_table")]

public class OrganizationEntity{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrgNo{get;set;}

    [Required]
    public string? OrgName{get;set;}
    /// <summary>
    /// 　緯度
    /// </summary>
    [Required]
    public double Lon{get;set;}

    /// <summary>
    ///  経度
    /// </summary>
    [Required]
    public double Lat{get;set;}

    
    /// <summary>
    ///     建造物種別外部キー
    /// </summary>
    [Required]
    public int? StructureTypeNo { get; set; }
    /// <summary>
    /// 建造物種別
    /// </summary>
    [ForeignKey("StructureTypeNo")]
    public StructureTypeEntity? StructureType{get;set;}

    /// <summary>
    ///    備考
    /// </summary>
    public string? OrgNote{get;set;}

    /// <summary>
    ///  電話番号
    /// </summary>
    public string? OrgTel{get;set;}

    /// <summary>
    ///  設備テーブル
    /// </summary>
    public EquipamentEntity? Equip{get;set;}

    /// <summary>
    ///     地震避難所Flg
    /// </summary>
    public EmergencyShelterEarthquakeEntity? EarthquakeFlg{get;set;}

    /// <summary>
    ///     土砂崩れ避難所Flg
    /// </summary>
    public EmergencyShelterSliderEntity? SliderFlg{get;set;}

    /// <summary>
    ///     指定避難所Flg
    /// </summary>
    public EmergencyShelterSpecifiedEntity? SpecifiedFlg{get;set;}

    /// <summary>
    ///     津波避難所Flg
    /// </summary>
    public EmergencyShelterTsunamiEntity? TsunamiFlg{get;set;}

    /// <summary>
    ///     火山避難所Flg
    /// </summary>
    public EmergencyShelterVolcanoEntity? VolcanoFlg{get;set;}

    /// <summary>
    ///  大規模火災Flg
    /// </summary>
    public EmergencyShelterBuringEntity? BuringFlg{get;set;}

    /// <summary>
    ///    内水氾濫
    /// </summary>
    public EmergencyShelterInlandfloodEntity? InlandFlg{get;set;}

    /// <summary>
    ///  高潮
    /// </summary>
    public EmergencyShelterStormsurgeEntity? StormsurgeFlg{get;set;}

    /// <summary>
    ///     洪水
    /// </summary>
    public EmergencyShelterFloodEntity? FloodFlg {get;set;}
}
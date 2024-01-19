using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DisasterApiService.Entity;

/// <summary>
///  建造物種別
/// </summary>
[Table("structure_type_table")]
[PrimaryKey(nameof(StructId))]
public class StructureTypeEntity{

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int StructId{get;set;}
    /// <summary>
    ///  建造物種別名
    /// </summary>
    [Required]
    public string? StructName{get;set;}

    /// <summary>
    ///  備考
    /// </summary>A
    public string? StructNote{get;set;}

    /// <summary>
    ///  外部キーとして参照している項目
    /// </summary>
    public List<OrganizationEntity>? OrgNo{get;set;}
}
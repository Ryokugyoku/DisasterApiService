using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisasterApiService.Entity.PublicShelterTypes;

/// <summary>
///  緊急避難所　土砂崩れ
/// </summary>
[Table("emergency_shelter_flood_table")]
public class EmergencyShelterFloodEntity{
    
    [Key]
    [ForeignKey("Organization")]
    public int OrgNo { get; set; }

    /// <summary>
    ///     外部参照
    /// </summary>
    public virtual OrganizationEntity? Organization { get; set; }
}
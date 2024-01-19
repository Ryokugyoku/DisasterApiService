using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisasterApiService.Entity.PublicShelterTypes;

/// <summary>
///  緊急避難所　地震
/// </summary>
[Table("emergency_shelter_volcano_table")]
public class EmergencyShelterVolcanoEntity{
    [Key]
    [ForeignKey("Organization")]
    public int OrgNo { get; set; }

    /// <summary>
    ///     外部参照
    /// </summary>
    public virtual OrganizationEntity? Organization { get; set; }
}
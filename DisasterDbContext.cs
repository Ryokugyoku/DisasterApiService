using Microsoft.EntityFrameworkCore;
using DisasterApiService.Entity;
using DisasterApiService.Entity.PublicShelterTypes;

namespace DisasterApiService;
public class DisasterDbContext : DbContext{
    public DisasterDbContext(DbContextOptions<DisasterDbContext> options): base(options){}

    public DbSet<StructureTypeEntity> StructureTypeEntity{get;set;}
    public DbSet<OrganizationEntity> OrganizationEntity{get;set;}

    public DbSet<EquipamentEntity> EquipamentEntity{get;set;}

    public DbSet<EmergencyShelterEarthquakeEntity> EmergencyShelterEarthquakeEntity{get;set;}

    public DbSet<EmergencyShelterSliderEntity> EmergencyShelterSliderEntity{get;set;}

    public DbSet<EmergencyShelterSpecifiedEntity> EmergencyShelterSpecifiedEntity{get;set;}

    public DbSet<EmergencyShelterTsunamiEntity> EmergencyShelterTsunamiEntity {get;set;}

    public DbSet<EmergencyShelterVolcanoEntity> EmergencyShelterVolcanoEntity{get;set;}

    public DbSet<EmergencyShelterBuringEntity> EmergencyShelterBuringEntity{get;set;}

    public DbSet<EmergencyShelterInlandfloodEntity> EmergencyShelterInlandfloodEntity{get;set;}

    public DbSet<EmergencyShelterStormsurgeEntity> EmergencyShelterStormsurgeEntity{get;set;}

    public DbSet<EmergencyShelterFloodEntity> EmergencyShelterFloodEntity{get;set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<OrganizationEntity>()
            .HasOne(o => o.StructureType)
            .WithMany(c => c.OrgNo)
            .HasForeignKey(o => o.StructureTypeNo)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<OrganizationEntity>()
        .HasOne(o => o.Equip)
        .WithOne(c => c.Organization)
        .HasForeignKey<EquipamentEntity>(o => o.OrgNo)
        .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<OrganizationEntity>()
        .HasOne(o => o.EarthquakeFlg)
        .WithOne(c => c.Organization)
        .HasForeignKey<EmergencyShelterEarthquakeEntity>(o => o.OrgNo)
        .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<OrganizationEntity>()
        .HasOne(o => o.SliderFlg)
        .WithOne(c => c.Organization)
        .HasForeignKey<EmergencyShelterSliderEntity>(o => o.OrgNo)
        .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Entity<OrganizationEntity>()
        .HasOne(o => o.SpecifiedFlg)
        .WithOne(c => c.Organization)
        .HasForeignKey<EmergencyShelterSpecifiedEntity>(o => o.OrgNo)
        .OnDelete(DeleteBehavior.Cascade);
       
        modelBuilder.Entity<OrganizationEntity>()
        .HasOne(o => o.TsunamiFlg)
        .WithOne(c => c.Organization)
        .HasForeignKey<EmergencyShelterTsunamiEntity>(o => o.OrgNo)
        .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Entity<OrganizationEntity>()
        .HasOne(o => o.VolcanoFlg)
        .WithOne(c => c.Organization)
        .HasForeignKey<EmergencyShelterVolcanoEntity>(o => o.OrgNo)
        .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<OrganizationEntity>()
        .HasOne(o => o.BuringFlg)
        .WithOne(c => c.Organization)
        .HasForeignKey<EmergencyShelterBuringEntity>(o => o.OrgNo)
        .OnDelete(DeleteBehavior.Cascade); 

        modelBuilder.Entity<OrganizationEntity>()
        .HasOne(o => o.FloodFlg)
        .WithOne(c => c.Organization)
        .HasForeignKey<EmergencyShelterFloodEntity>(o => o.OrgNo)
        .OnDelete(DeleteBehavior.Cascade);  

        modelBuilder.Entity<OrganizationEntity>()
        .HasOne(o => o.InlandFlg)
        .WithOne(c => c.Organization)
        .HasForeignKey<EmergencyShelterInlandfloodEntity>(o => o.OrgNo)
        .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<OrganizationEntity>()
        .HasOne(o => o.StormsurgeFlg)
        .WithOne(c => c.Organization)
        .HasForeignKey<EmergencyShelterStormsurgeEntity>(o => o.OrgNo)
        .OnDelete(DeleteBehavior.Cascade);                  

    }
}
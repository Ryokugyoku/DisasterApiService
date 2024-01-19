﻿// <auto-generated />
using System;
using DisasterApiService;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DisasterApiService.Migrations
{
    [DbContext(typeof(DisasterDbContext))]
    partial class DisasterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DisasterApiService.Entity.EquipamentEntity", b =>
                {
                    b.Property<int>("OrgNo")
                        .HasColumnType("integer");

                    b.Property<bool>("AirConditioningFlg")
                        .HasColumnType("boolean");

                    b.Property<bool>("ElectricityFlg")
                        .HasColumnType("boolean");

                    b.Property<int>("EvacuationCount")
                        .HasColumnType("integer");

                    b.Property<bool>("FreeWifiFlg")
                        .HasColumnType("boolean");

                    b.Property<bool>("GasFlg")
                        .HasColumnType("boolean");

                    b.Property<bool>("MedicalSystemFlg")
                        .HasColumnType("boolean");

                    b.Property<bool>("PhoneNetFlg")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("WaterFlg")
                        .HasColumnType("boolean");

                    b.HasKey("OrgNo");

                    b.ToTable("equipament_table");
                });

            modelBuilder.Entity("DisasterApiService.Entity.OrganizationEntity", b =>
                {
                    b.Property<int>("OrgNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrgNo"));

                    b.Property<double>("Lat")
                        .HasColumnType("double precision");

                    b.Property<double>("Lon")
                        .HasColumnType("double precision");

                    b.Property<string>("OrgName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OrgNote")
                        .HasColumnType("text");

                    b.Property<string>("OrgTel")
                        .HasColumnType("text");

                    b.Property<int?>("StructureTypeNo")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.HasKey("OrgNo");

                    b.HasIndex("StructureTypeNo");

                    b.ToTable("organization_table");
                });

            modelBuilder.Entity("DisasterApiService.Entity.PublicShelterTypes.EmergencyShelterBuringEntity", b =>
                {
                    b.Property<int>("OrgNo")
                        .HasColumnType("integer");

                    b.HasKey("OrgNo");

                    b.ToTable("emergency_shelter_buring_table");
                });

            modelBuilder.Entity("DisasterApiService.Entity.PublicShelterTypes.EmergencyShelterEarthquakeEntity", b =>
                {
                    b.Property<int>("OrgNo")
                        .HasColumnType("integer");

                    b.HasKey("OrgNo");

                    b.ToTable("emergency_shelter_earthquake_table");
                });

            modelBuilder.Entity("DisasterApiService.Entity.PublicShelterTypes.EmergencyShelterFloodEntity", b =>
                {
                    b.Property<int>("OrgNo")
                        .HasColumnType("integer");

                    b.HasKey("OrgNo");

                    b.ToTable("emergency_shelter_flood_table");
                });

            modelBuilder.Entity("DisasterApiService.Entity.PublicShelterTypes.EmergencyShelterInlandfloodEntity", b =>
                {
                    b.Property<int>("OrgNo")
                        .HasColumnType("integer");

                    b.HasKey("OrgNo");

                    b.ToTable("emergency_shelter_inlandflood_table");
                });

            modelBuilder.Entity("DisasterApiService.Entity.PublicShelterTypes.EmergencyShelterSliderEntity", b =>
                {
                    b.Property<int>("OrgNo")
                        .HasColumnType("integer");

                    b.HasKey("OrgNo");

                    b.ToTable("emergency_shelter_slider_table");
                });

            modelBuilder.Entity("DisasterApiService.Entity.PublicShelterTypes.EmergencyShelterSpecifiedEntity", b =>
                {
                    b.Property<int>("OrgNo")
                        .HasColumnType("integer");

                    b.HasKey("OrgNo");

                    b.ToTable("emergency_shelter_specified_table");
                });

            modelBuilder.Entity("DisasterApiService.Entity.PublicShelterTypes.EmergencyShelterStormsurgeEntity", b =>
                {
                    b.Property<int>("OrgNo")
                        .HasColumnType("integer");

                    b.HasKey("OrgNo");

                    b.ToTable("emergency_shelter_stormsurge_table");
                });

            modelBuilder.Entity("DisasterApiService.Entity.PublicShelterTypes.EmergencyShelterTsunamiEntity", b =>
                {
                    b.Property<int>("OrgNo")
                        .HasColumnType("integer");

                    b.HasKey("OrgNo");

                    b.ToTable("emergency_shelter_tsunami_table");
                });

            modelBuilder.Entity("DisasterApiService.Entity.PublicShelterTypes.EmergencyShelterVolcanoEntity", b =>
                {
                    b.Property<int>("OrgNo")
                        .HasColumnType("integer");

                    b.HasKey("OrgNo");

                    b.ToTable("emergency_shelter_volcano_table");
                });

            modelBuilder.Entity("DisasterApiService.Entity.StructureTypeEntity", b =>
                {
                    b.Property<int>("StructId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StructId"));

                    b.Property<string>("StructName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StructNote")
                        .HasColumnType("text");

                    b.HasKey("StructId");

                    b.ToTable("structure_type_table");
                });

            modelBuilder.Entity("DisasterApiService.Entity.EquipamentEntity", b =>
                {
                    b.HasOne("DisasterApiService.Entity.OrganizationEntity", "Organization")
                        .WithOne("Equip")
                        .HasForeignKey("DisasterApiService.Entity.EquipamentEntity", "OrgNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("DisasterApiService.Entity.OrganizationEntity", b =>
                {
                    b.HasOne("DisasterApiService.Entity.StructureTypeEntity", "StructureType")
                        .WithMany("OrgNo")
                        .HasForeignKey("StructureTypeNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StructureType");
                });

            modelBuilder.Entity("DisasterApiService.Entity.PublicShelterTypes.EmergencyShelterBuringEntity", b =>
                {
                    b.HasOne("DisasterApiService.Entity.OrganizationEntity", "Organization")
                        .WithOne("BuringFlg")
                        .HasForeignKey("DisasterApiService.Entity.PublicShelterTypes.EmergencyShelterBuringEntity", "OrgNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("DisasterApiService.Entity.PublicShelterTypes.EmergencyShelterEarthquakeEntity", b =>
                {
                    b.HasOne("DisasterApiService.Entity.OrganizationEntity", "Organization")
                        .WithOne("EarthquakeFlg")
                        .HasForeignKey("DisasterApiService.Entity.PublicShelterTypes.EmergencyShelterEarthquakeEntity", "OrgNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("DisasterApiService.Entity.PublicShelterTypes.EmergencyShelterFloodEntity", b =>
                {
                    b.HasOne("DisasterApiService.Entity.OrganizationEntity", "Organization")
                        .WithOne("FloodFlg")
                        .HasForeignKey("DisasterApiService.Entity.PublicShelterTypes.EmergencyShelterFloodEntity", "OrgNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("DisasterApiService.Entity.PublicShelterTypes.EmergencyShelterInlandfloodEntity", b =>
                {
                    b.HasOne("DisasterApiService.Entity.OrganizationEntity", "Organization")
                        .WithOne("InlandFlg")
                        .HasForeignKey("DisasterApiService.Entity.PublicShelterTypes.EmergencyShelterInlandfloodEntity", "OrgNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("DisasterApiService.Entity.PublicShelterTypes.EmergencyShelterSliderEntity", b =>
                {
                    b.HasOne("DisasterApiService.Entity.OrganizationEntity", "Organization")
                        .WithOne("SliderFlg")
                        .HasForeignKey("DisasterApiService.Entity.PublicShelterTypes.EmergencyShelterSliderEntity", "OrgNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("DisasterApiService.Entity.PublicShelterTypes.EmergencyShelterSpecifiedEntity", b =>
                {
                    b.HasOne("DisasterApiService.Entity.OrganizationEntity", "Organization")
                        .WithOne("SpecifiedFlg")
                        .HasForeignKey("DisasterApiService.Entity.PublicShelterTypes.EmergencyShelterSpecifiedEntity", "OrgNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("DisasterApiService.Entity.PublicShelterTypes.EmergencyShelterStormsurgeEntity", b =>
                {
                    b.HasOne("DisasterApiService.Entity.OrganizationEntity", "Organization")
                        .WithOne("StormsurgeFlg")
                        .HasForeignKey("DisasterApiService.Entity.PublicShelterTypes.EmergencyShelterStormsurgeEntity", "OrgNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("DisasterApiService.Entity.PublicShelterTypes.EmergencyShelterTsunamiEntity", b =>
                {
                    b.HasOne("DisasterApiService.Entity.OrganizationEntity", "Organization")
                        .WithOne("TsunamiFlg")
                        .HasForeignKey("DisasterApiService.Entity.PublicShelterTypes.EmergencyShelterTsunamiEntity", "OrgNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("DisasterApiService.Entity.PublicShelterTypes.EmergencyShelterVolcanoEntity", b =>
                {
                    b.HasOne("DisasterApiService.Entity.OrganizationEntity", "Organization")
                        .WithOne("VolcanoFlg")
                        .HasForeignKey("DisasterApiService.Entity.PublicShelterTypes.EmergencyShelterVolcanoEntity", "OrgNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("DisasterApiService.Entity.OrganizationEntity", b =>
                {
                    b.Navigation("BuringFlg");

                    b.Navigation("EarthquakeFlg");

                    b.Navigation("Equip");

                    b.Navigation("FloodFlg");

                    b.Navigation("InlandFlg");

                    b.Navigation("SliderFlg");

                    b.Navigation("SpecifiedFlg");

                    b.Navigation("StormsurgeFlg");

                    b.Navigation("TsunamiFlg");

                    b.Navigation("VolcanoFlg");
                });

            modelBuilder.Entity("DisasterApiService.Entity.StructureTypeEntity", b =>
                {
                    b.Navigation("OrgNo");
                });
#pragma warning restore 612, 618
        }
    }
}

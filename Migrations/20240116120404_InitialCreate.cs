using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DisasterApiService.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "structure_type_table",
                columns: table => new
                {
                    StructId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StructName = table.Column<string>(type: "text", nullable: false),
                    StructNote = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_structure_type_table", x => x.StructId);
                });

            migrationBuilder.CreateTable(
                name: "organization_table",
                columns: table => new
                {
                    OrgNo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrgName = table.Column<string>(type: "text", nullable: false),
                    Lon = table.Column<double>(type: "double precision", nullable: false),
                    Lat = table.Column<double>(type: "double precision", nullable: false),
                    StructureTypeNo = table.Column<int>(type: "integer", nullable: false),
                    OrgNote = table.Column<string>(type: "text", nullable: true),
                    OrgTel = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organization_table", x => x.OrgNo);
                    table.ForeignKey(
                        name: "FK_organization_table_structure_type_table_StructureTypeNo",
                        column: x => x.StructureTypeNo,
                        principalTable: "structure_type_table",
                        principalColumn: "StructId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "emergency_shelter_buring_table",
                columns: table => new
                {
                    OrgNo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emergency_shelter_buring_table", x => x.OrgNo);
                    table.ForeignKey(
                        name: "FK_emergency_shelter_buring_table_organization_table_OrgNo",
                        column: x => x.OrgNo,
                        principalTable: "organization_table",
                        principalColumn: "OrgNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "emergency_shelter_earthquake_table",
                columns: table => new
                {
                    OrgNo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emergency_shelter_earthquake_table", x => x.OrgNo);
                    table.ForeignKey(
                        name: "FK_emergency_shelter_earthquake_table_organization_table_OrgNo",
                        column: x => x.OrgNo,
                        principalTable: "organization_table",
                        principalColumn: "OrgNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "emergency_shelter_flood_table",
                columns: table => new
                {
                    OrgNo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emergency_shelter_flood_table", x => x.OrgNo);
                    table.ForeignKey(
                        name: "FK_emergency_shelter_flood_table_organization_table_OrgNo",
                        column: x => x.OrgNo,
                        principalTable: "organization_table",
                        principalColumn: "OrgNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "emergency_shelter_inlandflood_table",
                columns: table => new
                {
                    OrgNo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emergency_shelter_inlandflood_table", x => x.OrgNo);
                    table.ForeignKey(
                        name: "FK_emergency_shelter_inlandflood_table_organization_table_OrgNo",
                        column: x => x.OrgNo,
                        principalTable: "organization_table",
                        principalColumn: "OrgNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "emergency_shelter_slider_table",
                columns: table => new
                {
                    OrgNo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emergency_shelter_slider_table", x => x.OrgNo);
                    table.ForeignKey(
                        name: "FK_emergency_shelter_slider_table_organization_table_OrgNo",
                        column: x => x.OrgNo,
                        principalTable: "organization_table",
                        principalColumn: "OrgNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "emergency_shelter_specified_table",
                columns: table => new
                {
                    OrgNo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emergency_shelter_specified_table", x => x.OrgNo);
                    table.ForeignKey(
                        name: "FK_emergency_shelter_specified_table_organization_table_OrgNo",
                        column: x => x.OrgNo,
                        principalTable: "organization_table",
                        principalColumn: "OrgNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "emergency_shelter_stormsurge_table",
                columns: table => new
                {
                    OrgNo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emergency_shelter_stormsurge_table", x => x.OrgNo);
                    table.ForeignKey(
                        name: "FK_emergency_shelter_stormsurge_table_organization_table_OrgNo",
                        column: x => x.OrgNo,
                        principalTable: "organization_table",
                        principalColumn: "OrgNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "emergency_shelter_tsunami_table",
                columns: table => new
                {
                    OrgNo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emergency_shelter_tsunami_table", x => x.OrgNo);
                    table.ForeignKey(
                        name: "FK_emergency_shelter_tsunami_table_organization_table_OrgNo",
                        column: x => x.OrgNo,
                        principalTable: "organization_table",
                        principalColumn: "OrgNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "emergency_shelter_volcano_table",
                columns: table => new
                {
                    OrgNo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emergency_shelter_volcano_table", x => x.OrgNo);
                    table.ForeignKey(
                        name: "FK_emergency_shelter_volcano_table_organization_table_OrgNo",
                        column: x => x.OrgNo,
                        principalTable: "organization_table",
                        principalColumn: "OrgNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "equipament_table",
                columns: table => new
                {
                    OrgNo = table.Column<int>(type: "integer", nullable: false),
                    WaterFlg = table.Column<bool>(type: "boolean", nullable: false),
                    ElectricityFlg = table.Column<bool>(type: "boolean", nullable: false),
                    FreeWifiFlg = table.Column<bool>(type: "boolean", nullable: false),
                    PhoneNetFlg = table.Column<bool>(type: "boolean", nullable: false),
                    AirConditioningFlg = table.Column<bool>(type: "boolean", nullable: false),
                    EvacuationCount = table.Column<int>(type: "integer", nullable: false),
                    MedicalSystemFlg = table.Column<bool>(type: "boolean", nullable: false),
                    GasFlg = table.Column<bool>(type: "boolean", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipament_table", x => x.OrgNo);
                    table.ForeignKey(
                        name: "FK_equipament_table_organization_table_OrgNo",
                        column: x => x.OrgNo,
                        principalTable: "organization_table",
                        principalColumn: "OrgNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_organization_table_StructureTypeNo",
                table: "organization_table",
                column: "StructureTypeNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "emergency_shelter_buring_table");

            migrationBuilder.DropTable(
                name: "emergency_shelter_earthquake_table");

            migrationBuilder.DropTable(
                name: "emergency_shelter_flood_table");

            migrationBuilder.DropTable(
                name: "emergency_shelter_inlandflood_table");

            migrationBuilder.DropTable(
                name: "emergency_shelter_slider_table");

            migrationBuilder.DropTable(
                name: "emergency_shelter_specified_table");

            migrationBuilder.DropTable(
                name: "emergency_shelter_stormsurge_table");

            migrationBuilder.DropTable(
                name: "emergency_shelter_tsunami_table");

            migrationBuilder.DropTable(
                name: "emergency_shelter_volcano_table");

            migrationBuilder.DropTable(
                name: "equipament_table");

            migrationBuilder.DropTable(
                name: "organization_table");

            migrationBuilder.DropTable(
                name: "structure_type_table");
        }
    }
}

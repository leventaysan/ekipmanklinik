using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HastaneEkipman.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ekipmans",
                columns: table => new
                {
                    EkipmanID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EkipmanName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    EkipmanProcDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EkipmanNumber = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    EkipmanUnitPrice = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    EkipmanUsageRate = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    KlinikID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ekipmans", x => x.EkipmanID);
                });

            migrationBuilder.CreateTable(
                name: "Kliniks",
                columns: table => new
                {
                    KlinikID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KlinikName = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kliniks", x => x.KlinikID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ekipmans");

            migrationBuilder.DropTable(
                name: "Kliniks");
        }
    }
}

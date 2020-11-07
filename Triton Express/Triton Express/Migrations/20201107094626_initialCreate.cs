using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TritonExpress.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Vehicle_Registration_Number = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Vehicle_Number_Plate = table.Column<string>(type: "varchar(255)", nullable: false),
                    Vehicle_Make = table.Column<string>(type: "varchar(255)", nullable: false),
                    Vehicle_Model = table.Column<string>(type: "varchar(255)", nullable: false),
                    Branch = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Vehicle_Registration_Number);
                });

            migrationBuilder.CreateTable(
                name: "Waybill",
                columns: table => new
                {
                    WaybillId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Waybill_Total_weight = table.Column<string>(type: "varchar(255)", nullable: false),
                    Waybil_Total_Parcels_Allocated = table.Column<string>(type: "varchar(255)", nullable: false),
                    Vehicle_Registration_Number = table.Column<int>(nullable: false),
                    Vehicle_Number_Plate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Waybill", x => x.WaybillId);
                    table.ForeignKey(
                        name: "FK_Waybill_Vehicles_Vehicle_Registration_Number",
                        column: x => x.Vehicle_Registration_Number,
                        principalTable: "Vehicles",
                        principalColumn: "Vehicle_Registration_Number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Waybill_Vehicle_Registration_Number",
                table: "Waybill",
                column: "Vehicle_Registration_Number");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Waybill");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}

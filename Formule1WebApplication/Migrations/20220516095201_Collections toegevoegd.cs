using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Formule1WebApplication.Migrations
{
    public partial class Collectionstoegevoegd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Circuits_CircuitID",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Drivers_DriverID",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Grandprixes_GrandprixID",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Teams_TeamID",
                table: "Results");

            migrationBuilder.AlterColumn<int>(
                name: "TeamID",
                table: "Results",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GrandprixID",
                table: "Results",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DriverID",
                table: "Results",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CircuitID",
                table: "Results",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Circuits_CircuitID",
                table: "Results",
                column: "CircuitID",
                principalTable: "Circuits",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Drivers_DriverID",
                table: "Results",
                column: "DriverID",
                principalTable: "Drivers",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Grandprixes_GrandprixID",
                table: "Results",
                column: "GrandprixID",
                principalTable: "Grandprixes",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Teams_TeamID",
                table: "Results",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Circuits_CircuitID",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Drivers_DriverID",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Grandprixes_GrandprixID",
                table: "Results");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_Teams_TeamID",
                table: "Results");

            migrationBuilder.AlterColumn<int>(
                name: "TeamID",
                table: "Results",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GrandprixID",
                table: "Results",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DriverID",
                table: "Results",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CircuitID",
                table: "Results",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Circuits_CircuitID",
                table: "Results",
                column: "CircuitID",
                principalTable: "Circuits",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Drivers_DriverID",
                table: "Results",
                column: "DriverID",
                principalTable: "Drivers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Grandprixes_GrandprixID",
                table: "Results",
                column: "GrandprixID",
                principalTable: "Grandprixes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Teams_TeamID",
                table: "Results",
                column: "TeamID",
                principalTable: "Teams",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

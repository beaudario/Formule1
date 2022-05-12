﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Formule1WebApplication.Migrations
{
    public partial class newmodelsdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CountryFlagUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryCode);
                });

            migrationBuilder.CreateTable(
                name: "Circuits",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    WikiUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CountryID = table.Column<string>(type: "nvarchar(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Circuits", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Circuits_Countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "CountryCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Geslacht = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    WikiUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CountryID = table.Column<string>(type: "nvarchar(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Drivers_Countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "CountryCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WikiUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CountryID = table.Column<string>(type: "nvarchar(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Teams_Countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "CountryCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Grandprixes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Season = table.Column<int>(type: "int", nullable: false),
                    RaceNumber = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rounds = table.Column<int>(type: "int", nullable: false),
                    WinningTime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DriverID = table.Column<int>(type: "int", nullable: true),
                    CircuitID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grandprixes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Grandprixes_Circuits_CircuitID",
                        column: x => x.CircuitID,
                        principalTable: "Circuits",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Grandprixes_Drivers_DriverID",
                        column: x => x.DriverID,
                        principalTable: "Drivers",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Circuits_CountryID",
                table: "Circuits",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_CountryID",
                table: "Drivers",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Grandprixes_CircuitID",
                table: "Grandprixes",
                column: "CircuitID");

            migrationBuilder.CreateIndex(
                name: "IX_Grandprixes_DriverID",
                table: "Grandprixes",
                column: "DriverID");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CountryID",
                table: "Teams",
                column: "CountryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grandprixes");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Circuits");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}

﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Formule1WebApplication.Migrations
{
    public partial class initail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryCode = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code3 = table.Column<string>(type: "char(3)", maxLength: 3, nullable: true),
                    CountryNumber = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    FlagUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
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
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    Wiki = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CountryCode = table.Column<string>(type: "char(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Circuits", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Circuits_Countries_CountryCode",
                        column: x => x.CountryCode,
                        principalTable: "Countries",
                        principalColumn: "CountryCode");
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Wiki = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Gender = table.Column<string>(type: "char(1)", maxLength: 1, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryCode = table.Column<string>(type: "char(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Drivers_Countries_CountryCode",
                        column: x => x.CountryCode,
                        principalTable: "Countries",
                        principalColumn: "CountryCode");
                });

            migrationBuilder.CreateTable(
                name: "Grandprixes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wiki = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CountryCode = table.Column<string>(type: "char(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grandprixes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Grandprixes_Countries_CountryCode",
                        column: x => x.CountryCode,
                        principalTable: "Countries",
                        principalColumn: "CountryCode");
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wiki = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CountryCode = table.Column<string>(type: "char(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Teams_Countries_CountryCode",
                        column: x => x.CountryCode,
                        principalTable: "Countries",
                        principalColumn: "CountryCode");
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Racenumber = table.Column<byte>(type: "tinyint", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Rounds = table.Column<byte>(type: "tinyint", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverID = table.Column<int>(type: "int", nullable: false),
                    GrandprixID = table.Column<int>(type: "int", nullable: false),
                    CircuitID = table.Column<int>(type: "int", nullable: false),
                    TeamID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Results_Circuits_CircuitID",
                        column: x => x.CircuitID,
                        principalTable: "Circuits",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Results_Drivers_DriverID",
                        column: x => x.DriverID,
                        principalTable: "Drivers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Results_Grandprixes_GrandprixID",
                        column: x => x.GrandprixID,
                        principalTable: "Grandprixes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Results_Teams_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Circuits_CountryCode",
                table: "Circuits",
                column: "CountryCode");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_CountryCode",
                table: "Drivers",
                column: "CountryCode");

            migrationBuilder.CreateIndex(
                name: "IX_Grandprixes_CountryCode",
                table: "Grandprixes",
                column: "CountryCode");

            migrationBuilder.CreateIndex(
                name: "IX_Results_CircuitID",
                table: "Results",
                column: "CircuitID");

            migrationBuilder.CreateIndex(
                name: "IX_Results_DriverID",
                table: "Results",
                column: "DriverID");

            migrationBuilder.CreateIndex(
                name: "IX_Results_GrandprixID",
                table: "Results",
                column: "GrandprixID");

            migrationBuilder.CreateIndex(
                name: "IX_Results_TeamID",
                table: "Results",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CountryCode",
                table: "Teams",
                column: "CountryCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "Circuits");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Grandprixes");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}

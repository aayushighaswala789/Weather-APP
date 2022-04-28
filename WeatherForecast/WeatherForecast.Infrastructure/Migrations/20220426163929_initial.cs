using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherForecast.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UnitMeasures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitMeasures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ForecastDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Icon = table.Column<int>(type: "int", nullable: false),
                    IconPhrase = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WindSpeed = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CloudCover = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WindSpeedUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForecastDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForecastDetails_UnitMeasures_WindSpeedUnitId",
                        column: x => x.WindSpeedUnitId,
                        principalTable: "UnitMeasures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Temperatures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MinValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinPhrase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxPhrase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitMeasureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temperatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Temperatures_UnitMeasures_UnitMeasureId",
                        column: x => x.UnitMeasureId,
                        principalTable: "UnitMeasures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeatherForecasts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationKey = table.Column<int>(type: "int", nullable: false),
                    ForecastDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TemperatureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RealFeelTemperatureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NightId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherForecasts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeatherForecasts_ForecastDetails_DayId",
                        column: x => x.DayId,
                        principalTable: "ForecastDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeatherForecasts_ForecastDetails_NightId",
                        column: x => x.NightId,
                        principalTable: "ForecastDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeatherForecasts_Temperatures_RealFeelTemperatureId",
                        column: x => x.RealFeelTemperatureId,
                        principalTable: "Temperatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeatherForecasts_Temperatures_TemperatureId",
                        column: x => x.TemperatureId,
                        principalTable: "Temperatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "UnitMeasures",
                columns: new[] { "Id", "Unit", "UnitType" },
                values: new object[,]
                {
                    { new Guid("dc1777d7-e705-42c1-80bb-bb619730f6e0"), "ft", 0 },
                    { new Guid("8a68f4a6-36fa-464f-9d82-e221568f0db1"), "%", 20 },
                    { new Guid("1a4a079b-9813-4540-b242-21749840d317"), "K", 19 },
                    { new Guid("17088e9c-8636-4bb4-ad2c-1bda69a497f7"), "F", 18 },
                    { new Guid("80a38272-0cca-4943-94ce-22fe1597afe1"), "C", 17 },
                    { new Guid("42c3f36f-0b2d-4e68-bb31-b55c46b613f5"), "psi", 16 },
                    { new Guid("0d767092-b974-46f9-b0ed-78b40556d400"), "mmHg", 15 },
                    { new Guid("ff471d7b-3f8f-428d-ae58-95a0d03bfe2f"), "mbar", 14 },
                    { new Guid("085a009b-bae9-4432-9fe5-06defaff0c30"), "kPa", 13 },
                    { new Guid("72286c7d-5122-4406-9eee-af54d94328f2"), "Hg", 12 },
                    { new Guid("25845b49-0266-421e-b027-08484873568e"), "f", 21 },
                    { new Guid("69769a87-a256-42ea-b97c-0b59fa96b6b8"), "hPa", 11 },
                    { new Guid("86c66721-9354-4cb0-80ef-a298b6bea86c"), "mi/h", 9 },
                    { new Guid("a3cbcea3-71ea-434c-93b0-a163c0bd13b5"), "kt", 8 },
                    { new Guid("30ae5fbc-1a34-4064-b2df-7030be47c024"), "km/h", 7 },
                    { new Guid("90a64f8f-cd3a-44a1-a13d-65330d536af9"), "km", 6 },
                    { new Guid("476b2538-bfe1-4a6d-b1b4-070d94fd5893"), "m", 5 },
                    { new Guid("05eb6296-7ed9-47bb-b081-4ac3f8665ed4"), "cm", 4 },
                    { new Guid("5f5ba08d-980d-4e7a-b5f1-1b19b9944731"), "mm", 3 },
                    { new Guid("26a19e21-af30-4674-b74f-235ba363a9a4"), "mi", 2 },
                    { new Guid("02ef9dd1-073c-459a-a8ed-7b41b2373beb"), "in", 1 },
                    { new Guid("1bb62832-8497-4915-b33c-db1a3cbdb030"), "m/s", 10 },
                    { new Guid("8f6e3329-6cf5-4727-82dc-c8b5967fba3b"), "int", 22 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ForecastDetails_WindSpeedUnitId",
                table: "ForecastDetails",
                column: "WindSpeedUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Temperatures_UnitMeasureId",
                table: "Temperatures",
                column: "UnitMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherForecasts_DayId",
                table: "WeatherForecasts",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherForecasts_NightId",
                table: "WeatherForecasts",
                column: "NightId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherForecasts_RealFeelTemperatureId",
                table: "WeatherForecasts",
                column: "RealFeelTemperatureId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherForecasts_TemperatureId",
                table: "WeatherForecasts",
                column: "TemperatureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherForecasts");

            migrationBuilder.DropTable(
                name: "ForecastDetails");

            migrationBuilder.DropTable(
                name: "Temperatures");

            migrationBuilder.DropTable(
                name: "UnitMeasures");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace weatherCatto.Migrations
{
    /// <inheritdoc />
    public partial class WeatherDatasToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clouds",
                columns: table => new
                {
                    CloudsId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    All = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clouds", x => x.CloudsId);
                });

            migrationBuilder.CreateTable(
                name: "Coord",
                columns: table => new
                {
                    CoordsId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Lon = table.Column<double>(type: "REAL", nullable: false),
                    Lat = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coord", x => x.CoordsId);
                });

            migrationBuilder.CreateTable(
                name: "Main",
                columns: table => new
                {
                    MainId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Temperature = table.Column<double>(type: "REAL", nullable: false),
                    Pressure = table.Column<long>(type: "INTEGER", nullable: false),
                    Humidity = table.Column<long>(type: "INTEGER", nullable: false),
                    temp_min = table.Column<double>(type: "REAL", nullable: false),
                    temp_max = table.Column<double>(type: "REAL", nullable: false),
                    feels_like = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Main", x => x.MainId);
                });

            migrationBuilder.CreateTable(
                name: "Sys",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<long>(type: "INTEGER", nullable: false),
                    Message = table.Column<double>(type: "REAL", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: true),
                    Sunrise = table.Column<long>(type: "INTEGER", nullable: false),
                    Sunset = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wind",
                columns: table => new
                {
                    WindId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Speed = table.Column<double>(type: "REAL", nullable: false),
                    Deg = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wind", x => x.WindId);
                });

            migrationBuilder.CreateTable(
                name: "weatherDatas",
                columns: table => new
                {
                    WeatherId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    CoordsId = table.Column<int>(type: "INTEGER", nullable: true),
                    Base = table.Column<string>(type: "TEXT", nullable: true),
                    MainId = table.Column<int>(type: "INTEGER", nullable: true),
                    Visibility = table.Column<long>(type: "INTEGER", nullable: false),
                    WindId = table.Column<int>(type: "INTEGER", nullable: true),
                    CloudsId = table.Column<int>(type: "INTEGER", nullable: true),
                    Dt = table.Column<long>(type: "INTEGER", nullable: false),
                    SysId = table.Column<long>(type: "INTEGER", nullable: true),
                    Id = table.Column<long>(type: "INTEGER", nullable: false),
                    Cod = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_weatherDatas", x => x.WeatherId);
                    table.ForeignKey(
                        name: "FK_weatherDatas_Clouds_CloudsId",
                        column: x => x.CloudsId,
                        principalTable: "Clouds",
                        principalColumn: "CloudsId");
                    table.ForeignKey(
                        name: "FK_weatherDatas_Coord_CoordsId",
                        column: x => x.CoordsId,
                        principalTable: "Coord",
                        principalColumn: "CoordsId");
                    table.ForeignKey(
                        name: "FK_weatherDatas_Main_MainId",
                        column: x => x.MainId,
                        principalTable: "Main",
                        principalColumn: "MainId");
                    table.ForeignKey(
                        name: "FK_weatherDatas_Sys_SysId",
                        column: x => x.SysId,
                        principalTable: "Sys",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_weatherDatas_Wind_WindId",
                        column: x => x.WindId,
                        principalTable: "Wind",
                        principalColumn: "WindId");
                });

            migrationBuilder.CreateTable(
                name: "Weather",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Visibility = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Icon = table.Column<string>(type: "TEXT", nullable: true),
                    WeatherDataWeatherId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weather", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weather_weatherDatas_WeatherDataWeatherId",
                        column: x => x.WeatherDataWeatherId,
                        principalTable: "weatherDatas",
                        principalColumn: "WeatherId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Weather_WeatherDataWeatherId",
                table: "Weather",
                column: "WeatherDataWeatherId");

            migrationBuilder.CreateIndex(
                name: "IX_weatherDatas_CloudsId",
                table: "weatherDatas",
                column: "CloudsId");

            migrationBuilder.CreateIndex(
                name: "IX_weatherDatas_CoordsId",
                table: "weatherDatas",
                column: "CoordsId");

            migrationBuilder.CreateIndex(
                name: "IX_weatherDatas_MainId",
                table: "weatherDatas",
                column: "MainId");

            migrationBuilder.CreateIndex(
                name: "IX_weatherDatas_SysId",
                table: "weatherDatas",
                column: "SysId");

            migrationBuilder.CreateIndex(
                name: "IX_weatherDatas_WindId",
                table: "weatherDatas",
                column: "WindId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weather");

            migrationBuilder.DropTable(
                name: "weatherDatas");

            migrationBuilder.DropTable(
                name: "Clouds");

            migrationBuilder.DropTable(
                name: "Coord");

            migrationBuilder.DropTable(
                name: "Main");

            migrationBuilder.DropTable(
                name: "Sys");

            migrationBuilder.DropTable(
                name: "Wind");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Worker.Gtfs.Feeder.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransportData",
                columns: table => new
                {
                    CarNumber = table.Column<string>(type: "text", nullable: false),
                    TransportType = table.Column<string>(type: "text", nullable: true),
                    Route = table.Column<string>(type: "text", nullable: true),
                    TripId = table.Column<long>(type: "bigint", nullable: true),
                    Longitude = table.Column<long>(type: "bigint", nullable: true),
                    Latitude = table.Column<long>(type: "bigint", nullable: true),
                    Speed = table.Column<int>(type: "integer", nullable: true),
                    Azimuth = table.Column<int>(type: "integer", nullable: true),
                    TripStartInMinutes = table.Column<int>(type: "integer", nullable: true),
                    DeviationInSeconds = table.Column<int>(type: "integer", nullable: true),
                    MeasurementTime = table.Column<int>(type: "integer", nullable: true),
                    CarType = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportData", x => x.CarNumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransportData");
        }
    }
}

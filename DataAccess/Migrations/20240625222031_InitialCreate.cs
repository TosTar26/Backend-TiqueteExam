using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    RouteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<float>(type: "real", nullable: false),
                    DestinyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExitName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.RouteId);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Exit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destiny = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RouteId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "RouteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "RouteId", "DestinyName", "ExitName", "Price" },
                values: new object[,]
                {
                    { 1, "Lugar 1", "Lugar 2", 500f },
                    { 2, "Lugar 2", "Lugar 1", 500f },
                    { 3, "Lugar 2", "Lugar 3", 1000f },
                    { 4, "Lugar 3", "Lugar 2", 1000f },
                    { 5, "Lugar 1", "Lugar 3", 1500f },
                    { 6, "Lugar 3", "Lugar 1", 1500f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_RouteId",
                table: "Tickets",
                column: "RouteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Routes");
        }
    }
}

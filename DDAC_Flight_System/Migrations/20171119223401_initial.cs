using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DDAC_Flight_System.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    customerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    email = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.customerID);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    arrivalTime = table.Column<DateTime>(nullable: false),
                    departureTime = table.Column<DateTime>(nullable: false),
                    destination = table.Column<string>(nullable: true),
                    flightStatus = table.Column<bool>(nullable: false),
                    origin = table.Column<string>(nullable: true),
                    price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TravelClasses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClassDescription = table.Column<string>(nullable: true),
                    ClassPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelClasses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FlightIDID = table.Column<int>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    TotalPrice = table.Column<decimal>(nullable: false),
                    TravelClassIDID = table.Column<int>(nullable: true),
                    customerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reservations_Flights_FlightIDID",
                        column: x => x.FlightIDID,
                        principalTable: "Flights",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_TravelClasses_TravelClassIDID",
                        column: x => x.TravelClassIDID,
                        principalTable: "TravelClasses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_Customers_customerID",
                        column: x => x.customerID,
                        principalTable: "Customers",
                        principalColumn: "customerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_FlightIDID",
                table: "Reservations",
                column: "FlightIDID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TravelClassIDID",
                table: "Reservations",
                column: "TravelClassIDID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_customerID",
                table: "Reservations",
                column: "customerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "TravelClasses");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}

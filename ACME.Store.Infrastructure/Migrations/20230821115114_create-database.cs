using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ACME.Store.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class createdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    mail = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    createdat = table.Column<DateTime>(name: "created-at", type: "smalldatetime", nullable: false),
                    lastupdatedat = table.Column<DateTime>(name: "last-updated-at", type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    main = table.Column<bool>(type: "bit", nullable: false),
                    street = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    number = table.Column<int>(type: "int", maxLength: 10000, nullable: false),
                    complement = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    neighborhood = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    city = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    state = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    zipcode = table.Column<string>(name: "zip-code", type: "nvarchar(8)", maxLength: 8, nullable: false),
                    createdat = table.Column<DateTime>(name: "created-at", type: "smalldatetime", nullable: false),
                    lastupdatedat = table.Column<DateTime>(name: "last-updated-at", type: "smalldatetime", nullable: true),
                    customerid = table.Column<string>(name: "customer-id", type: "nvarchar(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.id);
                    table.ForeignKey(
                        name: "FK_address_customer_customer-id",
                        column: x => x.customerid,
                        principalTable: "customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_address_customer-id",
                table: "address",
                column: "customer-id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "customer");
        }
    }
}

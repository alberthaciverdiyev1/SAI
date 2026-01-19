using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SAI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedAttributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SearchAttributes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Key = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchAttributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SearchAttributeOptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SearchAttributeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchAttributeOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SearchAttributeOptions_SearchAttributes_SearchAttributeId",
                        column: x => x.SearchAttributeId,
                        principalTable: "SearchAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SearchAttributes",
                columns: new[] { "Id", "CreatedAt", "Key" },
                values: new object[,]
                {
                    { new Guid("ac7c941c-f5f3-466e-ad15-a0b97778a576"), new DateTime(2026, 1, 19, 21, 29, 44, 858, DateTimeKind.Utc).AddTicks(75), "City" },
                    { new Guid("ed33906d-67f1-4ae3-8990-9a14315cbbb7"), new DateTime(2026, 1, 19, 21, 29, 44, 858, DateTimeKind.Utc).AddTicks(99), "Brand" }
                });

            migrationBuilder.InsertData(
                table: "SearchAttributeOptions",
                columns: new[] { "Id", "CreatedAt", "SearchAttributeId", "Value" },
                values: new object[,]
                {
                    { new Guid("103d7ed1-7474-4df1-a963-8a220d068a8b"), new DateTime(2026, 1, 19, 21, 29, 44, 858, DateTimeKind.Utc).AddTicks(283), new Guid("ac7c941c-f5f3-466e-ad15-a0b97778a576"), "Baku" },
                    { new Guid("7b48a2b1-99ff-46f3-ba87-88ecd42cd0d7"), new DateTime(2026, 1, 19, 21, 29, 44, 858, DateTimeKind.Utc).AddTicks(344), new Guid("ed33906d-67f1-4ae3-8990-9a14315cbbb7"), "Apple" },
                    { new Guid("b0af7090-d7d9-4529-91b0-e9e54b00c86c"), new DateTime(2026, 1, 19, 21, 29, 44, 858, DateTimeKind.Utc).AddTicks(378), new Guid("ed33906d-67f1-4ae3-8990-9a14315cbbb7"), "Samsung" },
                    { new Guid("f0b18540-8e31-455e-8a81-238fb60b09ca"), new DateTime(2026, 1, 19, 21, 29, 44, 858, DateTimeKind.Utc).AddTicks(316), new Guid("ac7c941c-f5f3-466e-ad15-a0b97778a576"), "Ganja" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SearchAttributeOptions_SearchAttributeId",
                table: "SearchAttributeOptions",
                column: "SearchAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_SearchAttributes_Key",
                table: "SearchAttributes",
                column: "Key",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SearchAttributeOptions");

            migrationBuilder.DropTable(
                name: "SearchAttributes");
        }
    }
}

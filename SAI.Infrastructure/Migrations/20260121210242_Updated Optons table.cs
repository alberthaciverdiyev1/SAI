using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SAI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedOptonstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SearchAttributeOptions",
                keyColumn: "Id",
                keyValue: new Guid("103d7ed1-7474-4df1-a963-8a220d068a8b"));

            migrationBuilder.DeleteData(
                table: "SearchAttributeOptions",
                keyColumn: "Id",
                keyValue: new Guid("7b48a2b1-99ff-46f3-ba87-88ecd42cd0d7"));

            migrationBuilder.DeleteData(
                table: "SearchAttributeOptions",
                keyColumn: "Id",
                keyValue: new Guid("b0af7090-d7d9-4529-91b0-e9e54b00c86c"));

            migrationBuilder.DeleteData(
                table: "SearchAttributeOptions",
                keyColumn: "Id",
                keyValue: new Guid("f0b18540-8e31-455e-8a81-238fb60b09ca"));

            migrationBuilder.DeleteData(
                table: "SearchAttributes",
                keyColumn: "Id",
                keyValue: new Guid("ac7c941c-f5f3-466e-ad15-a0b97778a576"));

            migrationBuilder.DeleteData(
                table: "SearchAttributes",
                keyColumn: "Id",
                keyValue: new Guid("ed33906d-67f1-4ae3-8990-9a14315cbbb7"));

            migrationBuilder.AddColumn<string>(
                name: "ValueId",
                table: "SearchAttributeOptions",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "SearchAttributes",
                columns: new[] { "Id", "CreatedAt", "Key" },
                values: new object[,]
                {
                    { new Guid("90caf9da-f098-4993-a699-e239e8981d1b"), new DateTime(2026, 1, 21, 21, 2, 42, 303, DateTimeKind.Utc).AddTicks(3163), "City" },
                    { new Guid("92cd3861-57dc-435f-a561-69360bf86ad0"), new DateTime(2026, 1, 21, 21, 2, 42, 303, DateTimeKind.Utc).AddTicks(3187), "Brand" }
                });

            migrationBuilder.InsertData(
                table: "SearchAttributeOptions",
                columns: new[] { "Id", "CreatedAt", "SearchAttributeId", "Value", "ValueId" },
                values: new object[,]
                {
                    { new Guid("088cfeb6-9372-4fce-93c7-5f596e6b5760"), new DateTime(2026, 1, 21, 21, 2, 42, 303, DateTimeKind.Utc).AddTicks(3368), new Guid("90caf9da-f098-4993-a699-e239e8981d1b"), "Baku", "uydbajs" },
                    { new Guid("65ee8b90-183b-49bb-a7d4-18f8362cd22c"), new DateTime(2026, 1, 21, 21, 2, 42, 303, DateTimeKind.Utc).AddTicks(3458), new Guid("92cd3861-57dc-435f-a561-69360bf86ad0"), "Samsung", "123" },
                    { new Guid("b896e7e1-a73a-4e94-ba54-71a06d3376c1"), new DateTime(2026, 1, 21, 21, 2, 42, 303, DateTimeKind.Utc).AddTicks(3429), new Guid("92cd3861-57dc-435f-a561-69360bf86ad0"), "Apple", "090" },
                    { new Guid("c3ccc437-f273-49d7-bf50-6e420ac20b0b"), new DateTime(2026, 1, 21, 21, 2, 42, 303, DateTimeKind.Utc).AddTicks(3396), new Guid("90caf9da-f098-4993-a699-e239e8981d1b"), "Ganja", "123" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SearchAttributeOptions",
                keyColumn: "Id",
                keyValue: new Guid("088cfeb6-9372-4fce-93c7-5f596e6b5760"));

            migrationBuilder.DeleteData(
                table: "SearchAttributeOptions",
                keyColumn: "Id",
                keyValue: new Guid("65ee8b90-183b-49bb-a7d4-18f8362cd22c"));

            migrationBuilder.DeleteData(
                table: "SearchAttributeOptions",
                keyColumn: "Id",
                keyValue: new Guid("b896e7e1-a73a-4e94-ba54-71a06d3376c1"));

            migrationBuilder.DeleteData(
                table: "SearchAttributeOptions",
                keyColumn: "Id",
                keyValue: new Guid("c3ccc437-f273-49d7-bf50-6e420ac20b0b"));

            migrationBuilder.DeleteData(
                table: "SearchAttributes",
                keyColumn: "Id",
                keyValue: new Guid("90caf9da-f098-4993-a699-e239e8981d1b"));

            migrationBuilder.DeleteData(
                table: "SearchAttributes",
                keyColumn: "Id",
                keyValue: new Guid("92cd3861-57dc-435f-a561-69360bf86ad0"));

            migrationBuilder.DropColumn(
                name: "ValueId",
                table: "SearchAttributeOptions");

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
        }
    }
}

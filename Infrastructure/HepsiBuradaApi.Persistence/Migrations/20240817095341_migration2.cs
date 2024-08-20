using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HepsiBuradaApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 17, 9, 53, 41, 179, DateTimeKind.Utc).AddTicks(2550));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 17, 9, 53, 41, 179, DateTimeKind.Utc).AddTicks(2550));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 17, 9, 53, 41, 179, DateTimeKind.Utc).AddTicks(2550));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 17, 9, 53, 41, 179, DateTimeKind.Utc).AddTicks(3080));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 17, 9, 53, 41, 179, DateTimeKind.Utc).AddTicks(3080));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 17, 9, 53, 41, 179, DateTimeKind.Utc).AddTicks(3080));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 17, 9, 53, 41, 179, DateTimeKind.Utc).AddTicks(3080));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 17, 9, 53, 41, 179, DateTimeKind.Utc).AddTicks(3080));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 17, 9, 53, 41, 179, DateTimeKind.Utc).AddTicks(3480));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 17, 9, 53, 41, 179, DateTimeKind.Utc).AddTicks(3480));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 17, 9, 53, 41, 179, DateTimeKind.Utc).AddTicks(3480));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 17, 9, 53, 41, 179, DateTimeKind.Utc).AddTicks(3480));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CreatedDate", "Description", "Discount", "IsDeleted", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 8, 17, 9, 53, 41, 179, DateTimeKind.Utc).AddTicks(3840), "M2", 10m, false, 25000m, "Macbook Air" },
                    { 2, 1, new DateTime(2024, 8, 17, 9, 53, 41, 179, DateTimeKind.Utc).AddTicks(3850), "M2", 20m, false, 40000m, "Macbook Pro" },
                    { 3, 1, new DateTime(2024, 8, 17, 9, 53, 41, 179, DateTimeKind.Utc).AddTicks(3850), "", 20m, false, 40000m, "Kot Pantolon" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 17, 9, 51, 16, 170, DateTimeKind.Utc).AddTicks(6480));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 17, 9, 51, 16, 170, DateTimeKind.Utc).AddTicks(6480));

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 17, 9, 51, 16, 170, DateTimeKind.Utc).AddTicks(6480));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 17, 9, 51, 16, 170, DateTimeKind.Utc).AddTicks(6970));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 17, 9, 51, 16, 170, DateTimeKind.Utc).AddTicks(6970));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 17, 9, 51, 16, 170, DateTimeKind.Utc).AddTicks(6970));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 17, 9, 51, 16, 170, DateTimeKind.Utc).AddTicks(6970));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 17, 9, 51, 16, 170, DateTimeKind.Utc).AddTicks(6970));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 17, 9, 51, 16, 170, DateTimeKind.Utc).AddTicks(7340));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 17, 9, 51, 16, 170, DateTimeKind.Utc).AddTicks(7340));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 17, 9, 51, 16, 170, DateTimeKind.Utc).AddTicks(7340));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 17, 9, 51, 16, 170, DateTimeKind.Utc).AddTicks(7340));
        }
    }
}

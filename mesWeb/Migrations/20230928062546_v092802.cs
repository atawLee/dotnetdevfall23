using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mesWeb.Migrations
{
    /// <inheritdoc />
    public partial class v092802 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "Manufactures",
                newName: "Worker");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDateTime",
                table: "WorkOrders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "WorkOrders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpireDate",
                table: "WorkOrders",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "OrderUser",
                table: "WorkOrders",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Product",
                table: "WorkOrders",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<decimal>(
                name: "TargetQty",
                table: "WorkOrders",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FaultQty",
                table: "Manufactures",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "Manufactures",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "WorkEndTime",
                table: "Manufactures",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "WorkQty",
                table: "Manufactures",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "WorkStartTime",
                table: "Manufactures",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDateTime",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "ExpireDate",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "OrderUser",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "Product",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "TargetQty",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "FaultQty",
                table: "Manufactures");

            migrationBuilder.DropColumn(
                name: "Summary",
                table: "Manufactures");

            migrationBuilder.DropColumn(
                name: "WorkEndTime",
                table: "Manufactures");

            migrationBuilder.DropColumn(
                name: "WorkQty",
                table: "Manufactures");

            migrationBuilder.DropColumn(
                name: "WorkStartTime",
                table: "Manufactures");

            migrationBuilder.RenameColumn(
                name: "Worker",
                table: "Manufactures",
                newName: "ProductName");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IVCRM.DAL.Migrations
{
    public partial class FixOrderEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Orders",
                newName: "OrderDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "ProductStorages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "ProductStorages");

            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "Orders",
                newName: "CreationDate");
        }
    }
}

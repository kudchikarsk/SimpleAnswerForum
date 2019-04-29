using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleAnswerForum.Migrations
{
    public partial class AddDateTimeForAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Answer",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Answer",
                nullable: false,
                defaultValueSql: "getdate()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Answer");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Answer");
        }
    }
}

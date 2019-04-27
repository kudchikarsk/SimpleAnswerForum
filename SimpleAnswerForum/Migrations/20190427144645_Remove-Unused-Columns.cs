using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SimpleAnswerForum.Migrations
{
    public partial class RemoveUnusedColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "UpvoteQuestion");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UpvoteAnswer");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TopicQuestion");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DownvoteQuestion");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DownvoteAnswer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "UpvoteQuestion",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "UpvoteAnswer",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "TopicQuestion",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "DownvoteQuestion",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "DownvoteAnswer",
                nullable: false,
                defaultValue: 0L);
        }
    }
}

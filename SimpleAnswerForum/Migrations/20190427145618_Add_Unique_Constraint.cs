using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SimpleAnswerForum.Migrations
{
    public partial class Add_Unique_Constraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UpvoteQuestion_ApplicationUserId",
                table: "UpvoteQuestion");

            migrationBuilder.DropIndex(
                name: "IX_UpvoteAnswer_ApplicationUserId",
                table: "UpvoteAnswer");

            migrationBuilder.DropIndex(
                name: "IX_DownvoteQuestion_ApplicationUserId",
                table: "DownvoteQuestion");

            migrationBuilder.DropIndex(
                name: "IX_DownvoteAnswer_ApplicationUserId",
                table: "DownvoteAnswer");

            migrationBuilder.CreateIndex(
                name: "IX_UpvoteQuestion_ApplicationUserId_QuestionId",
                table: "UpvoteQuestion",
                columns: new[] { "ApplicationUserId", "QuestionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UpvoteAnswer_ApplicationUserId_AnswerId",
                table: "UpvoteAnswer",
                columns: new[] { "ApplicationUserId", "AnswerId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TopicQuestion_TopicId_QuestionId",
                table: "TopicQuestion",
                columns: new[] { "TopicId", "QuestionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DownvoteQuestion_ApplicationUserId_QuestionId",
                table: "DownvoteQuestion",
                columns: new[] { "ApplicationUserId", "QuestionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DownvoteAnswer_ApplicationUserId_AnswerId",
                table: "DownvoteAnswer",
                columns: new[] { "ApplicationUserId", "AnswerId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UpvoteQuestion_ApplicationUserId_QuestionId",
                table: "UpvoteQuestion");

            migrationBuilder.DropIndex(
                name: "IX_UpvoteAnswer_ApplicationUserId_AnswerId",
                table: "UpvoteAnswer");

            migrationBuilder.DropIndex(
                name: "IX_TopicQuestion_TopicId_QuestionId",
                table: "TopicQuestion");

            migrationBuilder.DropIndex(
                name: "IX_DownvoteQuestion_ApplicationUserId_QuestionId",
                table: "DownvoteQuestion");

            migrationBuilder.DropIndex(
                name: "IX_DownvoteAnswer_ApplicationUserId_AnswerId",
                table: "DownvoteAnswer");

            migrationBuilder.CreateIndex(
                name: "IX_UpvoteQuestion_ApplicationUserId",
                table: "UpvoteQuestion",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UpvoteAnswer_ApplicationUserId",
                table: "UpvoteAnswer",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DownvoteQuestion_ApplicationUserId",
                table: "DownvoteQuestion",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DownvoteAnswer_ApplicationUserId",
                table: "DownvoteAnswer",
                column: "ApplicationUserId");
        }
    }
}

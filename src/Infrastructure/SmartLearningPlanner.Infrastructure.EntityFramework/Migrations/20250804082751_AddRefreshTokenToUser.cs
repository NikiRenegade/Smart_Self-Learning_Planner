using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartLearningPlanner.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddRefreshTokenToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MindmapEdges_MindmapNodes_MindmapNodeId",
                table: "MindmapEdges");

            migrationBuilder.DropIndex(
                name: "IX_MindmapEdges_MindmapNodeId",
                table: "MindmapEdges");

            migrationBuilder.DropColumn(
                name: "MindmapNodeId",
                table: "MindmapEdges");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "character varying(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "Users",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(64)",
                oldMaxLength: 64);

            migrationBuilder.AddColumn<int>(
                name: "MindmapNodeId",
                table: "MindmapEdges",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MindmapEdges_MindmapNodeId",
                table: "MindmapEdges",
                column: "MindmapNodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MindmapEdges_MindmapNodes_MindmapNodeId",
                table: "MindmapEdges",
                column: "MindmapNodeId",
                principalTable: "MindmapNodes",
                principalColumn: "Id");
        }
    }
}

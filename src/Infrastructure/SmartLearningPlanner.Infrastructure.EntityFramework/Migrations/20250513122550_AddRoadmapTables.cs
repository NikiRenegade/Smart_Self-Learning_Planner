using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SmartLearningPlanner.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddRoadmapTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Missions_Roadmaps_RoadmapId",
                table: "Missions");

            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_Roadmaps_RoadmapId",
                table: "Quizzes");

            migrationBuilder.DropForeignKey(
                name: "FK_Resources_Roadmaps_RoadmapId",
                table: "Resources");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Roadmaps_RoadmapId",
                table: "Tags");

            migrationBuilder.DropTable(
                name: "Roadmaps");

            migrationBuilder.DropIndex(
                name: "IX_Resources_RoadmapId",
                table: "Resources");

            migrationBuilder.DropIndex(
                name: "IX_Quizzes_RoadmapId",
                table: "Quizzes");

            migrationBuilder.DropIndex(
                name: "IX_Missions_RoadmapId",
                table: "Missions");

            migrationBuilder.DropColumn(
                name: "RoadmapId",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "RoadmapId",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "RoadmapId",
                table: "Missions");

            migrationBuilder.RenameColumn(
                name: "RoadmapId",
                table: "Tags",
                newName: "MindmapNodeId");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_RoadmapId",
                table: "Tags",
                newName: "IX_Tags_MindmapNodeId");

            migrationBuilder.AddColumn<int>(
                name: "MindmapNodeId",
                table: "Resources",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MindmapNodeId",
                table: "Quizzes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MindmapNodeId",
                table: "Missions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MindmapNodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ShortDescription = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Notes = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    Result = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    UserId = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MindmapNodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MindmapEdges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParentId = table.Column<int>(type: "integer", nullable: false),
                    ChildId = table.Column<int>(type: "integer", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    MindmapNodeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MindmapEdges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MindmapEdges_MindmapNodes_ChildId",
                        column: x => x.ChildId,
                        principalTable: "MindmapNodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MindmapEdges_MindmapNodes_MindmapNodeId",
                        column: x => x.MindmapNodeId,
                        principalTable: "MindmapNodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MindmapEdges_MindmapNodes_ParentId",
                        column: x => x.ParentId,
                        principalTable: "MindmapNodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserNodeProgress",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    NodeId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNodeProgress", x => new { x.UserId, x.NodeId });
                    table.ForeignKey(
                        name: "FK_UserNodeProgress_MindmapNodes_NodeId",
                        column: x => x.NodeId,
                        principalTable: "MindmapNodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resources_MindmapNodeId",
                table: "Resources",
                column: "MindmapNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_MindmapNodeId",
                table: "Quizzes",
                column: "MindmapNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_MindmapNodeId",
                table: "Missions",
                column: "MindmapNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_MindmapEdges_ChildId",
                table: "MindmapEdges",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_MindmapEdges_MindmapNodeId",
                table: "MindmapEdges",
                column: "MindmapNodeId");

            migrationBuilder.CreateIndex(
                name: "IX_MindmapEdges_ParentId",
                table: "MindmapEdges",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNodeProgress_NodeId",
                table: "UserNodeProgress",
                column: "NodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Missions_MindmapNodes_MindmapNodeId",
                table: "Missions",
                column: "MindmapNodeId",
                principalTable: "MindmapNodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_MindmapNodes_MindmapNodeId",
                table: "Quizzes",
                column: "MindmapNodeId",
                principalTable: "MindmapNodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_MindmapNodes_MindmapNodeId",
                table: "Resources",
                column: "MindmapNodeId",
                principalTable: "MindmapNodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_MindmapNodes_MindmapNodeId",
                table: "Tags",
                column: "MindmapNodeId",
                principalTable: "MindmapNodes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Missions_MindmapNodes_MindmapNodeId",
                table: "Missions");

            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_MindmapNodes_MindmapNodeId",
                table: "Quizzes");

            migrationBuilder.DropForeignKey(
                name: "FK_Resources_MindmapNodes_MindmapNodeId",
                table: "Resources");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_MindmapNodes_MindmapNodeId",
                table: "Tags");

            migrationBuilder.DropTable(
                name: "MindmapEdges");

            migrationBuilder.DropTable(
                name: "UserNodeProgress");

            migrationBuilder.DropTable(
                name: "MindmapNodes");

            migrationBuilder.DropIndex(
                name: "IX_Resources_MindmapNodeId",
                table: "Resources");

            migrationBuilder.DropIndex(
                name: "IX_Quizzes_MindmapNodeId",
                table: "Quizzes");

            migrationBuilder.DropIndex(
                name: "IX_Missions_MindmapNodeId",
                table: "Missions");

            migrationBuilder.DropColumn(
                name: "MindmapNodeId",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "MindmapNodeId",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "MindmapNodeId",
                table: "Missions");

            migrationBuilder.RenameColumn(
                name: "MindmapNodeId",
                table: "Tags",
                newName: "RoadmapId");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_MindmapNodeId",
                table: "Tags",
                newName: "IX_Tags_RoadmapId");

            migrationBuilder.AddColumn<int>(
                name: "RoadmapId",
                table: "Resources",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoadmapId",
                table: "Quizzes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoadmapId",
                table: "Missions",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Roadmaps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Notes = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    ParentRoadmapId = table.Column<int>(type: "integer", nullable: true),
                    Result = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    Title = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roadmaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roadmaps_Roadmaps_ParentRoadmapId",
                        column: x => x.ParentRoadmapId,
                        principalTable: "Roadmaps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resources_RoadmapId",
                table: "Resources",
                column: "RoadmapId");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_RoadmapId",
                table: "Quizzes",
                column: "RoadmapId");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_RoadmapId",
                table: "Missions",
                column: "RoadmapId");

            migrationBuilder.CreateIndex(
                name: "IX_Roadmaps_ParentRoadmapId",
                table: "Roadmaps",
                column: "ParentRoadmapId");

            migrationBuilder.AddForeignKey(
                name: "FK_Missions_Roadmaps_RoadmapId",
                table: "Missions",
                column: "RoadmapId",
                principalTable: "Roadmaps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_Roadmaps_RoadmapId",
                table: "Quizzes",
                column: "RoadmapId",
                principalTable: "Roadmaps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_Roadmaps_RoadmapId",
                table: "Resources",
                column: "RoadmapId",
                principalTable: "Roadmaps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Roadmaps_RoadmapId",
                table: "Tags",
                column: "RoadmapId",
                principalTable: "Roadmaps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

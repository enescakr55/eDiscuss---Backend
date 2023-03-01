using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class updatedNotificationModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NotificationMessage",
                table: "Notifications",
                newName: "NotificationValue");

            migrationBuilder.CreateTable(
                name: "FollowedDiscussions",
                columns: table => new
                {
                    FollowedDiscussionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DiscussId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowedDiscussions", x => x.FollowedDiscussionId);
                    table.ForeignKey(
                        name: "FK_FollowedDiscussions_Discusses_DiscussId",
                        column: x => x.DiscussId,
                        principalTable: "Discusses",
                        principalColumn: "DiscussId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FollowedDiscussions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FollowedDiscussions_DiscussId",
                table: "FollowedDiscussions",
                column: "DiscussId");

            migrationBuilder.CreateIndex(
                name: "IX_FollowedDiscussions_UserId",
                table: "FollowedDiscussions",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FollowedDiscussions");

            migrationBuilder.RenameColumn(
                name: "NotificationValue",
                table: "Notifications",
                newName: "NotificationMessage");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class passwordresetcode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discusses_Categories_CategoryId",
                table: "Discusses");

            migrationBuilder.DropForeignKey(
                name: "FK_Discusses_Subjects_SubjectId",
                table: "Discusses");

            migrationBuilder.DropForeignKey(
                name: "FK_Discusses_Users_UserId",
                table: "Discusses");

            migrationBuilder.DropForeignKey(
                name: "FK_Replies_Discusses_DiscussId",
                table: "Replies");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Categories_CategoryId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_CategoryId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Replies_DiscussId",
                table: "Replies");

            migrationBuilder.DropIndex(
                name: "IX_Discusses_CategoryId",
                table: "Discusses");

            migrationBuilder.DropIndex(
                name: "IX_Discusses_SubjectId",
                table: "Discusses");

            migrationBuilder.DropIndex(
                name: "IX_Discusses_UserId",
                table: "Discusses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Subjects_CategoryId",
                table: "Subjects",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_DiscussId",
                table: "Replies",
                column: "DiscussId");

            migrationBuilder.CreateIndex(
                name: "IX_Discusses_CategoryId",
                table: "Discusses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Discusses_SubjectId",
                table: "Discusses",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Discusses_UserId",
                table: "Discusses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Discusses_Categories_CategoryId",
                table: "Discusses",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Discusses_Subjects_SubjectId",
                table: "Discusses",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Discusses_Users_UserId",
                table: "Discusses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_Discusses_DiscussId",
                table: "Replies",
                column: "DiscussId",
                principalTable: "Discusses",
                principalColumn: "DiscussId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Categories_CategoryId",
                table: "Subjects",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

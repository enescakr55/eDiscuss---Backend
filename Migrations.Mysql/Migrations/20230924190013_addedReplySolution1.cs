using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrations.Mysql.Migrations
{
    public partial class addedReplySolution1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discusses_Replies_ReplyId",
                table: "Discusses");

            migrationBuilder.RenameColumn(
                name: "ReplyId",
                table: "Discusses",
                newName: "Solution");

            migrationBuilder.RenameIndex(
                name: "IX_Discusses_ReplyId",
                table: "Discusses",
                newName: "IX_Discusses_Solution");

            migrationBuilder.AddForeignKey(
                name: "FK_Discusses_Replies_Solution",
                table: "Discusses",
                column: "Solution",
                principalTable: "Replies",
                principalColumn: "ReplyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discusses_Replies_Solution",
                table: "Discusses");

            migrationBuilder.RenameColumn(
                name: "Solution",
                table: "Discusses",
                newName: "ReplyId");

            migrationBuilder.RenameIndex(
                name: "IX_Discusses_Solution",
                table: "Discusses",
                newName: "IX_Discusses_ReplyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Discusses_Replies_ReplyId",
                table: "Discusses",
                column: "ReplyId",
                principalTable: "Replies",
                principalColumn: "ReplyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

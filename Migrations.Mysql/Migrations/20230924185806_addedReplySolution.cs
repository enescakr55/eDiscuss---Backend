using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrations.Mysql.Migrations
{
    public partial class addedReplySolution : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "UserCodes",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "ReplyId",
                table: "Discusses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Discusses_ReplyId",
                table: "Discusses",
                column: "ReplyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Discusses_Replies_ReplyId",
                table: "Discusses",
                column: "ReplyId",
                principalTable: "Replies",
                principalColumn: "ReplyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discusses_Replies_ReplyId",
                table: "Discusses");

            migrationBuilder.DropIndex(
                name: "IX_Discusses_ReplyId",
                table: "Discusses");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "UserCodes");

            migrationBuilder.DropColumn(
                name: "ReplyId",
                table: "Discusses");
        }
    }
}

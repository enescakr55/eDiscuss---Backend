using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrations.Mysql.Migrations
{
    public partial class addedReplySolution2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discusses_Replies_Solution",
                table: "Discusses");

            migrationBuilder.AlterColumn<int>(
                name: "Solution",
                table: "Discusses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Discusses_Replies_Solution",
                table: "Discusses",
                column: "Solution",
                principalTable: "Replies",
                principalColumn: "ReplyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discusses_Replies_Solution",
                table: "Discusses");

            migrationBuilder.AlterColumn<int>(
                name: "Solution",
                table: "Discusses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Discusses_Replies_Solution",
                table: "Discusses",
                column: "Solution",
                principalTable: "Replies",
                principalColumn: "ReplyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

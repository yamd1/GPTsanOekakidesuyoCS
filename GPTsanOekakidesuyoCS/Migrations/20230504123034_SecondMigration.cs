using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GPTsanOekakidesuyoCS.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Session_SessionId",
                table: "Message");

            migrationBuilder.AlterColumn<int>(
                name: "SessionId",
                table: "Message",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Session_SessionId",
                table: "Message",
                column: "SessionId",
                principalTable: "Session",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Session_SessionId",
                table: "Message");

            migrationBuilder.AlterColumn<int>(
                name: "SessionId",
                table: "Message",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Session_SessionId",
                table: "Message",
                column: "SessionId",
                principalTable: "Session",
                principalColumn: "Id");
        }
    }
}

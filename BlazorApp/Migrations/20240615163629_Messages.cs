using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp.Migrations
{
    /// <inheritdoc />
    public partial class Messages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Accounts_ReceiverId",
                table: "Messages");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Profiles_ReceiverId",
                table: "Messages",
                column: "ReceiverId",
                principalTable: "Profiles",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Profiles_ReceiverId",
                table: "Messages");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Accounts_ReceiverId",
                table: "Messages",
                column: "ReceiverId",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

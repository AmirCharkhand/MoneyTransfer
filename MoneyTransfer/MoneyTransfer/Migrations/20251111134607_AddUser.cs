using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MoneyTransfer.Migrations
{
    /// <inheritdoc />
    public partial class AddUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "BankAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "BankAccounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "BankAccounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "BankAccounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: 3);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "user1@email.com", "Rayan", "Reynolds", new byte[] { 230, 238, 118, 217, 85, 135, 110, 189, 117, 121, 10, 67, 49, 64, 166, 190, 254, 32, 246, 145, 194, 145, 196, 255, 171, 4, 14, 1, 42, 20, 68, 160, 59, 232, 16, 148, 18, 99, 141, 9, 165, 60, 72, 160, 243, 59, 230, 221, 32, 229, 255, 14, 96, 14, 84, 12, 74, 148, 104, 251, 117, 127, 18, 131 }, new byte[] { 116, 64, 92, 102, 127, 9, 84, 253, 61, 41, 68, 33, 234, 59, 171, 78, 138, 107, 117, 221, 211, 138, 190, 125, 200, 214, 240, 12, 86, 239, 234, 184, 129, 196, 164, 87, 197, 135, 47, 75, 0, 135, 41, 138, 220, 206, 44, 164, 179, 45, 103, 13, 249, 118, 66, 93, 215, 35, 42, 200, 13, 47, 71, 10, 234, 230, 109, 79, 156, 80, 209, 72, 57, 133, 94, 165, 76, 70, 14, 100, 171, 217, 154, 65, 228, 161, 56, 90, 136, 149, 36, 159, 76, 121, 225, 107, 151, 23, 204, 215, 227, 107, 253, 197, 72, 32, 196, 48, 4, 219, 226, 197, 171, 63, 238, 157, 211, 65, 3, 54, 179, 42, 144, 47, 204, 55, 193, 24 }, "123-456-7890" },
                    { 2, "user2@email.com", "Emma", "Stone", new byte[] { 230, 238, 118, 217, 85, 135, 110, 189, 117, 121, 10, 67, 49, 64, 166, 190, 254, 32, 246, 145, 194, 145, 196, 255, 171, 4, 14, 1, 42, 20, 68, 160, 59, 232, 16, 148, 18, 99, 141, 9, 165, 60, 72, 160, 243, 59, 230, 221, 32, 229, 255, 14, 96, 14, 84, 12, 74, 148, 104, 251, 117, 127, 18, 131 }, new byte[] { 116, 64, 92, 102, 127, 9, 84, 253, 61, 41, 68, 33, 234, 59, 171, 78, 138, 107, 117, 221, 211, 138, 190, 125, 200, 214, 240, 12, 86, 239, 234, 184, 129, 196, 164, 87, 197, 135, 47, 75, 0, 135, 41, 138, 220, 206, 44, 164, 179, 45, 103, 13, 249, 118, 66, 93, 215, 35, 42, 200, 13, 47, 71, 10, 234, 230, 109, 79, 156, 80, 209, 72, 57, 133, 94, 165, 76, 70, 14, 100, 171, 217, 154, 65, 228, 161, 56, 90, 136, 149, 36, 159, 76, 121, 225, 107, 151, 23, 204, 215, 227, 107, 253, 197, 72, 32, 196, 48, 4, 219, 226, 197, 171, 63, 238, 157, 211, 65, 3, 54, 179, 42, 144, 47, 204, 55, 193, 24 }, "234-567-8901" },
                    { 3, "user3@email.com", "Chris", "Evans", new byte[] { 230, 238, 118, 217, 85, 135, 110, 189, 117, 121, 10, 67, 49, 64, 166, 190, 254, 32, 246, 145, 194, 145, 196, 255, 171, 4, 14, 1, 42, 20, 68, 160, 59, 232, 16, 148, 18, 99, 141, 9, 165, 60, 72, 160, 243, 59, 230, 221, 32, 229, 255, 14, 96, 14, 84, 12, 74, 148, 104, 251, 117, 127, 18, 131 }, new byte[] { 116, 64, 92, 102, 127, 9, 84, 253, 61, 41, 68, 33, 234, 59, 171, 78, 138, 107, 117, 221, 211, 138, 190, 125, 200, 214, 240, 12, 86, 239, 234, 184, 129, 196, 164, 87, 197, 135, 47, 75, 0, 135, 41, 138, 220, 206, 44, 164, 179, 45, 103, 13, 249, 118, 66, 93, 215, 35, 42, 200, 13, 47, 71, 10, 234, 230, 109, 79, 156, 80, 209, 72, 57, 133, 94, 165, 76, 70, 14, 100, 171, 217, 154, 65, 228, 161, 56, 90, 136, 149, 36, 159, 76, 121, 225, 107, 151, 23, 204, 215, 227, 107, 253, 197, 72, 32, 196, 48, 4, 219, 226, 197, 171, 63, 238, 157, 211, 65, 3, 54, 179, 42, 144, 47, 204, 55, 193, 24 }, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_UserId",
                table: "BankAccounts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_Users_UserId",
                table: "BankAccounts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_Users_UserId",
                table: "BankAccounts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_BankAccounts_UserId",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BankAccounts");
        }
    }
}

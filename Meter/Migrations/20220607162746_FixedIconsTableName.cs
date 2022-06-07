using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Meter.Migrations
{
    public partial class FixedIconsTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Counters_Icon_IconId",
                table: "Counters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Icon",
                table: "Icon");

            migrationBuilder.RenameTable(
                name: "Icon",
                newName: "Icons");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Icons",
                table: "Icons",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "RoleId" },
                values: new object[] { 2, "anna.romaniuk@oa.edu.ua", "qwerty", 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_Counters_Icons_IconId",
                table: "Counters",
                column: "IconId",
                principalTable: "Icons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Counters_Icons_IconId",
                table: "Counters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Icons",
                table: "Icons");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "Icons",
                newName: "Icon");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Icon",
                table: "Icon",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Counters_Icon_IconId",
                table: "Counters",
                column: "IconId",
                principalTable: "Icon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

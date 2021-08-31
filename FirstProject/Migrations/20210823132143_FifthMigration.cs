using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstProject.Migrations
{
    public partial class FifthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DropPrimaryKey(
                name: "PK_CenterUsers",
                table: "CenterUsers");*/

            /*migrationBuilder.DropIndex(
                name: "IX_CenterUsers_UserId",
                table: "CenterUsers");*/

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "CenterUsers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CenterUsers",
                table: "CenterUsers",
                columns: new[] { "UserId", "CenterId" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Админ", "Admin" },
                    { 2, "Преподаватель", "Teacher" },
                    { 3, "Владелец", "Owner" },
                    { 4, "Студент", "Student" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CenterUsers",
                table: "CenterUsers");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "CenterUsers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CenterUsers",
                table: "CenterUsers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CenterUsers_UserId",
                table: "CenterUsers",
                column: "UserId");
        }
    }
}

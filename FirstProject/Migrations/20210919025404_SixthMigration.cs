using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstProject.Migrations
{
    public partial class SixthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET FOREIGN_KEY_CHECKS=0;");
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

            migrationBuilder.DeleteData(
               table: "CenterUsers",
               keyColumn: "Id",
               keyValue: 1);

            migrationBuilder.DeleteData(
               table: "Center",
               keyColumn: "Id",
               keyValue: 1);
            migrationBuilder.DeleteData(
               table: "Center",
               keyColumn: "Id",
               keyValue: 2);
            migrationBuilder.DeleteData(
               table: "Center",
               keyColumn: "Id",
               keyValue: 3);

            migrationBuilder.DeleteData(
               table: "City",
               keyColumn: "Id",
               keyValue: 1);
            migrationBuilder.DeleteData(
               table: "City",
               keyColumn: "Id",
               keyValue: 2);

            migrationBuilder.DeleteData(
               table: "Country",
               keyColumn: "Id",
               keyValue: 1);
            migrationBuilder.DeleteData(
               table: "Country",
               keyColumn: "Id",
               keyValue: 2);

            migrationBuilder.DeleteData(
              table: "Users",
              keyColumn: "Id",
              keyValue: 4);
            migrationBuilder.DeleteData(
               table: "Users",
               keyColumn: "Id",
               keyValue: 5);
            migrationBuilder.DeleteData(
              table: "Users",
              keyColumn: "Id",
              keyValue: 7);
            migrationBuilder.DeleteData(
               table: "Users",
               keyColumn: "Id",
               keyValue: 8);
            migrationBuilder.DeleteData(
              table: "Users",
              keyColumn: "Id",
              keyValue: 26);

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Qazaqstan" },
                    { 2, "Russia" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "IIN", "LastName", "MiddleName", "Password", "RoleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 9, 19, 8, 54, 4, 0, DateTimeKind.Local).AddTicks(3142), "mekthiev.1995@bk.ru", "Давид", "11111111111", "Мехтиев", "Низамиевич", "$2b$10$Pc5eHaDTvQyvSfvUR6Haxeq4FX3uqvFYnlewKFtlW.F2wYDAJRGCS", 3 },
                    { 2, new DateTime(2021, 9, 19, 8, 54, 4, 100, DateTimeKind.Local).AddTicks(6031), "shagirovaDayana@gmail.com", "Даяна", "123123154345", "Шагирова", "Жолдасбековна", "$2b$10$sBSBlkab4TY1Dsw6UvRJC.0kARbPd00Zq/ONahyIV9KlRP6C52SIy", 1 },
                    { 3, new DateTime(2021, 9, 19, 8, 54, 4, 196, DateTimeKind.Local).AddTicks(4979), "litvinov.2004@mail.ru", "Никита", "24523452341", "Литвинов", "Сергеевич", "$2b$10$mf5yOXGgjZS46dbBSeoYfu9P//muCSfzbg6Wu/ik7o4AYBvmjy75G", 2 },
                    { 4, new DateTime(2021, 9, 19, 8, 54, 4, 289, DateTimeKind.Local).AddTicks(9824), "maksim12313@mail.ru", "Максим", "112624511111", "Дворянкин", "Иванович", null, 4 }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Nur-Sultan" },
                    { 2, 1, "Almaty" },
                    { 3, 2, "Moscow" },
                    { 4, 2, "St-Petersburg" }
                });

            migrationBuilder.InsertData(
                table: "Center",
                columns: new[] { "Id", "CityId", "CountryId", "Created", "Name" },
                values: new object[,]
                {
                    { 3, 1, 1, new DateTime(2021, 9, 19, 8, 54, 4, 0, DateTimeKind.Local).AddTicks(2067), "Nur-Center №1" },
                    { 4, 1, 1, new DateTime(2021, 9, 19, 8, 54, 4, 0, DateTimeKind.Local).AddTicks(2070), "Nur-Center №2" },
                    { 1, 2, 1, new DateTime(2021, 9, 19, 8, 54, 3, 999, DateTimeKind.Local).AddTicks(1376), "Alma-Center №1" },
                    { 2, 2, 1, new DateTime(2021, 9, 19, 8, 54, 4, 0, DateTimeKind.Local).AddTicks(2013), "Alma-Center №2" },
                    { 5, 3, 2, new DateTime(2021, 9, 19, 8, 54, 4, 0, DateTimeKind.Local).AddTicks(2072), "Moscow-Center №1" },
                    { 6, 3, 2, new DateTime(2021, 9, 19, 8, 54, 4, 0, DateTimeKind.Local).AddTicks(2073), "Moscow-Center №2" },
                    { 7, 4, 2, new DateTime(2021, 9, 19, 8, 54, 4, 0, DateTimeKind.Local).AddTicks(2075), "Petersburg-Center №1" },
                    { 8, 4, 2, new DateTime(2021, 9, 19, 8, 54, 4, 0, DateTimeKind.Local).AddTicks(2077), "Petersburg-Center №2" }
                });

            migrationBuilder.InsertData(
                table: "CenterUsers",
                columns: new[] { "CenterId", "UserId", "Id" },
                values: new object[,]
                {
                    { 3, 1, 1 },
                    { 1, 4, 4 },
                    { 5, 2, 2 },
                    { 8, 3, 3 }
                });
            migrationBuilder.Sql("SET FOREIGN_KEY_CHECKS=1;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Center",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Center",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Center",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Center",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CenterUsers",
                keyColumns: new[] { "CenterId", "UserId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "CenterUsers",
                keyColumns: new[] { "CenterId", "UserId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "CenterUsers",
                keyColumns: new[] { "CenterId", "UserId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "CenterUsers",
                keyColumns: new[] { "CenterId", "UserId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "Center",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Center",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Center",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Center",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

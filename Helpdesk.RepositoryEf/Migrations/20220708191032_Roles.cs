using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Helpdesk.RepositoryEf.Migrations
{
    public partial class Roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                type: "varchar(12)",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(12)",
                oldMaxLength: 12)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Project",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldMaxLength: 1000)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Person",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRegistration",
                table: "Person",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Person",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Person",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "Agency",
                type: "varchar(5)",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(5)",
                oldMaxLength: 5)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "TownHall",
                table: "Agency",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Agency",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Settlement",
                table: "Agency",
                type: "varchar(120)",
                maxLength: 120,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(120)",
                oldMaxLength: 120)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Agency",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Agency",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldMaxLength: 1000)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Log",
                table: "Agency",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Agency",
                type: "varchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Agency",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Device",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SerialNumber = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LicenseDateStart = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LicenseDateEnd = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Notes = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeviceStateId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateRegistration = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DeviceState",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateRegistration = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceState", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateRegistration = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Agency",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 7, 8, 14, 10, 32, 193, DateTimeKind.Local).AddTicks(4287));

            migrationBuilder.UpdateData(
                table: "AgencyType",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 7, 8, 14, 10, 32, 193, DateTimeKind.Local).AddTicks(4255));

            migrationBuilder.UpdateData(
                table: "AgencyType",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateRegistration",
                value: new DateTime(2022, 7, 8, 14, 10, 32, 193, DateTimeKind.Local).AddTicks(4259));

            migrationBuilder.UpdateData(
                table: "AgencyType",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateRegistration",
                value: new DateTime(2022, 7, 8, 14, 10, 32, 193, DateTimeKind.Local).AddTicks(4262));

            migrationBuilder.UpdateData(
                table: "AgencyType",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateRegistration",
                value: new DateTime(2022, 7, 8, 14, 10, 32, 193, DateTimeKind.Local).AddTicks(4265));

            migrationBuilder.InsertData(
                table: "DeviceState",
                columns: new[] { "Id", "DateRegistration", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 8, 14, 10, 32, 193, DateTimeKind.Local).AddTicks(4370), true, "En almacen" },
                    { 2, new DateTime(2022, 7, 8, 14, 10, 32, 193, DateTimeKind.Local).AddTicks(4373), true, "Asignado" },
                    { 3, new DateTime(2022, 7, 8, 14, 10, 32, 193, DateTimeKind.Local).AddTicks(4376), true, "Merma" }
                });

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateRegistration", "IsActive" },
                values: new object[] { new DateTime(2022, 7, 8, 14, 10, 32, 193, DateTimeKind.Local).AddTicks(4307), true });

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 7, 8, 14, 10, 32, 193, DateTimeKind.Local).AddTicks(4142));

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "DateRegistration", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 8, 14, 10, 32, 193, DateTimeKind.Local).AddTicks(4325), true, "Nivel 1" },
                    { 2, new DateTime(2022, 7, 8, 14, 10, 32, 193, DateTimeKind.Local).AddTicks(4329), true, "Nivel 2" },
                    { 3, new DateTime(2022, 7, 8, 14, 10, 32, 193, DateTimeKind.Local).AddTicks(4332), true, "Nivel 3" },
                    { 4, new DateTime(2022, 7, 8, 14, 10, 32, 193, DateTimeKind.Local).AddTicks(4336), true, "Nivel 4" }
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateRegistration", "RoleId" },
                values: new object[] { new DateTime(2022, 7, 8, 14, 10, 32, 193, DateTimeKind.Local).AddTicks(4352), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Person_AgencyId",
                table: "Person",
                column: "AgencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Agency_AgencyId",
                table: "Person",
                column: "AgencyId",
                principalTable: "Agency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Agency_AgencyId",
                table: "Person");

            migrationBuilder.DropTable(
                name: "Device");

            migrationBuilder.DropTable(
                name: "DeviceState");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Person_AgencyId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DateRegistration",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Person");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Password",
                keyValue: null,
                column: "Password",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                type: "varchar(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(12)",
                oldMaxLength: 12,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Notes",
                keyValue: null,
                column: "Notes",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Project",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "LastName",
                keyValue: null,
                column: "LastName",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Person",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Agency",
                keyColumn: "ZipCode",
                keyValue: null,
                column: "ZipCode",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "Agency",
                type: "varchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(5)",
                oldMaxLength: 5,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Agency",
                keyColumn: "TownHall",
                keyValue: null,
                column: "TownHall",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "TownHall",
                table: "Agency",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Agency",
                keyColumn: "State",
                keyValue: null,
                column: "State",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Agency",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Agency",
                keyColumn: "Settlement",
                keyValue: null,
                column: "Settlement",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Settlement",
                table: "Agency",
                type: "varchar(120)",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(120)",
                oldMaxLength: 120,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Agency",
                keyColumn: "Phone",
                keyValue: null,
                column: "Phone",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Agency",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Agency",
                keyColumn: "Notes",
                keyValue: null,
                column: "Notes",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Agency",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Agency",
                keyColumn: "Log",
                keyValue: null,
                column: "Log",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Log",
                table: "Agency",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Agency",
                keyColumn: "Code",
                keyValue: null,
                column: "Code",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Agency",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Agency",
                keyColumn: "Address",
                keyValue: null,
                column: "Address",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Agency",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Agency",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 6, 14, 15, 23, 19, 930, DateTimeKind.Local).AddTicks(3938));

            migrationBuilder.UpdateData(
                table: "AgencyType",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 6, 14, 15, 23, 19, 930, DateTimeKind.Local).AddTicks(3911));

            migrationBuilder.UpdateData(
                table: "AgencyType",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateRegistration",
                value: new DateTime(2022, 6, 14, 15, 23, 19, 930, DateTimeKind.Local).AddTicks(3914));

            migrationBuilder.UpdateData(
                table: "AgencyType",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateRegistration",
                value: new DateTime(2022, 6, 14, 15, 23, 19, 930, DateTimeKind.Local).AddTicks(3918));

            migrationBuilder.UpdateData(
                table: "AgencyType",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateRegistration",
                value: new DateTime(2022, 6, 14, 15, 23, 19, 930, DateTimeKind.Local).AddTicks(3921));

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 6, 14, 15, 23, 19, 930, DateTimeKind.Local).AddTicks(3809));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 6, 14, 15, 23, 19, 930, DateTimeKind.Local).AddTicks(3969));
        }
    }
}

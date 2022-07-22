using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Helpdesk.RepositoryEf.Migrations
{
    public partial class FormsAgency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropColumn(
            //     name: "Name",
            //     table: "User");

            // migrationBuilder.DropColumn(
            //     name: "LicenseDateEnd",
            //     table: "Device");

            // migrationBuilder.DropColumn(
            //     name: "LicenseDateStart",
            //     table: "Device");

            // migrationBuilder.AddColumn<string>(
            //     name: "Email",
            //     table: "User",
            //     type: "varchar(50)",
            //     maxLength: 50,
            //     nullable: true)
            //     .Annotation("MySql:CharSet", "utf8mb4");

            // migrationBuilder.AddColumn<int>(
            //     name: "UserId",
            //     table: "User",
            //     type: "int",
            //     nullable: false,
            //     defaultValue: 0);

            // migrationBuilder.AddColumn<string>(
            //     name: "Reason",
            //     table: "Project",
            //     type: "longtext",
            //     nullable: true)
            //     .Annotation("MySql:CharSet", "utf8mb4");

            // migrationBuilder.AddColumn<DateTime>(
            //     name: "DateEnd",
            //     table: "Device",
            //     type: "datetime(6)",
            //     nullable: true);

            // migrationBuilder.AddColumn<DateTime>(
            //     name: "DateStart",
            //     table: "Device",
            //     type: "datetime(6)",
            //     nullable: true);

            // migrationBuilder.AddColumn<int>(
            //     name: "FormAgencyEntityId",
            //     table: "Device",
            //     type: "int",
            //     nullable: true);

            // migrationBuilder.AddColumn<int>(
            //     name: "UserId",
            //     table: "Device",
            //     type: "int",
            //     nullable: false,
            //     defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FormAgency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    AgencyId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Text = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateRegistration = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormAgency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormAgency_Agency_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "Agency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FormAgencyDevices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FormAgencyId = table.Column<int>(type: "int", nullable: false),
                    DeviceId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateRegistration = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormAgencyDevices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormAgencyDevices_Device_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Device",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormAgencyDevices_FormAgency_FormAgencyId",
                        column: x => x.FormAgencyId,
                        principalTable: "FormAgency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Agency",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 7, 21, 16, 27, 55, 506, DateTimeKind.Local).AddTicks(8985));

            migrationBuilder.UpdateData(
                table: "AgencyType",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 7, 21, 16, 27, 55, 506, DateTimeKind.Local).AddTicks(8953));

            migrationBuilder.UpdateData(
                table: "AgencyType",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateRegistration",
                value: new DateTime(2022, 7, 21, 16, 27, 55, 506, DateTimeKind.Local).AddTicks(8957));

            migrationBuilder.UpdateData(
                table: "AgencyType",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateRegistration",
                value: new DateTime(2022, 7, 21, 16, 27, 55, 506, DateTimeKind.Local).AddTicks(8960));

            migrationBuilder.UpdateData(
                table: "AgencyType",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateRegistration",
                value: new DateTime(2022, 7, 21, 16, 27, 55, 506, DateTimeKind.Local).AddTicks(8964));

            migrationBuilder.UpdateData(
                table: "DeviceState",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 7, 21, 16, 27, 55, 506, DateTimeKind.Local).AddTicks(9062));

            migrationBuilder.UpdateData(
                table: "DeviceState",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateRegistration",
                value: new DateTime(2022, 7, 21, 16, 27, 55, 506, DateTimeKind.Local).AddTicks(9066));

            migrationBuilder.UpdateData(
                table: "DeviceState",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateRegistration",
                value: new DateTime(2022, 7, 21, 16, 27, 55, 506, DateTimeKind.Local).AddTicks(9069));

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 7, 21, 16, 27, 55, 506, DateTimeKind.Local).AddTicks(9003));

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 7, 21, 16, 27, 55, 506, DateTimeKind.Local).AddTicks(8828));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 7, 21, 16, 27, 55, 506, DateTimeKind.Local).AddTicks(9019));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateRegistration",
                value: new DateTime(2022, 7, 21, 16, 27, 55, 506, DateTimeKind.Local).AddTicks(9023));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateRegistration",
                value: new DateTime(2022, 7, 21, 16, 27, 55, 506, DateTimeKind.Local).AddTicks(9026));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateRegistration",
                value: new DateTime(2022, 7, 21, 16, 27, 55, 506, DateTimeKind.Local).AddTicks(9029));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateRegistration", "Email" },
                values: new object[] { new DateTime(2022, 7, 21, 16, 27, 55, 506, DateTimeKind.Local).AddTicks(9044), "administrador" });

            migrationBuilder.CreateIndex(
                name: "IX_User_PersonId",
                table: "User",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Device_FormAgencyEntityId",
                table: "Device",
                column: "FormAgencyEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_FormAgency_AgencyId",
                table: "FormAgency",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_FormAgencyDevices_DeviceId",
                table: "FormAgencyDevices",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_FormAgencyDevices_FormAgencyId",
                table: "FormAgencyDevices",
                column: "FormAgencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Device_FormAgency_FormAgencyEntityId",
                table: "Device",
                column: "FormAgencyEntityId",
                principalTable: "FormAgency",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Person_PersonId",
                table: "User",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Device_FormAgency_FormAgencyEntityId",
                table: "Device");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Person_PersonId",
                table: "User");

            migrationBuilder.DropTable(
                name: "FormAgencyDevices");

            migrationBuilder.DropTable(
                name: "FormAgency");

            migrationBuilder.DropIndex(
                name: "IX_User_PersonId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Device_FormAgencyEntityId",
                table: "Device");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "DateEnd",
                table: "Device");

            migrationBuilder.DropColumn(
                name: "DateStart",
                table: "Device");

            migrationBuilder.DropColumn(
                name: "FormAgencyEntityId",
                table: "Device");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Device");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "User",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "LicenseDateEnd",
                table: "Device",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LicenseDateStart",
                table: "Device",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

            migrationBuilder.UpdateData(
                table: "DeviceState",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 7, 8, 14, 10, 32, 193, DateTimeKind.Local).AddTicks(4370));

            migrationBuilder.UpdateData(
                table: "DeviceState",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateRegistration",
                value: new DateTime(2022, 7, 8, 14, 10, 32, 193, DateTimeKind.Local).AddTicks(4373));

            migrationBuilder.UpdateData(
                table: "DeviceState",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateRegistration",
                value: new DateTime(2022, 7, 8, 14, 10, 32, 193, DateTimeKind.Local).AddTicks(4376));

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 7, 8, 14, 10, 32, 193, DateTimeKind.Local).AddTicks(4307));

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 7, 8, 14, 10, 32, 193, DateTimeKind.Local).AddTicks(4142));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 7, 8, 14, 10, 32, 193, DateTimeKind.Local).AddTicks(4325));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateRegistration",
                value: new DateTime(2022, 7, 8, 14, 10, 32, 193, DateTimeKind.Local).AddTicks(4329));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateRegistration",
                value: new DateTime(2022, 7, 8, 14, 10, 32, 193, DateTimeKind.Local).AddTicks(4332));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateRegistration",
                value: new DateTime(2022, 7, 8, 14, 10, 32, 193, DateTimeKind.Local).AddTicks(4336));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateRegistration", "Name" },
                values: new object[] { new DateTime(2022, 7, 8, 14, 10, 32, 193, DateTimeKind.Local).AddTicks(4352), "administrador" });
        }
    }
}

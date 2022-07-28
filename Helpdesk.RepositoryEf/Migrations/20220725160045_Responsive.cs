using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Helpdesk.RepositoryEf.Migrations
{
    public partial class Responsive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Device_FormAgency_FormAgencyEntityId",
                table: "Device");

            migrationBuilder.DropTable(
                name: "FormAgencyDevices");

            migrationBuilder.DropTable(
                name: "FormAgency");

            migrationBuilder.DropIndex(
                name: "IX_Device_FormAgencyEntityId",
                table: "Device");

            migrationBuilder.RenameColumn(
                name: "FormAgencyEntityId",
                table: "Device",
                newName: "AgencyId");

            migrationBuilder.CreateTable(
                name: "Responsive",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AgencyId = table.Column<int>(type: "int", nullable: false),
                    DocumentId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateRegistration = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsive", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Agency",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 7, 25, 11, 0, 45, 194, DateTimeKind.Local).AddTicks(2941));

            migrationBuilder.UpdateData(
                table: "AgencyType",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 7, 25, 11, 0, 45, 194, DateTimeKind.Local).AddTicks(2910));

            migrationBuilder.UpdateData(
                table: "AgencyType",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateRegistration",
                value: new DateTime(2022, 7, 25, 11, 0, 45, 194, DateTimeKind.Local).AddTicks(2914));

            migrationBuilder.UpdateData(
                table: "AgencyType",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateRegistration",
                value: new DateTime(2022, 7, 25, 11, 0, 45, 194, DateTimeKind.Local).AddTicks(2917));

            migrationBuilder.UpdateData(
                table: "AgencyType",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateRegistration",
                value: new DateTime(2022, 7, 25, 11, 0, 45, 194, DateTimeKind.Local).AddTicks(2921));

            migrationBuilder.UpdateData(
                table: "DeviceState",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 7, 25, 11, 0, 45, 194, DateTimeKind.Local).AddTicks(3020));

            migrationBuilder.UpdateData(
                table: "DeviceState",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateRegistration",
                value: new DateTime(2022, 7, 25, 11, 0, 45, 194, DateTimeKind.Local).AddTicks(3023));

            migrationBuilder.UpdateData(
                table: "DeviceState",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateRegistration",
                value: new DateTime(2022, 7, 25, 11, 0, 45, 194, DateTimeKind.Local).AddTicks(3027));

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 7, 25, 11, 0, 45, 194, DateTimeKind.Local).AddTicks(2962));

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 7, 25, 11, 0, 45, 194, DateTimeKind.Local).AddTicks(2793));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 7, 25, 11, 0, 45, 194, DateTimeKind.Local).AddTicks(2978));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateRegistration",
                value: new DateTime(2022, 7, 25, 11, 0, 45, 194, DateTimeKind.Local).AddTicks(2982));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateRegistration",
                value: new DateTime(2022, 7, 25, 11, 0, 45, 194, DateTimeKind.Local).AddTicks(2985));

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateRegistration",
                value: new DateTime(2022, 7, 25, 11, 0, 45, 194, DateTimeKind.Local).AddTicks(2988));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateRegistration",
                value: new DateTime(2022, 7, 25, 11, 0, 45, 194, DateTimeKind.Local).AddTicks(3005));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Responsive");

            migrationBuilder.RenameColumn(
                name: "AgencyId",
                table: "Device",
                newName: "FormAgencyEntityId");

            migrationBuilder.CreateTable(
                name: "FormAgency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AgencyId = table.Column<int>(type: "int", nullable: false),
                    DateRegistration = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                    DeviceId = table.Column<int>(type: "int", nullable: false),
                    FormAgencyId = table.Column<int>(type: "int", nullable: false),
                    DateRegistration = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                column: "DateRegistration",
                value: new DateTime(2022, 7, 21, 16, 27, 55, 506, DateTimeKind.Local).AddTicks(9044));

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
        }
    }
}

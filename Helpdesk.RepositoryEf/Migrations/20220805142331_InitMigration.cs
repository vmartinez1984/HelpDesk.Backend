using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Helpdesk.RepositoryEf.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgencyType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgencyType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Device",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    DeviceStateId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AgencyId = table.Column<int>(type: "int", nullable: true),
                    DateRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceState",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceState", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    AgencyTypeId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TownHall = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Settlement = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Log = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DateRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agency_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AgencyId = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    DateRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Agency_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "Agency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Responsive",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgencyId = table.Column<int>(type: "int", nullable: false),
                    DocumentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateSend = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsive", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Responsive_Agency_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "Agency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DateRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AgencyType",
                columns: new[] { "Id", "DateRegistration", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 8, 5, 9, 23, 30, 973, DateTimeKind.Local).AddTicks(4395), true, "Corporativo" },
                    { 2, new DateTime(2022, 8, 5, 9, 23, 30, 973, DateTimeKind.Local).AddTicks(4399), true, "Matriz" },
                    { 3, new DateTime(2022, 8, 5, 9, 23, 30, 973, DateTimeKind.Local).AddTicks(4402), true, "Sucursal" },
                    { 4, new DateTime(2022, 8, 5, 9, 23, 30, 973, DateTimeKind.Local).AddTicks(4405), true, "Punto de venta" }
                });

            migrationBuilder.InsertData(
                table: "DeviceState",
                columns: new[] { "Id", "DateRegistration", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 8, 5, 9, 23, 30, 973, DateTimeKind.Local).AddTicks(4555), true, "En almacen" },
                    { 2, new DateTime(2022, 8, 5, 9, 23, 30, 973, DateTimeKind.Local).AddTicks(4558), true, "Asignado" },
                    { 3, new DateTime(2022, 8, 5, 9, 23, 30, 973, DateTimeKind.Local).AddTicks(4561), true, "Merma" }
                });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Id", "DateRegistration", "IsActive", "Name", "Notes", "Reason", "UserId" },
                values: new object[] { 1, new DateTime(2022, 8, 5, 9, 23, 30, 973, DateTimeKind.Local).AddTicks(4256), true, "Proyecto inicial", "Proyecto inicial", null, 1 });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "DateRegistration", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 8, 5, 9, 23, 30, 973, DateTimeKind.Local).AddTicks(4507), true, "Nivel 1" },
                    { 2, new DateTime(2022, 8, 5, 9, 23, 30, 973, DateTimeKind.Local).AddTicks(4511), true, "Nivel 2" },
                    { 3, new DateTime(2022, 8, 5, 9, 23, 30, 973, DateTimeKind.Local).AddTicks(4514), true, "Nivel 3" },
                    { 4, new DateTime(2022, 8, 5, 9, 23, 30, 973, DateTimeKind.Local).AddTicks(4518), true, "Nivel 4" }
                });

            migrationBuilder.InsertData(
                table: "Agency",
                columns: new[] { "Id", "Address", "AgencyTypeId", "Code", "DateRegistration", "IsActive", "Log", "Name", "Notes", "Phone", "ProjectId", "Settlement", "State", "TownHall", "UserId", "ZipCode" },
                values: new object[] { 1, "Domicilio conocido", 1, "01", new DateTime(2022, 8, 5, 9, 23, 30, 973, DateTimeKind.Local).AddTicks(4428), true, "", "Principal", "", "", 1, "", "", "", 1, "" });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "AgencyId", "DateRegistration", "IsActive", "LastName", "Name", "Notes", "UserId" },
                values: new object[] { 1, 1, new DateTime(2022, 8, 5, 9, 23, 30, 973, DateTimeKind.Local).AddTicks(4446), true, "Admin", "Admin", null, 1 });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateRegistration", "Email", "IsActive", "Password", "PersonId", "RoleId", "UserId" },
                values: new object[] { 1, new DateTime(2022, 8, 5, 9, 23, 30, 973, DateTimeKind.Local).AddTicks(4536), "administrador", true, "123456", 1, 1, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Agency_ProjectId",
                table: "Agency",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_AgencyId",
                table: "Person",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Responsive_AgencyId",
                table: "Responsive",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_User_PersonId",
                table: "User",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgencyType");

            migrationBuilder.DropTable(
                name: "Device");

            migrationBuilder.DropTable(
                name: "DeviceState");

            migrationBuilder.DropTable(
                name: "Responsive");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Agency");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}

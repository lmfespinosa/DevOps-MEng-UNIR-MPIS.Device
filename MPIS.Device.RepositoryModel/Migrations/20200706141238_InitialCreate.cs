using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MPIS.Device.RepositoryModel.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Core");

            migrationBuilder.EnsureSchema(
                name: "Extermal");

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Extermal",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    MAC = table.Column<string>(nullable: true),
                    ComputerName = table.Column<string>(nullable: true),
                    TypeSO = table.Column<int>(nullable: false),
                    EmailUser = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Devices_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Extermal",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hardwares",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    Device = table.Column<string>(nullable: true),
                    TypeHardware = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    MACDevice = table.Column<string>(nullable: true),
                    DeviceUnitId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hardwares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hardwares_Devices_DeviceUnitId",
                        column: x => x.DeviceUnitId,
                        principalSchema: "Core",
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OperativeSystems",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    MACDevice = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    DeviceId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperativeSystems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperativeSystems_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "Core",
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Softwares",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<DateTime>(nullable: true),
                    MACDevice = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    DeviceId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Softwares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Softwares_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "Core",
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Devices_MAC",
                schema: "Core",
                table: "Devices",
                column: "MAC");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_UserId",
                schema: "Core",
                table: "Devices",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Hardwares_DeviceUnitId",
                schema: "Core",
                table: "Hardwares",
                column: "DeviceUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Hardwares_MACDevice",
                schema: "Core",
                table: "Hardwares",
                column: "MACDevice");

            migrationBuilder.CreateIndex(
                name: "IX_OperativeSystems_DeviceId",
                schema: "Core",
                table: "OperativeSystems",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_OperativeSystems_MACDevice",
                schema: "Core",
                table: "OperativeSystems",
                column: "MACDevice");

            migrationBuilder.CreateIndex(
                name: "IX_Softwares_DeviceId",
                schema: "Core",
                table: "Softwares",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Softwares_MACDevice",
                schema: "Core",
                table: "Softwares",
                column: "MACDevice");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                schema: "Extermal",
                table: "Users",
                column: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hardwares",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "OperativeSystems",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "Softwares",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "Devices",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Extermal");
        }
    }
}

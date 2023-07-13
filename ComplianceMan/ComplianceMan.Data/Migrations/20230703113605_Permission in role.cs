using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComplianceMan.Data.Migrations
{
    public partial class Permissioninrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RolePermission",
                columns: table => new
                {
                    RolePermissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Permission = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermission", x => x.RolePermissionId);
                    table.ForeignKey(
                        name: "FK_RolePermission_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "UserPolicies",
                keyColumn: "UserPolicyId",
                keyValue: 1,
                column: "AcceptanceDate",
                value: new DateTime(2023, 7, 3, 17, 36, 5, 193, DateTimeKind.Local).AddTicks(1565));

            migrationBuilder.UpdateData(
                table: "UserPolicies",
                keyColumn: "UserPolicyId",
                keyValue: 2,
                column: "AcceptanceDate",
                value: new DateTime(2023, 7, 3, 17, 36, 5, 193, DateTimeKind.Local).AddTicks(1579));

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_RoleId",
                table: "RolePermission",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolePermission");

            migrationBuilder.UpdateData(
                table: "UserPolicies",
                keyColumn: "UserPolicyId",
                keyValue: 1,
                column: "AcceptanceDate",
                value: new DateTime(2023, 6, 30, 6, 10, 37, 87, DateTimeKind.Local).AddTicks(1097));

            migrationBuilder.UpdateData(
                table: "UserPolicies",
                keyColumn: "UserPolicyId",
                keyValue: 2,
                column: "AcceptanceDate",
                value: new DateTime(2023, 6, 30, 6, 10, 37, 87, DateTimeKind.Local).AddTicks(1107));
        }
    }
}

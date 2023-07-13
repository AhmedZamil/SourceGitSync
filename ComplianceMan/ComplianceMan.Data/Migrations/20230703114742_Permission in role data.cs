using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComplianceMan.Data.Migrations
{
    public partial class Permissioninroledata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "RolePermissionId", "Permission", "RoleId" },
                values: new object[,]
                {
                    { 1, "EditUsers", 1 },
                    { 2, "DeleteUsers", 1 },
                    { 3, "ViewUsers", 2 }
                });

            migrationBuilder.UpdateData(
                table: "UserPolicies",
                keyColumn: "UserPolicyId",
                keyValue: 1,
                column: "AcceptanceDate",
                value: new DateTime(2023, 7, 3, 17, 47, 41, 783, DateTimeKind.Local).AddTicks(651));

            migrationBuilder.UpdateData(
                table: "UserPolicies",
                keyColumn: "UserPolicyId",
                keyValue: 2,
                column: "AcceptanceDate",
                value: new DateTime(2023, 7, 3, 17, 47, 41, 783, DateTimeKind.Local).AddTicks(665));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "RolePermissionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "RolePermissionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "RolePermissionId",
                keyValue: 3);

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
        }
    }
}

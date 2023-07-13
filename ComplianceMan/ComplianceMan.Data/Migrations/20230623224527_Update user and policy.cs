using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComplianceMan.Data.Migrations
{
    public partial class Updateuserandpolicy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "UserPolicies",
                keyColumn: "UserPolicyId",
                keyValue: 1,
                column: "AcceptanceDate",
                value: new DateTime(2023, 6, 24, 4, 45, 27, 146, DateTimeKind.Local).AddTicks(8998));

            migrationBuilder.UpdateData(
                table: "UserPolicies",
                keyColumn: "UserPolicyId",
                keyValue: 2,
                column: "AcceptanceDate",
                value: new DateTime(2023, 6, 24, 4, 45, 27, 146, DateTimeKind.Local).AddTicks(9015));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "UserPolicies",
                keyColumn: "UserPolicyId",
                keyValue: 1,
                column: "AcceptanceDate",
                value: new DateTime(2023, 6, 20, 0, 50, 45, 973, DateTimeKind.Local).AddTicks(945));

            migrationBuilder.UpdateData(
                table: "UserPolicies",
                keyColumn: "UserPolicyId",
                keyValue: 2,
                column: "AcceptanceDate",
                value: new DateTime(2023, 6, 20, 0, 50, 45, 973, DateTimeKind.Local).AddTicks(956));
        }
    }
}

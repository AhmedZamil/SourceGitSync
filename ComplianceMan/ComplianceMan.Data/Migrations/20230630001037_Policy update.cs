using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComplianceMan.Data.Migrations
{
    public partial class Policyupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Policies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 1,
                column: "Description",
                value: "Policy Basic Description");

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "PolicyId",
                keyValue: 2,
                column: "Description",
                value: "Policy Basic Description");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Policies");

            migrationBuilder.UpdateData(
                table: "UserPolicies",
                keyColumn: "UserPolicyId",
                keyValue: 1,
                column: "AcceptanceDate",
                value: new DateTime(2023, 6, 24, 21, 35, 27, 689, DateTimeKind.Local).AddTicks(4499));

            migrationBuilder.UpdateData(
                table: "UserPolicies",
                keyColumn: "UserPolicyId",
                keyValue: 2,
                column: "AcceptanceDate",
                value: new DateTime(2023, 6, 24, 21, 35, 27, 689, DateTimeKind.Local).AddTicks(4514));
        }
    }
}

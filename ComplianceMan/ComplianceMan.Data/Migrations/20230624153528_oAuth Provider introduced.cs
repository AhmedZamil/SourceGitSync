using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComplianceMan.Data.Migrations
{
    public partial class oAuthProviderintroduced : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserCode",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "UserToken",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserToken",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "UserCode",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}

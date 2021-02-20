using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Alpaca.Data.EFCore.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfigApp",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    VerifyMissingDays = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateUserID = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUserID = table.Column<int>(type: "int", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigApp", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ConfigAppEnvironment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConfigAppID = table.Column<int>(type: "int", nullable: false),
                    ConfigEnvironmentID = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateUserID = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUserID = table.Column<int>(type: "int", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigAppEnvironment", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ConfigEnvironment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateUserID = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUserID = table.Column<int>(type: "int", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigEnvironment", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ConfigItem",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namespace = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ConfigAppID = table.Column<int>(type: "int", nullable: false),
                    ConfigEnvironmentID = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateUserID = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUserID = table.Column<int>(type: "int", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigItem", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ConfigItemSniffer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConfigAppID = table.Column<int>(type: "int", nullable: false),
                    Namespace = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    VerifyMissingTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateUserID = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUserID = table.Column<int>(type: "int", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigItemSniffer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateUserID = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUserID = table.Column<int>(type: "int", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateUserID = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUserID = table.Column<int>(type: "int", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserPermission",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    PermissionCode = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    AppID = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateUserID = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUserID = table.Column<int>(type: "int", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermission", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "ID", "Code", "CreateTime", "CreateUserID", "IsDeleted", "Name", "UpdateTime", "UpdateUserID" },
                values: new object[,]
                {
                    { 1, "100", new DateTime(2021, 2, 20, 11, 3, 22, 487, DateTimeKind.Local).AddTicks(9449), 0, false, "Admin", new DateTime(2021, 2, 20, 11, 3, 22, 488, DateTimeKind.Local).AddTicks(636), 0 },
                    { 2, "100101", new DateTime(2021, 2, 20, 11, 3, 22, 488, DateTimeKind.Local).AddTicks(1627), 0, false, "UserPermissionManagement", new DateTime(2021, 2, 20, 11, 3, 22, 488, DateTimeKind.Local).AddTicks(1633), 0 },
                    { 3, "100102", new DateTime(2021, 2, 20, 11, 3, 22, 488, DateTimeKind.Local).AddTicks(1639), 0, false, "UserManagemenet", new DateTime(2021, 2, 20, 11, 3, 22, 488, DateTimeKind.Local).AddTicks(1641), 0 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "ID", "CreateTime", "CreateUserID", "IsDeleted", "Name", "NickName", "Password", "UpdateTime", "UpdateUserID" },
                values: new object[] { 1, new DateTime(2021, 2, 20, 11, 3, 22, 490, DateTimeKind.Local).AddTicks(3720), 0, false, "admin", "Admin", "DB69FC039DCBD2962CB4D28F5891AAE1", new DateTime(2021, 2, 20, 11, 3, 22, 490, DateTimeKind.Local).AddTicks(3736), 0 });

            migrationBuilder.InsertData(
                table: "UserPermission",
                columns: new[] { "ID", "AppID", "CreateTime", "CreateUserID", "IsDeleted", "PermissionCode", "UpdateTime", "UpdateUserID", "UserID" },
                values: new object[] { 1, 0, new DateTime(2021, 2, 20, 11, 3, 22, 490, DateTimeKind.Local).AddTicks(8956), 0, false, "100", new DateTime(2021, 2, 20, 11, 3, 22, 490, DateTimeKind.Local).AddTicks(8969), 0, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_ConfigAppEnvironment_ConfigAppID_IsDeleted",
                table: "ConfigAppEnvironment",
                columns: new[] { "ConfigAppID", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_ConfigItem_ConfigAppID_ConfigEnvironmentID_IsDeleted",
                table: "ConfigItem",
                columns: new[] { "ConfigAppID", "ConfigEnvironmentID", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_ConfigItemSniffer_ConfigAppID_Namespace_IsDeleted",
                table: "ConfigItemSniffer",
                columns: new[] { "ConfigAppID", "Namespace", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_User_Name_IsDeleted",
                table: "User",
                columns: new[] { "Name", "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_UserPermission_UserID_IsDeleted",
                table: "UserPermission",
                columns: new[] { "UserID", "IsDeleted" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfigApp");

            migrationBuilder.DropTable(
                name: "ConfigAppEnvironment");

            migrationBuilder.DropTable(
                name: "ConfigEnvironment");

            migrationBuilder.DropTable(
                name: "ConfigItem");

            migrationBuilder.DropTable(
                name: "ConfigItemSniffer");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserPermission");
        }
    }
}

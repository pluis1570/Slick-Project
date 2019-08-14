using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Slick.Database.Migrations
{
    public partial class AddedAccountsAndEmployees2thTry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompanyName = table.Column<string>(nullable: false),
                    VatNumber = table.Column<string>(nullable: true),
                    TelephoneNumber = table.Column<string>(nullable: true),
                    AddressId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    MiddleName = table.Column<string>(nullable: true),
                    AddressId = table.Column<Guid>(nullable: true),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountConsultants",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ConsultantId = table.Column<Guid>(nullable: false),
                    AccountId = table.Column<Guid>(nullable: false),
                    Startdate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    BuyPrice = table.Column<decimal>(nullable: false),
                    SellPrice = table.Column<decimal>(nullable: false),
                    EmployeeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountConsultants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountConsultants_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountConsultants_Consultants_ConsultantId",
                        column: x => x.ConsultantId,
                        principalTable: "Consultants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountConsultants_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountManagers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EmployeeId = table.Column<Guid>(nullable: false),
                    AccountId = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountManagers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountManagers_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountManagers_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountConsultants_AccountId",
                table: "AccountConsultants",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountConsultants_ConsultantId",
                table: "AccountConsultants",
                column: "ConsultantId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountConsultants_EmployeeId",
                table: "AccountConsultants",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountManagers_AccountId",
                table: "AccountManagers",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountManagers_EmployeeId",
                table: "AccountManagers",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AddressId",
                table: "Accounts",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AddressId",
                table: "Employees",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountConsultants");

            migrationBuilder.DropTable(
                name: "AccountManagers");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}

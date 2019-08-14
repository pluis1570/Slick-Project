using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Slick.Database.Migrations
{
    public partial class AddedAccountsAndEmployees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Street = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContractTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecialisationLevel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialisationLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Consultants",
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
                    WorkEmail = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consultants_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Specialisations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    SpecialisationLevelId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialisations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specialisations_SpecialisationLevel_SpecialisationLevelId",
                        column: x => x.SpecialisationLevelId,
                        principalTable: "SpecialisationLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ContractTypeId = table.Column<Guid>(nullable: false),
                    ConsultantId = table.Column<Guid>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    SignedDate = table.Column<DateTime>(nullable: true),
                    Salary = table.Column<decimal>(nullable: true),
                    DocumentUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_Consultants_ConsultantId",
                        column: x => x.ConsultantId,
                        principalTable: "Consultants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_ContractTypes_ContractTypeId",
                        column: x => x.ContractTypeId,
                        principalTable: "ContractTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConsultantSpecialisations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ConsultantId = table.Column<Guid>(nullable: false),
                    SpecialisationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultantSpecialisations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsultantSpecialisations_Consultants_ConsultantId",
                        column: x => x.ConsultantId,
                        principalTable: "Consultants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsultantSpecialisations_Specialisations_SpecialisationId",
                        column: x => x.SpecialisationId,
                        principalTable: "Specialisations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consultants_AddressId",
                table: "Consultants",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultantSpecialisations_ConsultantId",
                table: "ConsultantSpecialisations",
                column: "ConsultantId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultantSpecialisations_SpecialisationId",
                table: "ConsultantSpecialisations",
                column: "SpecialisationId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ConsultantId",
                table: "Contracts",
                column: "ConsultantId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ContractTypeId",
                table: "Contracts",
                column: "ContractTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Specialisations_SpecialisationLevelId",
                table: "Specialisations",
                column: "SpecialisationLevelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsultantSpecialisations");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Specialisations");

            migrationBuilder.DropTable(
                name: "Consultants");

            migrationBuilder.DropTable(
                name: "ContractTypes");

            migrationBuilder.DropTable(
                name: "SpecialisationLevel");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}

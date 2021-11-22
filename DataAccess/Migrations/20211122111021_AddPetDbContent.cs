using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddPetDbContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pet_Child_ChildId",
                table: "Pet");

            migrationBuilder.DropForeignKey(
                name: "FK_Pet_Family_FamilyStreetName_FamilyHouseNumber",
                table: "Pet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pet",
                table: "Pet");

            migrationBuilder.RenameTable(
                name: "Pet",
                newName: "Pets");

            migrationBuilder.RenameIndex(
                name: "IX_Pet_FamilyStreetName_FamilyHouseNumber",
                table: "Pets",
                newName: "IX_Pets_FamilyStreetName_FamilyHouseNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Pet_ChildId",
                table: "Pets",
                newName: "IX_Pets_ChildId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pets",
                table: "Pets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Child_ChildId",
                table: "Pets",
                column: "ChildId",
                principalTable: "Child",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Family_FamilyStreetName_FamilyHouseNumber",
                table: "Pets",
                columns: new[] { "FamilyStreetName", "FamilyHouseNumber" },
                principalTable: "Family",
                principalColumns: new[] { "StreetName", "HouseNumber" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Child_ChildId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Family_FamilyStreetName_FamilyHouseNumber",
                table: "Pets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pets",
                table: "Pets");

            migrationBuilder.RenameTable(
                name: "Pets",
                newName: "Pet");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_FamilyStreetName_FamilyHouseNumber",
                table: "Pet",
                newName: "IX_Pet_FamilyStreetName_FamilyHouseNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_ChildId",
                table: "Pet",
                newName: "IX_Pet_ChildId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pet",
                table: "Pet",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pet_Child_ChildId",
                table: "Pet",
                column: "ChildId",
                principalTable: "Child",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pet_Family_FamilyStreetName_FamilyHouseNumber",
                table: "Pet",
                columns: new[] { "FamilyStreetName", "FamilyHouseNumber" },
                principalTable: "Family",
                principalColumns: new[] { "StreetName", "HouseNumber" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}

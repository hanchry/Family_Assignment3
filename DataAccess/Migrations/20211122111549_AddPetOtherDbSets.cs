using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddPetOtherDbSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adult_Family_FamilyStreetName_FamilyHouseNumber",
                table: "Adult");

            migrationBuilder.DropForeignKey(
                name: "FK_Adult_Job_JobTittleJobTitle",
                table: "Adult");

            migrationBuilder.DropForeignKey(
                name: "FK_Child_Family_FamilyStreetName_FamilyHouseNumber",
                table: "Child");

            migrationBuilder.DropForeignKey(
                name: "FK_Interest_Child_ChildId",
                table: "Interest");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Child_ChildId",
                table: "Pets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Job",
                table: "Job");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Child",
                table: "Child");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Adult",
                table: "Adult");

            migrationBuilder.RenameTable(
                name: "Job",
                newName: "Jobs");

            migrationBuilder.RenameTable(
                name: "Child",
                newName: "Children");

            migrationBuilder.RenameTable(
                name: "Adult",
                newName: "Adults");

            migrationBuilder.RenameIndex(
                name: "IX_Child_FamilyStreetName_FamilyHouseNumber",
                table: "Children",
                newName: "IX_Children_FamilyStreetName_FamilyHouseNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Adult_JobTittleJobTitle",
                table: "Adults",
                newName: "IX_Adults_JobTittleJobTitle");

            migrationBuilder.RenameIndex(
                name: "IX_Adult_FamilyStreetName_FamilyHouseNumber",
                table: "Adults",
                newName: "IX_Adults_FamilyStreetName_FamilyHouseNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs",
                column: "JobTitle");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Children",
                table: "Children",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adults",
                table: "Adults",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Adults_Family_FamilyStreetName_FamilyHouseNumber",
                table: "Adults",
                columns: new[] { "FamilyStreetName", "FamilyHouseNumber" },
                principalTable: "Family",
                principalColumns: new[] { "StreetName", "HouseNumber" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Adults_Jobs_JobTittleJobTitle",
                table: "Adults",
                column: "JobTittleJobTitle",
                principalTable: "Jobs",
                principalColumn: "JobTitle",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Children_Family_FamilyStreetName_FamilyHouseNumber",
                table: "Children",
                columns: new[] { "FamilyStreetName", "FamilyHouseNumber" },
                principalTable: "Family",
                principalColumns: new[] { "StreetName", "HouseNumber" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Interest_Children_ChildId",
                table: "Interest",
                column: "ChildId",
                principalTable: "Children",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Children_ChildId",
                table: "Pets",
                column: "ChildId",
                principalTable: "Children",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adults_Family_FamilyStreetName_FamilyHouseNumber",
                table: "Adults");

            migrationBuilder.DropForeignKey(
                name: "FK_Adults_Jobs_JobTittleJobTitle",
                table: "Adults");

            migrationBuilder.DropForeignKey(
                name: "FK_Children_Family_FamilyStreetName_FamilyHouseNumber",
                table: "Children");

            migrationBuilder.DropForeignKey(
                name: "FK_Interest_Children_ChildId",
                table: "Interest");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Children_ChildId",
                table: "Pets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Children",
                table: "Children");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Adults",
                table: "Adults");

            migrationBuilder.RenameTable(
                name: "Jobs",
                newName: "Job");

            migrationBuilder.RenameTable(
                name: "Children",
                newName: "Child");

            migrationBuilder.RenameTable(
                name: "Adults",
                newName: "Adult");

            migrationBuilder.RenameIndex(
                name: "IX_Children_FamilyStreetName_FamilyHouseNumber",
                table: "Child",
                newName: "IX_Child_FamilyStreetName_FamilyHouseNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Adults_JobTittleJobTitle",
                table: "Adult",
                newName: "IX_Adult_JobTittleJobTitle");

            migrationBuilder.RenameIndex(
                name: "IX_Adults_FamilyStreetName_FamilyHouseNumber",
                table: "Adult",
                newName: "IX_Adult_FamilyStreetName_FamilyHouseNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Job",
                table: "Job",
                column: "JobTitle");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Child",
                table: "Child",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adult",
                table: "Adult",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Adult_Family_FamilyStreetName_FamilyHouseNumber",
                table: "Adult",
                columns: new[] { "FamilyStreetName", "FamilyHouseNumber" },
                principalTable: "Family",
                principalColumns: new[] { "StreetName", "HouseNumber" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Adult_Job_JobTittleJobTitle",
                table: "Adult",
                column: "JobTittleJobTitle",
                principalTable: "Job",
                principalColumn: "JobTitle",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Child_Family_FamilyStreetName_FamilyHouseNumber",
                table: "Child",
                columns: new[] { "FamilyStreetName", "FamilyHouseNumber" },
                principalTable: "Family",
                principalColumns: new[] { "StreetName", "HouseNumber" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Interest_Child_ChildId",
                table: "Interest",
                column: "ChildId",
                principalTable: "Child",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Child_ChildId",
                table: "Pets",
                column: "ChildId",
                principalTable: "Child",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

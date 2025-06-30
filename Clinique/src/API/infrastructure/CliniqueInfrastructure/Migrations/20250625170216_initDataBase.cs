using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CliniqueInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Maladies",
                columns: new[] { "Id", "Pathologie" },
                values: new object[,]
                {
                    { 1, "scarlatine" },
                    { 2, "Varicelle" },
                    { 3, "Tuberculose" },
                    { 4, "Covid" },
                    { 5, "Grippe" },
                    { 6, "Rhume" },
                    { 7, "Oreillon" }
                });

            migrationBuilder.InsertData(
                table: "Medecin",
                columns: new[] { "Id", "Adresse", "Age", "Nom", "Prenom" },
                values: new object[,]
                {
                    { 1, "", 0, "Medecin1", "" },
                    { 2, "", 0, "Medecin2", "" }
                });

            migrationBuilder.InsertData(
                table: "Soins",
                columns: new[] { "Id", "Durees", "TypeSoin", "prix" },
                values: new object[,]
                {
                    { 1, 1, "soin1", 50m },
                    { 2, 2, "soin2", 100m },
                    { 3, 3, "soin3", 150m },
                    { 4, 5, "soin4", 200m }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Adresse", "Age", "MaladieId", "MedecinId", "Nom", "Prenom" },
                values: new object[,]
                {
                    { 1, "", 0, 1, 1, "Patient1", "" },
                    { 2, "", 0, 1, 1, "Patient2", "" },
                    { 3, "", 0, 2, 1, "Patient3", "" },
                    { 4, "", 0, 3, 1, "Patient4", "" },
                    { 5, "", 0, 4, 1, "Patient5", "" },
                    { 6, "", 0, 4, 1, "Patient6", "" },
                    { 7, "", 0, 5, 2, "Patient7", "" },
                    { 8, "", 0, 6, 2, "Patient8", "" },
                    { 9, "", 0, 7, 2, "Patient9", "" },
                    { 10, "", 0, 7, 2, "Patient10", "" }
                });

            migrationBuilder.InsertData(
                table: "Traitements",
                columns: new[] { "MaladieId", "SoinId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 3, 1 },
                    { 6, 1 },
                    { 1, 2 },
                    { 4, 2 },
                    { 7, 2 },
                    { 2, 3 },
                    { 3, 3 },
                    { 5, 3 },
                    { 3, 4 },
                    { 4, 4 },
                    { 5, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Traitements",
                keyColumns: new[] { "MaladieId", "SoinId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Traitements",
                keyColumns: new[] { "MaladieId", "SoinId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "Traitements",
                keyColumns: new[] { "MaladieId", "SoinId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "Traitements",
                keyColumns: new[] { "MaladieId", "SoinId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Traitements",
                keyColumns: new[] { "MaladieId", "SoinId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "Traitements",
                keyColumns: new[] { "MaladieId", "SoinId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "Traitements",
                keyColumns: new[] { "MaladieId", "SoinId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "Traitements",
                keyColumns: new[] { "MaladieId", "SoinId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Traitements",
                keyColumns: new[] { "MaladieId", "SoinId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "Traitements",
                keyColumns: new[] { "MaladieId", "SoinId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "Traitements",
                keyColumns: new[] { "MaladieId", "SoinId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "Traitements",
                keyColumns: new[] { "MaladieId", "SoinId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "Maladies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Maladies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Maladies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Maladies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Maladies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Maladies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Maladies",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Medecin",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Medecin",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Soins",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Soins",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Soins",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Soins",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}

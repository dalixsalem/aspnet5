using Microsoft.EntityFrameworkCore.Migrations;

namespace fristapp.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Rating",
                table: "hotels",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "ShortName" },
                values: new object[] { 1, "france", "fr" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "ShortName" },
                values: new object[] { 2, "alegriya", "al0" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "ShortName" },
                values: new object[] { 3, "italiya", "it" });

            migrationBuilder.InsertData(
                table: "hotels",
                columns: new[] { "Id", "Adress", "Name", "Rating", "countryid" },
                values: new object[] { 4, "benzert", "yallapalce", 2.0, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_hotels_countryid",
                table: "hotels",
                column: "countryid");

            migrationBuilder.AddForeignKey(
                name: "FK_hotels_Countries_countryid",
                table: "hotels",
                column: "countryid",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_hotels_Countries_countryid",
                table: "hotels");

            migrationBuilder.DropIndex(
                name: "IX_hotels_countryid",
                table: "hotels");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "hotels",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Rating",
                table: "hotels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}

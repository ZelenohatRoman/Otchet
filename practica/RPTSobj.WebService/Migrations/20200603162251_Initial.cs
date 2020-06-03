using Microsoft.EntityFrameworkCore.Migrations;

namespace RPTSobj.WebService.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RPTSobjs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    MetroStation = table.Column<string>(nullable: true),
                    MetroLine = table.Column<string>(nullable: true),
                    WebSite = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RPTSobjs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "RPTSobjs",
                columns: new[] { "Id", "Address", "MetroLine", "MetroStation", "Name", "WebSite" },
                values: new object[] { 1L, "Ленинградский проспект, дом 36, строение 21 ", "Долгушев Анатолий Петрович", "генеральный директор", "УЧРЕЖДЕНИЕ «МОСКОВСКИЙ ФИЗКУЛЬТУРНО-СПОРТИВНЫЙ КЛУБ «ЮНЫЙ ДИНАМОВЕЦ»", "63809221" });

            migrationBuilder.InsertData(
                table: "RPTSobjs",
                columns: new[] { "Id", "Address", "MetroLine", "MetroStation", "Name", "WebSite" },
                values: new object[] { 2L, "Краснобогатырская улица, дом 44, корпус 1", "Чаплеевский Роман Павлович", "президент", "РЕГИОНАЛЬНАЯ ОБЩЕСТВЕННАЯ ОРГАНИЗАЦИЯ «ФЕДЕРАЦИЯ СКЕЙТБОРДИНГА»", "63809222" });

            migrationBuilder.InsertData(
                table: "RPTSobjs",
                columns: new[] { "Id", "Address", "MetroLine", "MetroStation", "Name", "WebSite" },
                values: new object[] { 3L, "Фурманный переулок, дом 10, строение 1", "Папсуев Матвей Александрович", "генеральный директор", "Автономная некоммерческая организация «Ассоциация «Здоровая нация»", "63809223" });

            migrationBuilder.InsertData(
                table: "RPTSobjs",
                columns: new[] { "Id", "Address", "MetroLine", "MetroStation", "Name", "WebSite" },
                values: new object[] { 4L, "Новинский бульвар, дом 18, корпус 1", "Сиваков Олег Петрович", "исполнительный директор", "АВТОНОМНАЯ НЕКОММЕРЧЕСКАЯ ОРГАНИЗАЦИЯ ПО ПРОВЕДЕНИЮ СПОРТИВНЫХ И МАССОВЫХ МЕРОПРИЯТИЙ «ВЫДВИЖЕНИЕ»", "63809224 " });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RPTSobjs");
        }
    }
}

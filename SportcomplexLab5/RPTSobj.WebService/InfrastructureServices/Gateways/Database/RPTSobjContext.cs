using Microsoft.EntityFrameworkCore;
using RPTSobj.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPTSobj.InfrastructureServices.Gateways.Database
{
    public class RPTSobjContext : DbContext
    {
        public DbSet<rptsobj> RPTSobjs { get; set; }

        public RPTSobjContext(DbContextOptions options)
            : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            FillTestData(modelBuilder);
        }
        private void FillTestData(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<rptsobj>().HasData(
                new
                {
                    Id = 1L,
                    Name = "УЧРЕЖДЕНИЕ «МОСКОВСКИЙ ФИЗКУЛЬТУРНО-СПОРТИВНЫЙ КЛУБ «ЮНЫЙ ДИНАМОВЕЦ»",
                    Address = "Ленинградский проспект, дом 36, строение 21 ",
                    MetroStation = "генеральный директор",
                    MetroLine = "Долгушев Анатолий Петрович",
                    WebSite = "63809221",
                },
                new
                {
                    Id = 2L,
                    Name = "РЕГИОНАЛЬНАЯ ОБЩЕСТВЕННАЯ ОРГАНИЗАЦИЯ «ФЕДЕРАЦИЯ СКЕЙТБОРДИНГА»",
                    Address = "Краснобогатырская улица, дом 44, корпус 1",
                    MetroStation = "президент",
                    MetroLine = "Чаплеевский Роман Павлович",
                    WebSite = "63809222",

                },
                new
                {
                    Id = 3L,
                    Name = "Автономная некоммерческая организация «Ассоциация «Здоровая нация»",
                    Address = "Фурманный переулок, дом 10, строение 1",
                    MetroStation = "генеральный директор",
                    MetroLine = "Папсуев Матвей Александрович",
                    WebSite = "63809223",

                },
                new
                {
                    Id = 4L,
                    Name = "АВТОНОМНАЯ НЕКОММЕРЧЕСКАЯ ОРГАНИЗАЦИЯ ПО ПРОВЕДЕНИЮ СПОРТИВНЫХ И МАССОВЫХ МЕРОПРИЯТИЙ «ВЫДВИЖЕНИЕ»",
                    Address = "Новинский бульвар, дом 18, корпус 1",
                    MetroStation = "исполнительный директор",
                    MetroLine = "Сиваков Олег Петрович",
                    WebSite = "63809224 ",

                }
               
            );
        }
    }
}

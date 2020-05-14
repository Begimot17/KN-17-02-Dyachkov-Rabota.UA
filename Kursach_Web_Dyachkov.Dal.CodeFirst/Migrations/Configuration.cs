namespace Kursach_Web_Dyachkov.Dal.CodeFirst.Migrations
{
    using Kursach_Web_Dyachkov.Dal.CodeFirst.Entities;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Kursach_Web_Dyachkov.Dal.CodeFirst.RabotaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RabotaContext db)
        {
            
            var categories = new List<Category> {
                new Category {Name="Программирование" },
                new Category { Name = "Автобизнес" },
                new Category { Name = "Торговля" },
                new Category {Name="Охрана" },
                new Category {Name="Недвижимость" },
                new Category {Name="Образование" },
                new Category {Name="Спорт" },
                new Category {Name="Другое" }};

            db.Categories.AddRange(categories);

            var profession = new List<Profession> {
                new Profession {Name="Сварщик" },
                new Profession { Name = "Водитель" },
                new Profession { Name = "Продавец" },
                new Profession {Name="Программист" },
                new Profession {Name="Бизнесмен" },
                new Profession {Name="Уборщик" },
                new Profession {Name="Учитель" },
                new Profession {Name="Другое" }};
            db.Professions.AddRange(profession);

            var regions = new List<Region> {
                new Region {Name="Киев" },
                new Region { Name = "Харьков" },
                new Region { Name = "Кременчуг" },
                new Region {Name="Полтава" },
                new Region {Name="Донецк" },
                new Region {Name="Днепр" },
                new Region {Name="Одесса" },
                new Region {Name="Львов" }};

            db.Regions.AddRange(regions);
            db.SaveChanges();

            var users = new List<User>
            {
                new User
                {
                    Id=1,
                    Surname="Иванов",
                    Name="Иван",
                    Email="Ivanov@gmail.com",
                    Age=21,
                    NumberPhone="+788005553535",
                    Summary="Создал отдел продаж с «0». Впоследствии отдел (5 человек) под моим руководством регулярно выполнял план по привлечению новых клиентов и продажам Привел в компанию 7 ключевых клиентов (совокупно до 50% заказов) Разработал и внедрил в компании технологию продаж технически сложного оборудования.",
                    ProfessionId=5,
                    RegionId=1
                },
                new User
                {
                    Id=2,
                    Surname="Петров",
                    Name="Пётр",
                    Email="Petya@gmail.com",
                    Age=34,
                    NumberPhone="+380660883412",
                    Summary="Талантливый веб-разработчик. Участвовал при написании React.js. 5 лет стаж работы в Facebook. Приехал на родину так как заработал себе состояния. Для прикола могу побыть тимлидом на каком-нибудь интересном проэкте",
                    ProfessionId=4,
                    RegionId=3
                },new User
                {
                    Id=3,
                    Surname="Gregory",
                    Name="Christopher",
                    Email="Gregory@gmail.com",
                    Age=24,
                    NumberPhone="+380959595959",
                    Summary="I am Chrisopher Gregory.It`s all",
                    ProfessionId=1,
                    RegionId=2
                },
            };
            db.Users.AddRange(users);
            db.SaveChanges();

            var announs = new List<Announcement>
            {
                new Announcement
                {
                    Id=1,
                    Name="Требуется учитель физкультуры",
                    Price=7000,
                    Description="Нужен молодой, без вредных привычек учитель физкультуры умеющий ладить с детьми",
                    UserId=1,
                    CategoryId=7
                },
                new Announcement
                {
                    Id=1,
                    Name="Требуется дворник",
                    Price=2000,
                    Description="Старый дворник прошёл курсы по английскому и уехал работать дворником в Атланту. Выручайте во дворе уже месяц никто не убирал",
                    UserId=2,
                    CategoryId=6
                },
                new Announcement
                {
                    Id=1,
                    Name="Ничего не нужно просто зарегался на этом крутом сайте",
                    Price=999999,
                    Description="Топовый сайт :)",
                    UserId=3,
                    CategoryId=8
                },
            };
            db.Announcements.AddRange(announs);
            db.SaveChanges();

        }
    }
}

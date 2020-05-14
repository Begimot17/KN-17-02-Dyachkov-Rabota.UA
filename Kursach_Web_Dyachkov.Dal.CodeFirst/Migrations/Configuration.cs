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
                new Category {Name="����������������" },
                new Category { Name = "����������" },
                new Category { Name = "��������" },
                new Category {Name="������" },
                new Category {Name="������������" },
                new Category {Name="�����������" },
                new Category {Name="�����" },
                new Category {Name="������" }};

            db.Categories.AddRange(categories);

            var profession = new List<Profession> {
                new Profession {Name="�������" },
                new Profession { Name = "��������" },
                new Profession { Name = "��������" },
                new Profession {Name="�����������" },
                new Profession {Name="���������" },
                new Profession {Name="�������" },
                new Profession {Name="�������" },
                new Profession {Name="������" }};
            db.Professions.AddRange(profession);

            var regions = new List<Region> {
                new Region {Name="����" },
                new Region { Name = "�������" },
                new Region { Name = "���������" },
                new Region {Name="�������" },
                new Region {Name="������" },
                new Region {Name="�����" },
                new Region {Name="������" },
                new Region {Name="�����" }};

            db.Regions.AddRange(regions);
            db.SaveChanges();

            var users = new List<User>
            {
                new User
                {
                    Id=1,
                    Surname="������",
                    Name="����",
                    Email="Ivanov@gmail.com",
                    Age=21,
                    NumberPhone="+788005553535",
                    Summary="������ ����� ������ � �0�. ������������ ����� (5 �������) ��� ���� ������������ ��������� �������� ���� �� ����������� ����� �������� � �������� ������ � �������� 7 �������� �������� (��������� �� 50% �������) ���������� � ������� � �������� ���������� ������ ���������� �������� ������������.",
                    ProfessionId=5,
                    RegionId=1
                },
                new User
                {
                    Id=2,
                    Surname="������",
                    Name="ϸ��",
                    Email="Petya@gmail.com",
                    Age=34,
                    NumberPhone="+380660883412",
                    Summary="����������� ���-�����������. ���������� ��� ��������� React.js. 5 ��� ���� ������ � Facebook. ������� �� ������ ��� ��� ��������� ���� ���������. ��� ������� ���� ������ �������� �� �����-������ ���������� �������",
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
                    Name="��������� ������� �����������",
                    Price=7000,
                    Description="����� �������, ��� ������� �������� ������� ����������� ������� ������ � ������",
                    UserId=1,
                    CategoryId=7
                },
                new Announcement
                {
                    Id=1,
                    Name="��������� �������",
                    Price=2000,
                    Description="������ ������� ������ ����� �� ����������� � ����� �������� ��������� � �������. ��������� �� ����� ��� ����� ����� �� ������",
                    UserId=2,
                    CategoryId=6
                },
                new Announcement
                {
                    Id=1,
                    Name="������ �� ����� ������ ��������� �� ���� ������ �����",
                    Price=999999,
                    Description="������� ���� :)",
                    UserId=3,
                    CategoryId=8
                },
            };
            db.Announcements.AddRange(announs);
            db.SaveChanges();

        }
    }
}

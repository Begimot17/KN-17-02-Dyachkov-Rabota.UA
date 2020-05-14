namespace Kursach_Web_Dyachkov.Dal.CodeFirst.Entities
{
    public class User : BaseEntity
    {
        public string Surname { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }

        public string Email { get; set; }

        public string NumberPhone { get; set; }

        public string Password { get; set; }
        public string Summary { get; set; }
        public int ProfessionId { get; set; }
        public int RegionId { get; set; }

        public virtual Profession Profession { get; set; }
        public virtual Region Region { get; set; }

    }
}

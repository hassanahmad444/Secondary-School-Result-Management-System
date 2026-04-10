namespace Secondary_School_Result_Management_System.Models.Entities
{
    public class Student
    {
        public Guid Id { get; set; }
        public Guid SchoolClassId { get; set; }
        public string PersonalId { get; set; }


        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = null!;
        public string FullName => $"{FirstName} {MiddleName} {LastName}";


        public SchoolClass SchoolClass { get; set; } = null!;
        public ICollection<Result> Results { get; set; } = new List<Result>();
        

    }
}


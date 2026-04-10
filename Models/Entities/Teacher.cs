namespace Secondary_School_Result_Management_System.Models.Entities
{
    public class Teacher
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string UserId { get; set; } = null!;  // Links to AspNetUsers
        public ICollection<TeacherSubjectClass> Assignments { get; set; } = new List<TeacherSubjectClass>();
    }
}

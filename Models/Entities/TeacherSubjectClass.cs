namespace Secondary_School_Result_Management_System.Models.Entities
{
    public class TeacherSubjectClass
    {
        public Guid Id { get; set; }
        public Guid TeacherId { get; set; }
        public Guid SubjectId { get; set; }
        public Guid SchoolClassId { get; set; }
        public Teacher Teacher { get; set; } = null!;
        public Subject Subject { get; set; } = null!;
        public SchoolClass SchoolClass { get; set; } = null!;
    }
}

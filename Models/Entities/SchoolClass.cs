namespace Secondary_School_Result_Management_System.Models.Entities
{
    public class SchoolClass
    {
        public Guid Id { get; set; }


        public string Name { get; set; } = null!;


        public ICollection<Student> Students { get; set; } = new List<Student>();

    }
}

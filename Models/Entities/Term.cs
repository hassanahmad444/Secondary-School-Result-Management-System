namespace Secondary_School_Result_Management_System.Models.Entities
{
    public class Term
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;  // "First Term", "Second Term"
        public string AcademicSession { get; set; } = null!;  // "2024/2025"
        public ICollection<Result> Results { get; set; } = new List<Result>();
    }
}

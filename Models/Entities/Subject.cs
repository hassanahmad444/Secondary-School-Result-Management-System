namespace Secondary_School_Result_Management_System.Models.Entities
{
    public class Subject
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;


        public ICollection<Result> Results { get; set; } = new List<Result>();
    }
}

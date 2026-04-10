namespace Secondary_School_Result_Management_System.Models.Entities
{
    public class Result
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid SubjectId { get; set; }
        public int CAScore { get; set; }        // Continuous Assessment
        public int ExamScore { get; set; }      // Exam score
        public int TotalScore => CAScore + ExamScore;  // Computed
        public string Grade => TotalScore switch  // Computed
        {
            >= 70 => "A",
            >= 60 => "B",
            >= 50 => "C",
            >= 40 => "D",
            _ => "F"
        };
        public Guid TermId { get; set; }
        public Student Student { get; set; } = null!;
        public Subject Subject { get; set; } = null!;
        public Term Term { get; set; } = null!;
    }
}

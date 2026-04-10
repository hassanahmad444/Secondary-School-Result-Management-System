namespace Secondary_School_Result_Management_System.ViewModel
{
    public class SubjectScoreViewModel
    {
        public required string SubjectName { get; set; }
        public required int CAScore { get; set; }
        public required int ExamScore { get; set; }
        public int TotalScore => CAScore + ExamScore;
        public required string Grade { get; set; }
    }
}
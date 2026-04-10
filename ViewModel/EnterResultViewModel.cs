using System.ComponentModel.DataAnnotations;

namespace Secondary_School_Result_Management_System.ViewModel
{
    public class EnterResultViewModel
    {
        [Required]
        public Guid StudentId { get; set; }

        [Required]
        public Guid SubjectId { get; set; }

        [Required]
        public Guid TermId { get; set; }

        [Required]
        [Range(0, 40, ErrorMessage = "CA Score must be between 0 and 40")]
        public int CAScore { get; set; }

        [Required]
        [Range(0, 60, ErrorMessage = "Exam Score must be between 0 and 60")]
        public int ExamScore { get; set; }
    }
}
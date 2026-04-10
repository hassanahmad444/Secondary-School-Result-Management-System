using System.Collections.Generic;
using System.Linq;

namespace Secondary_School_Result_Management_System.ViewModel
{
    public class StudentResultViewModel
    {
        public required string FullName { get; set; }
        public required string ClassName { get; set; }
        public List<SubjectScoreViewModel> Subjects { get; set; }
            = new List<SubjectScoreViewModel>();

        public int TotalScore => Subjects.Sum(s => s.TotalScore);

        public double Average => Subjects.Count == 0
            ? 0
            : (double)TotalScore / Subjects.Count;
    }
}
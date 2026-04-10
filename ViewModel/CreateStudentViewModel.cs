using System.ComponentModel.DataAnnotations;

namespace Secondary_School_Result_Management_System.ViewModel
{
    public class CreateStudentViewModel
    {
        [Required]
        public string FirstName { get; set; } = null!;

       
        public string? MiddleName { get; set; }

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        public string PersonalId { get; set; } = null!;

        [Required]
        public Guid SchoolClassId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
namespace Secondary_School_Result_Management_System.ViewModel
{
    public class CreateTermViewModel
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string AcademicSession { get; set; } = null!;
    }
}

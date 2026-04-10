using System.ComponentModel.DataAnnotations;

namespace Secondary_School_Result_Management_System.ViewModel
{
    public class CreateSchoolClassViewModel
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
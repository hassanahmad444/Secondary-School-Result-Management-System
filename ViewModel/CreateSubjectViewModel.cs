using System.ComponentModel.DataAnnotations;
namespace Secondary_School_Result_Management_System.ViewModel
{
    public class CreateSubjectViewModel
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}

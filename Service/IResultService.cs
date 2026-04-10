using Secondary_School_Result_Management_System.Models.Entities;
using Secondary_School_Result_Management_System.ViewModel;

namespace Secondary_School_Result_Management_System.Services
{
    public interface IResultService
    {
        Task<List<Result>> GetResultsByTermAsync(Guid termId);
        Task<List<Result>> GetStudentResultsAsync(Guid studentId, Guid termId);
        Task EnterResultAsync(EnterResultViewModel model);
        Task<bool> ResultExistsAsync(Guid studentId, Guid subjectId, Guid termId);
        Task<List<Student>> GetAllStudentsAsync();
        Task<List<Subject>> GetAllSubjectsAsync();
        Task<List<Term>> GetAllTermsAsync();
    }
}


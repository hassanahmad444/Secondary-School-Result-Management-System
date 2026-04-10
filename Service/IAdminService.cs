using Secondary_School_Result_Management_System.Models.Entities;
using Secondary_School_Result_Management_System.ViewModel;

namespace Secondary_School_Result_Management_System.Services
{
    public interface IAdminService
    {
             Task<List<Student>> GetAllStudentsAsync();
            Task<List<Teacher>> GetAllTeachersAsync();
            Task<List<Subject>> GetAllSubjectsAsync();
            Task<List<Term>> GetAllTermsAsync();
             Task CreateStudentAsync(CreateStudentViewModel model);
            Task CreateTeacherAsync(CreateTeacherViewModel model);
            Task CreateSubjectAsync(CreateSubjectViewModel subject);
            Task CreateTermAsync(CreateTermViewModel model);
            Task UpdateStudentAsync(Guid id, CreateStudentViewModel model);
            Task UpdateTeacherAsync(Guid id, CreateTeacherViewModel model);
            Task UpdateSubjectAsync(Guid id, CreateSubjectViewModel model);
            Task UpdateTermAsync(Guid id, CreateTermViewModel model);
        Task DeleteStudentAsync(Guid id);
            Task DeleteTeacherAsync(Guid id);
            Task DeleteSubjectAsync(Guid id);
        Task DeleteTermAsync(Guid id);

        Task CreateSchoolClassAsync(CreateSchoolClassViewModel model);
            Task<List<SchoolClass>> GetAllSchoolClassesAsync();
        Task UpdateSchoolClassAsync(Guid id, CreateSchoolClassViewModel model);
            Task DeleteSchoolClassAsync(Guid id);


    }
}

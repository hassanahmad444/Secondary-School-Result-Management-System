using Microsoft.EntityFrameworkCore;
using Secondary_School_Result_Management_System.Data;
using Secondary_School_Result_Management_System.Models.Entities;
using Secondary_School_Result_Management_System.ViewModel;

namespace Secondary_School_Result_Management_System.Services
{
    public class ResultService : IResultService
    {
        private readonly SchoolResultDbContext _context;

        public ResultService(SchoolResultDbContext context)
        {
            _context = context;
        }

        public async Task<List<Result>> GetResultsByTermAsync(Guid termId)
        {
            return await _context.Results
                .Include(r => r.Student)
                .Include(r => r.Subject)
                .Include(r => r.Term)
                .Where(r => r.TermId == termId)
                .ToListAsync();
        }

        public async Task<List<Result>> GetStudentResultsAsync(Guid studentId, Guid termId)
        {
            return await _context.Results
                .Include(r => r.Subject)
                .Include(r => r.Term)
                .Where(r => r.StudentId == studentId && r.TermId == termId)
                .ToListAsync();
        }

        public async Task EnterResultAsync(EnterResultViewModel model)
        {
            // Prevent duplicate result entry
            var exists = await ResultExistsAsync(model.StudentId, model.SubjectId, model.TermId);
            if (exists)
                throw new InvalidOperationException("Result already exists for this student, subject and term.");

            var result = new Result
            {
                Id = Guid.NewGuid(),
                StudentId = model.StudentId,
                SubjectId = model.SubjectId,
                TermId = model.TermId,
                CAScore = model.CAScore,
                ExamScore = model.ExamScore
            };

            await _context.Results.AddAsync(result);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ResultExistsAsync(Guid studentId, Guid subjectId, Guid termId)
        {
            return await _context.Results
                .AnyAsync(r => r.StudentId == studentId
                            && r.SubjectId == subjectId
                            && r.TermId == termId);
        }
        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }
        public async Task<List<Subject>> GetAllSubjectsAsync()
        {
            return await _context.Subjects.ToListAsync();
        }
        public async Task<List<Term>> GetAllTermsAsync()
        {
            return await _context.Terms.ToListAsync();
        }
    }
}
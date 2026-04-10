using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Secondary_School_Result_Management_System.Data;
using Secondary_School_Result_Management_System.Models.Entities;
using Secondary_School_Result_Management_System.ViewModel;

namespace Secondary_School_Result_Management_System.Services
{
    public class AdminService : IAdminService
    {
        private readonly SchoolResultDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public AdminService(SchoolResultDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        
        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _context.Students
                .Include(s => s.SchoolClass)
                .ToListAsync();
        }

        public async Task<List<Teacher>> GetAllTeachersAsync()
        {
            return await _context.Teachers.ToListAsync();
        }
        public async Task<List<Subject>> GetAllSubjectsAsync()
        {
            return await _context.Subjects.ToListAsync();
        }
        public async Task<List<Term>> GetAllTermsAsync()
        {
            return await _context.Terms.ToListAsync();
        }
        public async Task CreateStudentAsync(CreateStudentViewModel model)
        {
            var student = new Student
            {
                Id = Guid.NewGuid(),
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                PersonalId = model.PersonalId,
                SchoolClassId = model.SchoolClassId
            };
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task CreateTeacherAsync(CreateTeacherViewModel model)
        {
            
            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new InvalidOperationException($"Failed to create teacher account: {errors}");
            }

            
            await _userManager.AddToRoleAsync(user,"Teacher");

           
            var teacher = new Teacher
            {
                Id = Guid.NewGuid(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserId = user.Id
            };

            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
        }

        public async Task CreateSchoolClassAsync(CreateSchoolClassViewModel model)
        {
            var schoolClass = new SchoolClass
                {
                Id = Guid.NewGuid(),
                Name = model.Name
            };
            await _context.SchoolClasses.AddAsync(schoolClass);
            await _context.SaveChangesAsync();
        }

        public async Task CreateSubjectAsync(CreateSubjectViewModel subject)
        {
            var newSubject = new Subject
            {
                Id = Guid.NewGuid(),
                Name = subject.Name
            };
            await _context.Subjects.AddAsync(newSubject);
            await _context.SaveChangesAsync();
        }

        public async Task CreateTermAsync(CreateTermViewModel model)
        {
            var term = new Term
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                AcademicSession = model.AcademicSession
            };
            await _context.Terms.AddAsync(term);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStudentAsync(Guid id, CreateStudentViewModel model)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                throw new InvalidOperationException("Student not found.");

            student.FirstName = model.FirstName;
            student.MiddleName = model.MiddleName;
            student.LastName = model.LastName;
            student.PersonalId = model.PersonalId;
            student.SchoolClassId = model.SchoolClassId;

            await _context.SaveChangesAsync();

        }

        public async Task UpdateTeacherAsync(Guid id, CreateTeacherViewModel model)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
                throw new InvalidOperationException("Teacher not found.");

            teacher.LastName = model.LastName;
            teacher.FirstName = model.FirstName;

            await _context.SaveChangesAsync();
        }

        public async Task UpdateSubjectAsync(Guid id, CreateSubjectViewModel model)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null)
                throw new InvalidOperationException("Subject not found.");

            subject.Name = model.Name;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTermAsync(Guid id, CreateTermViewModel model)
        {
            var term = await _context.Terms.FindAsync(id);
            if (term == null)
                throw new InvalidOperationException("Term not found.");

            term.Name = model.Name;
            term.AcademicSession = model.AcademicSession;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(Guid id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                throw new InvalidOperationException("Student not found.");

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTeacherAsync(Guid id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
                throw new InvalidOperationException("Teacher not found.");

            
            var user = await _userManager.FindByIdAsync(teacher.UserId);
            if (user != null)
                await _userManager.DeleteAsync(user);

            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSubjectAsync(Guid id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null)
                throw new InvalidOperationException("Subject not found.");

            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTermAsync(Guid id)
        {
            var term = await _context.Terms.FindAsync(id);
            if (term == null)
                throw new InvalidOperationException("Term not found.");

            _context.Terms.Remove(term);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SchoolClass>> GetAllSchoolClassesAsync()
        {
            return await _context.SchoolClasses.ToListAsync();
        }

  

        public async Task UpdateSchoolClassAsync(Guid id, CreateSchoolClassViewModel model)
        {
            var schoolClass = await _context.SchoolClasses.FindAsync(id);
            if (schoolClass == null)
                throw new InvalidOperationException("School class not found.");

            schoolClass.Name = model.Name;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSchoolClassAsync(Guid id)
        {
            var schoolClass = await _context.SchoolClasses.FindAsync(id);
            if (schoolClass == null)
                throw new InvalidOperationException("School class not found.");

            _context.SchoolClasses.Remove(schoolClass);
            await _context.SaveChangesAsync();
        }
    }
}
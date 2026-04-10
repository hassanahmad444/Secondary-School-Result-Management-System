using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Secondary_School_Result_Management_System.Services;
using Secondary_School_Result_Management_System.ViewModel;

namespace Secondary_School_Result_Management_System.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        // DASHBOARD
        public async Task<IActionResult> Index()
        {
            ViewBag.StudentCount = (await _adminService.GetAllStudentsAsync()).Count;
            ViewBag.TeacherCount = (await _adminService.GetAllTeachersAsync()).Count;
            ViewBag.SubjectCount = (await _adminService.GetAllSubjectsAsync()).Count;
            ViewBag.ClassCount = (await _adminService.GetAllSchoolClassesAsync()).Count;
            return View("Dashboard");
        }

        // STUDENTS
        public async Task<IActionResult> Students()
        {
            var students = await _adminService.GetAllStudentsAsync();
            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> CreateStudent()
        {
            ViewBag.Classes = await _adminService.GetAllSchoolClassesAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStudent(CreateStudentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Classes = await _adminService.GetAllSchoolClassesAsync();
                return View(model);
            }
            await _adminService.CreateStudentAsync(model);
            TempData["Success"] = "Student created successfully.";
            return RedirectToAction(nameof(Students));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            await _adminService.DeleteStudentAsync(id);
            TempData["Success"] = "Student deleted successfully.";
            return RedirectToAction(nameof(Students));
        }

        // TEACHERS
        public async Task<IActionResult> Teachers()
        {
            var teachers = await _adminService.GetAllTeachersAsync();
            return View(teachers);
        }

        [HttpGet]
        public IActionResult CreateTeacher()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTeacher(CreateTeacherViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                await _adminService.CreateTeacherAsync(model);
                TempData["Success"] = "Teacher created successfully.";
                return RedirectToAction(nameof(Teachers));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTeacher(Guid id)
        {
            await _adminService.DeleteTeacherAsync(id);
            TempData["Success"] = "Teacher deleted successfully.";
            return RedirectToAction(nameof(Teachers));
        }

        // SUBJECTS
        public async Task<IActionResult> Subjects()
        {
            var subjects = await _adminService.GetAllSubjectsAsync();
            return View(subjects);
        }

        [HttpGet]
        public IActionResult CreateSubject()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSubject(CreateSubjectViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _adminService.CreateSubjectAsync(model);
            TempData["Success"] = "Subject created successfully.";
            return RedirectToAction(nameof(Subjects));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteSubject(Guid id)
        {
            await _adminService.DeleteSubjectAsync(id);
            TempData["Success"] = "Subject deleted.";
            return RedirectToAction(nameof(Subjects));
        }

        // CLASSES
        public async Task<IActionResult> Classes()
        {
            var classes = await _adminService.GetAllSchoolClassesAsync();
            return View(classes);
        }

        [HttpGet]
        public IActionResult CreateClass()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateClass(CreateSchoolClassViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _adminService.CreateSchoolClassAsync(model);
            TempData["Success"] = "Class created successfully.";
            return RedirectToAction(nameof(Classes));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteClass(Guid id)
        {
            await _adminService.DeleteSchoolClassAsync(id);
            TempData["Success"] = "Class deleted.";
            return RedirectToAction(nameof(Classes));
        }

        // TERMS
        public async Task<IActionResult> Terms()
        {
            var terms = await _adminService.GetAllTermsAsync();
            return View(terms);
        }

        [HttpGet]
        public IActionResult CreateTerm()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTerm(CreateTermViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _adminService.CreateTermAsync(model);
            TempData["Success"] = "Term created successfully.";
            return RedirectToAction(nameof(Terms));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTerm(Guid id)
        {
            await _adminService.DeleteTermAsync(id);
            TempData["Success"] = "Term deleted.";
            return RedirectToAction(nameof(Terms));
        }
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Secondary_School_Result_Management_System.Services;
using Secondary_School_Result_Management_System.ViewModel;

namespace Secondary_School_Result_Management_System.Controllers
{
    [Authorize(Roles = "Admin,Teacher")]
    public class ResultController : Controller
    {
        private readonly IResultService _resultService;

        public ResultController(IResultService resultService)
        {
            _resultService = resultService;
        }

        public async Task<IActionResult> Index(Guid termId)
        {
            if (termId == Guid.Empty)
                return View(new List<Models.Entities.Result>());

            var results = await _resultService.GetResultsByTermAsync(termId);
            return View(results);
        }

        [HttpGet]
        public async Task<IActionResult> Enter()
        {
            ViewBag.Students = await _resultService.GetAllStudentsAsync();
            ViewBag.Subjects = await _resultService.GetAllSubjectsAsync();
            ViewBag.Terms = await _resultService.GetAllTermsAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Enter(EnterResultViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Students = await _resultService.GetAllStudentsAsync();
                ViewBag.Subjects = await _resultService.GetAllSubjectsAsync();
                ViewBag.Terms = await _resultService.GetAllTermsAsync();
                return View(model);
            }

            try
            {
                await _resultService.EnterResultAsync(model);
                TempData["Success"] = "Result entered successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                ViewBag.Students = await _resultService.GetAllStudentsAsync();
                ViewBag.Subjects = await _resultService.GetAllSubjectsAsync();
                ViewBag.Terms = await _resultService.GetAllTermsAsync();
                return View(model);
            }
        }
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentsRM.Models.Results;
using StudentsRM.Models.Role;
using StudentsRM.Service.Interface;

namespace StudentsRM.Controllers
{
    [Authorize]
    public class ResultController : Controller
    {
        private readonly IResultService _resultService;
        private readonly ICourseService _courseService;

        public ResultController(IResultService resultService, ICourseService courseService)
        {
            _resultService =  resultService;
            _courseService = courseService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Lecturer")]
        public IActionResult Create()
        {
            return View();
        }
         
        [HttpPost]
        public IActionResult Create(AddResultViewModel request, string studentId)
        {
            var response = _resultService.Create(request, studentId);
            if (response.Status == false)
            {
                ViewData["Message"] = response.Message;
                return View();
            }

            ViewData["Message"] = response.Message;
            return RedirectToAction("Index", "Home");
        }

        public IActionResult CheckResult()
        {
            var response = _resultService.CheckStudentResult();
            if(response.Status == false)
            {
                ViewData["Message"] = response.Message;
                return View();
            }

            ViewData["Message"] = response.Message;
            ViewData["Status"] = response.Status;
            return View(response.Data);
        }
    }
}
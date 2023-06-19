using AspNetCoreHero.ToastNotification.Abstractions;
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
        private readonly INotyfService _notyf;

        public ResultController(IResultService resultService, ICourseService courseService, INotyfService notyf)
        {
            _resultService =  resultService;
            _courseService = courseService;
            _notyf = notyf;
        }
        public IActionResult Index()
        {
            return View();
        }

        // [Authorize(Roles = "Lecturer")]
        // public IActionResult Create()
        // {
        //     return View();
        // }
         
        // [HttpPost]
        // public IActionResult Create(AddResultViewModel request, string studentId)
        // {
        //     var response = _resultService.Create(request, studentId);
        //     if (response.Status == false)
        //     {
        //         _notyf.Success(response.Message);
        //         return View();
        //     }

        //     _notyf.Success(response.Message);
        //     return RedirectToAction("Index", "Home");
        // }

        [Authorize(Roles = "Lecturer")]
        public IActionResult Create()
        {
            return View();
        }
         
        [HttpPost]
        public IActionResult Create(AddResultViewModel request)
        {
            var response = _resultService.Create(request);
            if (response.Status == false)
            {
                _notyf.Success(response.Message);
                return View();
            }

            _notyf.Success(response.Message);
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Student")]
        public IActionResult CheckResult()
        {
            var response = _resultService.CheckStudentResult();
            if(response.Status == false)
            {
                _notyf.Error(response.Message);
                return View();
            }
             _notyf.Success(response.Message);   
            return View(response.Data);
        }
    }
}
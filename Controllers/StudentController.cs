using StudentsRM.Service.Interface;
using StudentsRM.Models.Students;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace StudentsRM.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;
        private readonly INotyfService _notyf;

        public StudentController(IStudentService studentService, ICourseService courseService, INotyfService notyf)
        {
            _studentService = studentService;
            _courseService = courseService;
            _notyf = notyf;
        }
        
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var response = _studentService.GetAll();
            // ViewData["Message"] = response.Message;
            // ViewData["Status"] = response.Status;
            if (response.Status is false)
            {
                _notyf.Error(response.Message);
                return View();
            }

            _notyf.Success(response.Message);
            return View(response.Data);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewBag.Courses = _courseService.SelectCourses();
            ViewData["Message"] = "";
            ViewData["Status"] = false;

            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateStudentModel request)
        {
            var response = _studentService.Create(request);
            if (response.Status is false)
            {
                _notyf.Error(response.Message);
                return View();
            }

            _notyf.Success(response.Message);
            return RedirectToAction("Index");
        }

        public IActionResult GetStudent(string id)
        {
            var response = _studentService.GetStudent(id);
            ViewData["Message"] = response.Message;
            ViewData["Status"] = response.Status;
            return View(response.Data);
        }
        
        // [Authorize(Roles = "Lecturer")]
        public IActionResult GetLecturerStudents()
        {
            var response = _studentService.GetAllLecturerStudents();
            ViewData["Message"] = response.Message;
            ViewData["Status"] = response.Status;
            return View(response.Data);
        }
    }
}
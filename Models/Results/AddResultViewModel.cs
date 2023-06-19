using StudentsRM.Models.Students;

namespace StudentsRM.Models.Results
{
    public class AddResultViewModel
    {
        public string StudentId { get; set; }
        public List<StudentViewModel> Students { get; set; }
        public int Score { get; set; }
        public string SemesterId { get; set; }
        public string CourseId { get; set; }
    }
}
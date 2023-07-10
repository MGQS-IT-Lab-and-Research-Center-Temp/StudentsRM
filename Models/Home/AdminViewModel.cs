using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsRM.Models.Home
{
    public class AdminViewModel : BaseResponseModel
    {
        public int TotalStudent { get; set; }
        public int TotalCourses { get; set; }
        public int TotalLecturers { get; set; }
        public string CurrentSemester { get; set; }
    }
}
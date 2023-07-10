using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsRM.Models.Home
{
    public class HomeResponseModel : BaseResponseModel
    {
        public AdminViewModel Data { get; set; }    
    }
}
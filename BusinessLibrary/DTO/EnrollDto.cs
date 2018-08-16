using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLibrary.DTO
{
   
    public class EnrollDto
    {
        public int Id{ get; set; }
        public string DeptCode { get; set; }
        public string CourseCode { get; set; }
        public string FullName { get; set; }
        public string StatusText { get; set;}

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLibrary.DTO
{
  public  class CourseDto
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public string DeptCode{ get; set; }
    }
}

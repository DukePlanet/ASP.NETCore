using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models
{

     

    public partial class Enroll
    {
     


        public int Id { get; set; }
        public int DeptId { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public byte Status { get; set; }
    }
}

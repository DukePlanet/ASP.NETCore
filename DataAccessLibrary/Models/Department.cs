using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models
{
    public partial class Department
    {
        public Department()
        {
            Course = new HashSet<Course>();
            Student = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string DeptName { get; set; }
        public string DeptCode { get; set; }

        public ICollection<Course> Course { get; set; }
        public ICollection<Student> Student { get; set; }
    }
}

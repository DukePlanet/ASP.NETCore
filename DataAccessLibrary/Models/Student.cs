using System;
using System.Collections.Generic;

namespace DataAccessLibrary.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        public string RegNo { get; set; }
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public int DeptId { get; set; }

        public Department Dept { get; set; }
    }
}

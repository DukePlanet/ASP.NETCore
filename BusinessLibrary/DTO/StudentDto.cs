using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLibrary.DTO
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string RegNo { get; set; }
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public int DeptCode{ get; set; }
    }
}

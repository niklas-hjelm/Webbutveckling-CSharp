using System;
using System.Collections.Generic;

namespace DatabaseFirstDemo.Models
{
    public  class Course
    {
        public Course()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Points { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}

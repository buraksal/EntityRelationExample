using System;
using System.Collections.Generic;
using System.Text;

namespace EntityRelation.Shared.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Teacher Advisor { get; set; }
        public List<Course> Courses { get; set; }

    }
}

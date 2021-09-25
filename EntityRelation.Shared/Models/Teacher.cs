using System;
using System.Collections.Generic;
using System.Text;

namespace EntityRelation.Shared.Models
{
    public class Teacher
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; }
        public List<Course> Courses { get; set; }

    }
}

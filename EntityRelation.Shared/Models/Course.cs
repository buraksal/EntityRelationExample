using System;
using System.Collections.Generic;
using System.Text;

namespace EntityRelation.Shared.Models
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Student> Students { get; set; }
    }
}

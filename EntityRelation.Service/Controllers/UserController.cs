using EntityRelation.Data.Repositories.Interfaces;
using EntityRelation.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityRelation.Service.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IStudentRepository studentRepository;
        private readonly ITeacherRepository teacherRepository;
        private readonly ICourseRepository courseRepository;

        public UserController(ICourseRepository courseRepository, ITeacherRepository teacherRepository, IStudentRepository studentRepository, IUnitOfWork unitOfWork)
        {
            this.courseRepository = courseRepository;
            this.teacherRepository = teacherRepository;
            this.studentRepository = studentRepository;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("getStudentList")]
        public IActionResult GetStudents()
        {
            return Ok(this.studentRepository.GetAll());
        }

        [HttpGet]
        [Route("getTeacherList")]
        public IActionResult GetTeachers()
        {
            return Ok(this.teacherRepository.GetAll());
        }

        [HttpGet]
        [Route("getCourseList")]
        public IActionResult GetCourses()
        {
            return Ok(this.courseRepository.GetAll());
        }

        [HttpPost]
        [Route("fillDatabase")]
        public IActionResult FillDatabase()
        {
            Student student1 = new Student
            {
                Id = Guid.NewGuid(),
                Name = "Burak Sal",
                Advisor = new Teacher(),
                Courses = new List<Course>()
            };
            Student student2 = new Student
            {
                Id = Guid.NewGuid(),
                Name = "Ahmet Ayse",
                Advisor = new Teacher(),
                Courses = new List<Course>()
            };
            Student student3 = new Student
            {
                Id = Guid.NewGuid(),
                Name = "Ali Veli",
                Advisor = new Teacher(),
                Courses = new List<Course>()
            };
            Teacher teacher1 = new Teacher
            {
                Id = Guid.NewGuid(),
                Name = "Baris Yener",
                Students = new List<Student>(),
                Courses = new List<Course>()
            };
            Teacher teacher2 = new Teacher
            {
                Id = Guid.NewGuid(),
                Name = "Bora Senyurt",
                Students = new List<Student>(),
                Courses = new List<Course>()
            };
            Course course1 = new Course
            {
                Id = Guid.NewGuid(),
                Name = "SENG 101",
                Teachers = new List<Teacher>(),
                Students = new List<Student>()
            };
            Course course2 = new Course
            {
                Id = Guid.NewGuid(),
                Name = "SENG 102",
                Teachers = new List<Teacher>(),
                Students = new List<Student>()
            };
            Course course3 = new Course
            {
                Id = Guid.NewGuid(),
                Name = "SENG 201",
                Teachers = new List<Teacher>(),
                Students = new List<Student>()
            };
            Course course4 = new Course
            {
                Id = Guid.NewGuid(),
                Name = "SENG 202",
                Teachers = new List<Teacher>(),
                Students = new List<Student>()
            };
            student1.Advisor = teacher1;
            student2.Advisor = teacher1;
            student3.Advisor = teacher2;

            teacher1.Students.Add(student1);
            teacher1.Students.Add(student2);
            teacher2.Students.Add(student3);

            student1.Courses.Add(course1);
            student1.Courses.Add(course3);
            student2.Courses.Add(course1);
            student2.Courses.Add(course2);
            student2.Courses.Add(course3);
            student2.Courses.Add(course4);
            student3.Courses.Add(course2);
            student3.Courses.Add(course4);

            course1.Students.Add(student1);
            course1.Students.Add(student2);
            course2.Students.Add(student2);
            course2.Students.Add(student3);
            course3.Students.Add(student1);
            course3.Students.Add(student2);
            course4.Students.Add(student2);
            course4.Students.Add(student3);

            course1.Teachers.Add(teacher1);
            course1.Teachers.Add(teacher2);
            course2.Teachers.Add(teacher1);
            course3.Teachers.Add(teacher2);
            course4.Teachers.Add(teacher1);
            course4.Teachers.Add(teacher2);

            teacher1.Courses.Add(course1);
            teacher1.Courses.Add(course2);
            teacher1.Courses.Add(course4);
            teacher2.Courses.Add(course1);
            teacher2.Courses.Add(course3);
            teacher2.Courses.Add(course4);

            studentRepository.Insert(student1);
            studentRepository.Insert(student2);
            studentRepository.Insert(student3);

            teacherRepository.Insert(teacher1);
            teacherRepository.Insert(teacher2);

            courseRepository.Insert(course1);
            courseRepository.Insert(course2);
            courseRepository.Insert(course3);
            courseRepository.Insert(course4);

            unitOfWork.Save();

            return Ok("Added Successfully");
        }
    }
}

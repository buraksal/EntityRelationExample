using EntityRelation.Data.Repositories.Interfaces;
using EntityRelation.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityRelation.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly RelationsDbContext context;

        public StudentRepository(RelationsDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Student> GetAll()
        {
            var studentList = this.context.Students.Include(t => t.Advisor).Include(c => c.Courses).AsQueryable();
            return (IQueryable<Student>)studentList;
        }

        public Student GetByID(object id)
        {
            return context.Set<Student>().Find(id);
        }

        public void Insert(Student student)
        {
            this.context.Students.Add(student);
        }

        public void Delete(Student student)
        {
            this.context.Students.Remove(student);
        }

        public void Update(Student entityToUpdate)
        {
            context.Set<Student>().Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}

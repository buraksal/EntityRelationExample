using EntityRelation.Data.Repositories.Interfaces;
using EntityRelation.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityRelation.Data.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly RelationsDbContext context;

        public TeacherRepository(RelationsDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Teacher> GetAll()
        {
            var teacherList = this.context.Teachers.Include(s => s.Students).Include(c => c.Courses).AsQueryable();
            return (IQueryable<Teacher>)teacherList;
        }

        public Teacher GetByID(object id)
        {
            return context.Set<Teacher>().Find(id);
        }

        public void Insert(Teacher student)
        {
            this.context.Teachers.Add(student);
        }

        public void Delete(Teacher student)
        {
            this.context.Teachers.Remove(student);
        }

        public void Update(Teacher entityToUpdate)
        {
            context.Set<Teacher>().Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}

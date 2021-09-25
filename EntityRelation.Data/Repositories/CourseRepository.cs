using EntityRelation.Data.Repositories.Interfaces;
using EntityRelation.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityRelation.Data.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly RelationsDbContext context;

        public CourseRepository(RelationsDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Course> GetAll()
        {
            var courseList = this.context.Courses.Include(s => s.Students).Include(t => t.Teachers).AsQueryable();
            return (IQueryable<Course>)courseList;
        }

        public Course GetByID(object id)
        {
            return context.Set<Course>().Find(id);
        }

        public void Insert(Course course)
        {
            this.context.Courses.Add(course);
        }

        public void Delete(Course course)
        {
            this.context.Courses.Remove(course);
        }

        public void Update(Course entityToUpdate)
        {
            context.Set<Course>().Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}

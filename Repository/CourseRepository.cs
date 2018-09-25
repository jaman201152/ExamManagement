using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseContext;
using Models;

namespace Repository
{
  public  class CourseRepository
    {

      OnlineExamDb db = new OnlineExamDb();


      public bool Add(Course course)
      {
          db.Courses.Add(course);
          return db.SaveChanges() > 0;
      }


      public List<Organization> GetAll()
      {
          List<Organization> organizations = db.Organizations
                                            .Where(c => c.IsDeleted == false)
                                            .OrderByDescending(c => c.Id)
                                            .ToList();
          return organizations;
      }


      public IList<Course> CourseDetails()
      {
          List<Course> courses = db.Courses
                                  .Where(c => c.IsDeleted == false)
                                  .OrderByDescending(c => c.Id)
                                  .ToList();

          return courses;
      }




      public List<Course> GetCoursesLastFive()
      {
          List<Course> courses = db.Courses
                              .Where(c => c.IsDeleted == false)
                              .Take(5)
                              .OrderByDescending(c => c.Id)
                              .ToList();

          return courses;

      }

      public Course GetById(int id)
      {
          Course course = db.Courses.Find(id);
          return course;
      }


      public bool Update(Course course)
      {

          db.Courses.Attach(course);
          db.Entry(course).State = EntityState.Modified;
          bool isUpdated = db.SaveChanges() > 0;
          return isUpdated;

      }


      public bool Delete(int id)
      {


          Course course = new Course();

          //organization = db.Organizations.Where(c => c.Id == id).FirstOrDefault();

          course = db.Courses.FirstOrDefault(c => c.Id == id);

          if (course != null)
          {
              course.IsDeleted = true;
              return Update(course);
          }


          return false;


      }



    }
}

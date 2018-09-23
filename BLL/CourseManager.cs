using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.ViewMoldels.Course;
using Repository;

namespace BLL
{
    public class CourseManager
    {

        CourseRepository _courseRepository = new CourseRepository();
        public bool Add(Course course)
        {

            bool isAdded = _courseRepository.Add(course);
            return isAdded;

        }

        public List<Organization> GetAll()
        {
           return _courseRepository.GetAll();
        }

        //public List<Course> CourseDetails()
        //{
        //    return _courseRepository.CourseDetails();

        //}

        public IList<Course> CourseDetails()
        {
            return _courseRepository.CourseDetails();

        }

        public List<Course> GetCourseLastFive()
        {

            return _courseRepository.GetCoursesLastFive();

        }


        public Course GetById(int id)
        {
            return _courseRepository.GetById(id);
        }

        public bool Update(Course course)
        {
            return _courseRepository.Update(course);
        }


        public bool Delete(int id)
        {
            return _courseRepository.Delete(id);
        }


    }
}

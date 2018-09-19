﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseContext;
using Models;

namespace Repository
{
   public class BatchRepository
    {

       OnlineExamDb db = new OnlineExamDb();


        public bool AddBatch(Batch batch)
        {
            db.Batches.Add(batch);
            return db.SaveChanges() > 0;
        }

        public List<Organization> GetAllOrganizations()
        {
            List<Organization> organizations = db.Organizations.ToList();
            return organizations;
        }

        public List<Course> GetAllCourse()
        {
            List<Course> courses = db.Courses.ToList();
            return courses;
        }




        public List<Course> GetCourseByOrganizationId(int id)
        {
            var dataList = db.Courses.Where(c => c.OrganizationId == id).ToList();
         
            return dataList;
        }


    }
}

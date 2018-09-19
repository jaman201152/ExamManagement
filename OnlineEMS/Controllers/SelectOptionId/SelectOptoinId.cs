using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;

namespace OnlineEMS.Controllers.SelectOptionId
{
    public class SelectOptoinId
    {

        CourseManager _courseManager = new CourseManager();
        BatchManager _batchManager = new BatchManager();

        public IEnumerable<SelectListItem> SelectOrganization()
        {

            List<Organization> organizations = _courseManager.GetAll();

          
            List<SelectListItem> selectListItems = new List<SelectListItem>();

            foreach (Organization organizationData in organizations)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = organizationData.Name;
                selectListItem.Value = organizationData.Id.ToString();

                selectListItems.Add(selectListItem);
            }

            return selectListItems;
        }

        public IEnumerable<SelectListItem> SelectCourse()
        {

            List<Course> course = _batchManager.GetAllCourses();


            List<SelectListItem> selectListItems = new List<SelectListItem>();

            foreach (Course courseData in course)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = courseData.Name;
                selectListItem.Value = courseData.Id.ToString();

                selectListItems.Add(selectListItem);
            }

            return selectListItems;
        }


    }
}
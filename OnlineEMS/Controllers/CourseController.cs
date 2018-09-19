using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BLL;
using Models;
using Models.ViewMoldels.Course;
using OnlineEMS.Controllers.SelectOptionId;

namespace OnlineEMS.Controllers
{
    public class CourseController : Controller
    {
        //
        // GET: /Course/

        CourseManager _courseManager = new CourseManager();

        SelectOptoinId _selectOptionId = new SelectOptoinId();


        [HttpGet]
        public PartialViewResult EntryForm()
        {

            CourseCreateVM course = new CourseCreateVM();
          

            course.SelectListItemsOrganization = _selectOptionId.SelectOrganization(); 

            return PartialView("~/Views/Shared/Course/_CourseManagePartialCreate.cshtml",course);

        }
      
        public string AddCourse(CourseCreateVM vm)
        {

            var course = Mapper.Map<Course>(vm);


            if (ModelState.IsValid)
            {
                bool isAdded = _courseManager.Add(course);
                if (isAdded)
                {
                    return "Successfully Saved";
                }
                else
                {
                    return "Did not saved.";
                }
            }

           

            return "Sorry! Error Occured.";

            
        }

        public ActionResult CourseDetails()
        {
            return View();
        }




  

	}
}
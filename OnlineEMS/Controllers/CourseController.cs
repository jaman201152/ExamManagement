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

            //var model = new CourseCreateVM();
            //model.Courses = _courseManager.CourseDetails();

            IList<Course> course = _courseManager.CourseDetails();

            return View(course);

        }

        public ActionResult CourseInformation()
        {

            return View();

        }

        public PartialViewResult GetCourseLastFive()
        {
            var model = new CourseCreateVM();
            model.Courses = _courseManager.GetCourseLastFive();

            return PartialView("~/Views/Shared/Course/_CoursePartialDetails.cshtml", model);
        }



        [HttpGet]
        public ActionResult EditCourse(int id)
        {

            var courseVm = new CourseCreateVM();

            if (id > 0)
            {
              var  course = _courseManager.GetById(id);

              course.SelectListItemsOrganization = _selectOptionId.SelectOrganization(); 

               courseVm  = Mapper.Map<CourseCreateVM>(course);

            }


            return View(courseVm);
        }


        [HttpPost]
        public ActionResult EditCourse(CourseCreateVM vm)
        {

            var course = Mapper.Map<Course>(vm);

            var isUpdated = _courseManager.Update(course);
        

            if (isUpdated)
            {
                ViewBag.Msg = "Success";

                return RedirectToAction("CourseDetails");
            }

            ViewBag.Msg = "Failed";
            return RedirectToAction("CourseDetails");

        }


        public ActionResult Delete(int id)
        {

            if (id > 0)
            {
                var isDeleted = _courseManager.Delete(id);
                if (isDeleted)
                {
                    ViewBag.Msg = "Success";
                    return RedirectToAction("CourseDetails");
                }
            }

            ViewBag.Msg = "Failed";
            return RedirectToAction("CourseDetails");
        }






  

	}
}
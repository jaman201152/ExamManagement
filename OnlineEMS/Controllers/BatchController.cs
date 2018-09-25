using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BLL;
using Models;
using Models.ViewMoldels.Batch;
using OnlineEMS.Controllers.SelectOptionId;

namespace OnlineEMS.Controllers
{
    public class BatchController : Controller
    {
        //
        // GET: /Batch/

        SelectOptoinId _selectOptionId = new SelectOptoinId();

        BatchManager _batchManager = new BatchManager();

    

    
        //public PartialViewResult GetBatchManageForm()
        //{

        //        BatchCreateVM batch = new BatchCreateVM();


        //    batch.selectListOrganization = _selectOptionId.SelectOrganization();

        //    return PartialView("~/Views/Shared/Batch/_BatchManagePartialCreate.cshtml", batch);
        //}


        [HttpGet]
        public ActionResult BatchCreate()
        {

            BatchCreateVM batch = new BatchCreateVM();

            batch.selectListOrganization = _selectOptionId.SelectOrganization();

            return View(batch);
        }

    
        public string BatchCreateAdd(BatchCreateVM vm)
        {

         var batch = Mapper.Map<Batch>(vm);


            if (ModelState.IsValid)
            {
                bool isAdded = _batchManager.AddBatch(batch);
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


        public JsonResult GetCourseByOrganizationId(int id)
        {
            if (id > 0)
            {
                var dataList = _batchManager.GetCourseByOrganizationId(id);
                return Json(dataList);
            }
            return null;
        }


        public ActionResult BatchDetails()
        {

            //var model = new CourseCreateVM();
            //model.Courses = _courseManager.CourseDetails();

            IList<Batch> batches = _batchManager.BatchDetails();

            return View(batches);

        }


        [HttpGet]
        public ActionResult EditBatch(int id)
        {

            var batchVm = new BatchCreateVM();

            if (id > 0)
            {
                var batch =_batchManager.GetById(id);

                batchVm = Mapper.Map<BatchCreateVM>(batch);
                 batchVm.selectListOrganization = _selectOptionId.SelectOrganization();
                batchVm.selectListCourse = _selectOptionId.SelectCourse();

            }

            return View(batchVm);
        }


        [HttpPost]
        public ActionResult EditBatch(BatchCreateVM vm)
        {

            var course = Mapper.Map<Batch>(vm);

            var isUpdated = _batchManager.Update(course);


            if (isUpdated)
            {
                ViewBag.Msg = "Success";

                return RedirectToAction("BatchDetails");
            }

            ViewBag.Msg = "Failed";
            return RedirectToAction("BatchDetails");

        }


        public ActionResult Delete(int id)
        {

            if (id > 0)
            {
                var isDeleted = _batchManager.Delete(id);
                if (isDeleted)
                {
                    ViewBag.Msg = "Success";
                    return RedirectToAction("BatchDetails");
                }
            }

            ViewBag.Msg = "Failed";
            return RedirectToAction("BatchDetails");
        }



	}
}
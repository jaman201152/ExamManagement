﻿using System;
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

        [HttpPost]
        public string BatchCreate(BatchCreateVM vm)
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



	}
}
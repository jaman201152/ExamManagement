using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BLL;
using Models;
using Models.ViewMoldels.Batch;
using Models.ViewMoldels.Participant;
using OnlineEMS.Controllers.SelectOptionId;

namespace OnlineEMS.Controllers
{
    public class ParticipantController : Controller
    {
        //
        // GET: /Participant/

        SelectOptoinId _selectOptionId = new SelectOptoinId();

        ParticipantManager _participantManager = new ParticipantManager();
        

        [HttpGet]
        public ActionResult AddParticipant()
        {

            ParticipantCreateVM participants = new ParticipantCreateVM();

            participants.selectListOrganization = _selectOptionId.SelectOrganization();

            
            return View(participants);
        }

        public string ParticipantSubmit(ParticipantCreateVM vm)
        {
            
            var participants = Mapper.Map<Participant>(vm);

           if (ModelState.IsValid)
            {
                bool isAdded = _participantManager.AddParticipant(participants);
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


        public JsonResult GetBatchByCourseId(int id)
        {
            if (id > 0)
            {
                var dataList = _participantManager.GetBatchByCourseId(id);
                return Json(dataList);
            }
            return null;
        }

        public ActionResult ParticipantDetails()
        {
            List<Participant> participants = _participantManager.GetAllParticipants();

          return  View(participants);

        }

        public ActionResult IndividualParticipantDetails(int id)
        {
            List<Participant> participant = _participantManager.GetIndividualParticipant(id);
            return View(participant);
        }


        public ActionResult EditParticipant(int id)
        {

            var participantVm = new ParticipantCreateVM();

            if (id > 0)
            {
                var participant = _participantManager.GetByID(id);

                participantVm = Mapper.Map<ParticipantCreateVM>(participant);
                participantVm.selectListOrganization = _selectOptionId.SelectOrganization();
                participantVm.selectListCourse = _selectOptionId.SelectCourse();
                participantVm.selectListBatch = _selectOptionId.SelectBatch();

            }

            return View(participantVm);

        }

        [HttpPost]
        public ActionResult EditParticipant(ParticipantCreateVM Vm)
        {

            var participant = Mapper.Map<Participant>(Vm);

            bool IsUpdated = _participantManager.Update(participant);

            if (IsUpdated)
            {
                ViewBag.Msg = "Success";

                return RedirectToAction("ParticipantDetails");
            }

            ViewBag.Msg = "Failed";
            return RedirectToAction("ParticipantDetails");

        }

        public ActionResult Delete(int id)
        {

            if (id > 0)
            {
                var isDeleted = _participantManager.Delete(id);
                if (isDeleted)
                {
                    ViewBag.Msg = "Success";
                    return RedirectToAction("ParticipantDetails");
                }
            }
         
            ViewBag.Msg = "Failed";
          return  RedirectToAction("ParticipantDetails");

        }




	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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


        public JsonResult GetBatchByCourseId(int id)
        {
            if (id > 0)
            {
                var dataList = _participantManager.GetBatchByCourseId(id);
                return Json(dataList);
            }
            return null;
        }
        




	}
}
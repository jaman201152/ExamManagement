using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

        [HttpGet]
        public ActionResult AddParticipant()
        {

            ParticipantCreateVM participants = new ParticipantCreateVM();

            participants.selectListOrganization = _selectOptionId.SelectOrganization();

            return View(participants);
        }
        




	}
}
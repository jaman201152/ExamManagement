using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Models;
using BLL;
using Models.ViewMoldels.Organization;

namespace OnlineEMS.Controllers
{
    public class OrganizationController : Controller
    {
       
        
      OrganizationManager _organizationManager = new OrganizationManager();


        public PartialViewResult GetOrganizationPartialCreate()
        {

          //  List<Organization> organization = _organizationManager.GetAll();

           // return PartialView("~/Views/Shared/Organization/_OrganizationPartialCreate.cshtml",organization);


            var model = new OrganizationCreateVM();
            model.Organizations = _organizationManager.GetAll();

            return PartialView("~/Views/Shared/Organization/_OrganizationPartialCreate.cshtml",model);

        }


        public string Add(OrganizationCreateVM orgVm)
        {

            if (ModelState.IsValid)
            {

                var organization = Mapper.Map<Organization>(orgVm);
                

                bool isAdded = _organizationManager.Add(organization);

                if (isAdded)
                {
                   return "Successfully Saved!";
                   
                }
                else
                {
                   return "Sorry Execution Failed";
                }
            }

            return "Error Occured";
        }


        public ActionResult Details(int id)
        {
            var organization = _organizationManager.GetById(id);

            return View(organization);
        }

        public PartialViewResult GetOrganizationLastFive()
        {
            var model = new OrganizationCreateVM();
            model.Organizations = _organizationManager.GetOrganizationLastFive();

            return PartialView("~/Views/Shared/Organization/_OrganizationPartialDetails.cshtml", model);
        }

        public ActionResult OrganizationDetails()
        {
            var model = new OrganizationCreateVM();
            model.Organizations = _organizationManager.GetAll();
            return View(model);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            Organization organization = new Organization();
            if (id > 0)
            {
                organization = _organizationManager.GetById(id);
            }


            return View(organization);
        }


        [HttpPost]
        public ActionResult Edit(Organization organization)
        {
        
        
            var isUpdated = _organizationManager.Update(organization);
             

            if (isUpdated)
            {
                ViewBag.Msg = "Success";
                return View(organization);
            }

            ViewBag.Msg = "Failed";
            return View(organization);

        }


        public ActionResult Delete(int id)
        {
          
            if (id > 0)
            {
                var isDeleted = _organizationManager.Delete(id);
                if (isDeleted)
                {
                    ViewBag.Msg = "Success";
                    return RedirectToAction("OrganizationDetails");
                }
            }

            ViewBag.Msg = "Failed";
            return RedirectToAction("OrganizationDetails");
        }


      

        


      



	}


}
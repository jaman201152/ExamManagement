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

        public ActionResult AllOrganizationDetails()
        {
            List<Organization> organization = _organizationManager.GetAll();
            
            //var model = Mapper.Map<OrganizationCreateVM>(organization);
           
            return View(organization);
        }

      

        


      



	}


}
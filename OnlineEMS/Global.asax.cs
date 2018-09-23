using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using Models;
using Models.ViewMoldels.Batch;
using Models.ViewMoldels.Course;
using Models.ViewMoldels.Organization;

namespace OnlineEMS
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Mapper.Initialize(conf =>
            {

                conf.CreateMap<OrganizationCreateVM,Organization>();
                conf.CreateMap<Organization,OrganizationCreateVM>();

                conf.CreateMap<CourseCreateVM, Course>();
                conf.CreateMap<Course, CourseCreateVM>();

                conf.CreateMap<BatchCreateVM, Batch>();
                conf.CreateMap<Batch, BatchCreateVM>();

            });


        }
    }
}

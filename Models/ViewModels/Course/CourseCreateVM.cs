using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Models.ViewMoldels.Course
{
   public class CourseCreateVM
    {

        public int Id { get; set; }
        [Required]
        public int OrganizationId { get; set; }

        //public Organization Organization { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        public string CourseDuration { get; set; }
        public string Credit { get; set; }
        public string OutLine { get; set; }
        public string Tags { get; set; }
        public bool IsDeleted { get; set; }
        public IEnumerable<SelectListItem> SelectListItemsOrganization { get; set; }

        public List<Models.Course> Courses { get; set; }

    }
}

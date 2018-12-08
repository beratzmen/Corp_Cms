using CMS.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.MvcUI.Areas.Admin.Models
{
    public class vmAdminNews
    {       
        [Required]
        [UIHint("tinymce_full_compressed"), AllowHtml]
        public string ContentText { get; set; }

        [UIHint("tinymce_full_compressed"), AllowHtml]
        public string ContentTextEN { get; set; }

        public News news { get; set; }
    }
}
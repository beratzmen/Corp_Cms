using CMS.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CMS.MvcUI.Areas.Admin.Models
{
    public class vmProductCreate
    {
        [UIHint("tinymce_full_compressed"), AllowHtml]
        public string Description { get; set; }

        [UIHint("tinymce_full_compressed"), AllowHtml]
        public string DescriptionEN { get; set; }

        public List<Category> category { get; set; }

    }
}
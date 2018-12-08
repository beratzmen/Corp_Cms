using CMS.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CMS.MvcUI.Areas.Admin.Models
{
    public class AdminPageMenuModelView
    {
        [UIHint("tinymce_full_compressed"), AllowHtml]
        public Pages pages { get; set; }

        public List<Menu> menu { get; set; }

        //[UIHint("tinymce_full_compressed"), AllowHtml]
        //public string ContentText { get; set; }
    }
}
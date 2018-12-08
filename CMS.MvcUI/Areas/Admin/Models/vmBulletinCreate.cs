using CMS.Entities;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CMS.MvcUI.Areas.Admin.Models
{
    public class vmBulletinCreate
    {
        
        [UIHint("tinymce_full_compressed"), AllowHtml]
        public string ContentText { get; set; }

        public Bulletin bulletin { get; set; }
    }
}
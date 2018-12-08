using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CMS.MvcUI.Areas.Admin.Models
{
    public class vmAdminContentContentUpdate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameEN { get; set; }
        public string Title { get; set; }
        public string TitleEN { get; set; }

        //[UIHint("tinymce_full_compressed"), AllowHtml]
        public string ContentText { get; set; }

        //[UIHint("tinymce_full_compressed"), AllowHtml]
        public string ContentTextEN { get; set; }
    }
}
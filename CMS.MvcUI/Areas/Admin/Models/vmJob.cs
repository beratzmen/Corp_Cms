using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CMS.MvcUI.Areas.Admin.Models
{
    public class vmJob
    {
        [UIHint("tinymce_full_compressed"), AllowHtml]
        public string Content { get; set; }

        [UIHint("tinymce_full_compressed"), AllowHtml]
        public string ContentEN { get; set; }
    }
}
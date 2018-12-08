using CMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.MvcUI.Models
{
    public class ViewModel
    {
        public Company company { get; set; }
        public List<Menu> menu { get; set; }
    }
}
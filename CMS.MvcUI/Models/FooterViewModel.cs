using CMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.MvcUI.Models
{
    public class FooterViewModel
    {
        public List<Menu> menu { get; set; }
        public Company company { get; set; }
    }
}
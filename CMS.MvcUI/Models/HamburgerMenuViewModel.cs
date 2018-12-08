using CMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.MvcUI.Models
{
    public class HamburgerMenuViewModel
    {
        public List<Slider> slider { get; set; }
        public List<Menu> menu { get; set; }
        public List<Product> product { get; set; }
    }
}
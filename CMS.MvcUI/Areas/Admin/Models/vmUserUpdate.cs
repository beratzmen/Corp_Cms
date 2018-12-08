using CMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.MvcUI.Areas.Admin.Models
{
    public class vmUserUpdate
    {
        public List<Role> role { get; set; }
        public User user { get; set; }
    }
}
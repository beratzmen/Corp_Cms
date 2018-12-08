using CMS.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.MvcUI.Models
{
    public class CategoryProductViewModel
    {
        public Product oneProduct { get; set; }
        public List<Product> product { get; set; }
        public PagedList<Product> productList { get; set; }
        public List<Category> category { get; set; }
        
    }
}
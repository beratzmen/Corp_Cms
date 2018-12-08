namespace CMS.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pages
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string NameEN { get; set; }

        [StringLength(250)]
        public string Title { get; set; }

        [StringLength(250)]
        public string TitleEN { get; set; }

        public string ContentText { get; set; }

        public string ContentTextEN { get; set; }
    }
}

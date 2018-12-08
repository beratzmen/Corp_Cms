namespace CMS.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class News
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Title { get; set; }

        [StringLength(250)]
        public string TitleEN { get; set; }

        [Required]
        public string ContentText { get; set; }

        public string ContentTextEN { get; set; }

        public DateTime Date { get; set; }

        public string Image { get; set; }
    }
}

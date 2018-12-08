namespace CMS.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bulletin")]
    public partial class Bulletin
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        public string ContentText { get; set; }

        public DateTime Date { get; set; }
    }
}

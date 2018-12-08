namespace CMS.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int Id { get; set; }

        [StringLength(150)]
        public string Name { get; set; }

        public string Description { get; set; }

        [StringLength(150)]
        public string NameEN { get; set; }

        public string DescriptionEN { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        public string Image { get; set; }

        public int? CategoryID { get; set; }

        public virtual Category Category { get; set; }
    }
}

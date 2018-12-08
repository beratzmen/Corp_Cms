namespace CMS.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Company")]
    public partial class Company
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(11)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string EMail { get; set; }

        [Required]
        [StringLength(250)]
        public string Adress { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public string Map { get; set; }

        public string FullName { get; set; }
    }
}

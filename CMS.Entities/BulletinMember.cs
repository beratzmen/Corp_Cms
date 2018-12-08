namespace CMS.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BulletinMember")]
    public partial class BulletinMember
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string EMail { get; set; }

        public DateTime Date { get; set; }

        public int? Counter { get; set; }
    }
}

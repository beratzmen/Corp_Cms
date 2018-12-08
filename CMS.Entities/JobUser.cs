namespace CMS.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JobUser")]
    public partial class JobUser
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string SurName { get; set; }

        public DateTime? Date { get; set; }

        [StringLength(11)]
        public string Phone { get; set; }

        public string CV { get; set; }

        public int? JobID { get; set; }

        public virtual Job Job { get; set; }
    }
}

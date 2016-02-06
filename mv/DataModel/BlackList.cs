namespace mv.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BlackList")]
    public partial class BlackList
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        public long ComplaintID { get; set; }

        public virtual Complaints Complaints { get; set; }
    }
}

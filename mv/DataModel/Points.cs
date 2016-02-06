namespace mv.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Points
    {
        public int ID { get; set; }

        public int Point { get; set; }

        [Required]
        [StringLength(50)]
        public string UserType { get; set; }

        public long UserID { get; set; }

        public virtual Users Users { get; set; }
    }
}

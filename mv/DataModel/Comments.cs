namespace mv.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comments
    {
        public long ID { get; set; }

        [Required]
        public string Comment { get; set; }

        public DateTime Datetime { get; set; }

        public long PostID { get; set; }

        public long UserID { get; set; }

        public virtual Posts Posts { get; set; }

        public virtual Users Users { get; set; }
    }
}

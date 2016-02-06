namespace mv.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pictures
    {
        public long ID { get; set; }

        [Required]
        public string PictureLoc { get; set; }

        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        public long PostID { get; set; }

        public virtual Posts Posts { get; set; }
    }
}

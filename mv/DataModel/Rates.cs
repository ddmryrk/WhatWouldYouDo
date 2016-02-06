namespace mv.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Rates
    {
        public int ID { get; set; }

        [Required]
        public string PictureLoc { get; set; }

        public byte StarPoint { get; set; }

        public int RateCount { get; set; }

        public long UserID { get; set; }

        public virtual Users Users { get; set; }
    }
}

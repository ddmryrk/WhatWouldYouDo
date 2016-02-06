namespace mv.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Likes
    {
        public long ID { get; set; }

        public byte Type { get; set; }

        public long PostID { get; set; }

        public virtual Posts Posts { get; set; }
    }
}

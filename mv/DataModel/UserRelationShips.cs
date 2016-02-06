namespace mv.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserRelationShips
    {
        public long ID { get; set; }

        public byte Status { get; set; }

        public long UserID1 { get; set; }

        public long UserID2 { get; set; }

        public virtual Users Users { get; set; }

        public virtual Users Users1 { get; set; }
    }
}

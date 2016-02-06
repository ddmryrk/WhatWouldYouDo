namespace mv.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RateUserRelations
    {
        public int ID { get; set; }

        public long UserID { get; set; }

        public long UserIDRated { get; set; }

        public int RateID { get; set; }

        public virtual Rates Rates { get; set; }

        public virtual Users Users { get; set; }

        public virtual Users Users1 { get; set; }
    }
}

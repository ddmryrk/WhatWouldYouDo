namespace mv.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Rates
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rates()
        {
            RateUserRelations = new HashSet<RateUserRelations>();
        }

        public int ID { get; set; }

        [Required]
        public string PictureLoc { get; set; }

        public long UserID { get; set; }

        public double StarPoint { get; set; }

        public int RateCount { get; set; }

        public DateTime DateTime { get; set; }

        public virtual Users Users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RateUserRelations> RateUserRelations { get; set; }
    }
}

namespace mv.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Complaints
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Complaints()
        {
            BlackList = new HashSet<BlackList>();
        }

        public long ID { get; set; }

        public DateTime Datetime { get; set; }

        [Required]
        [MaxLength(50)]
        public byte[] Kind { get; set; }

        public bool PostOrUser { get; set; }

        public long ToComplainID { get; set; }

        public long ComplainerID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BlackList> BlackList { get; set; }

        public virtual Users Users { get; set; }
    }
}

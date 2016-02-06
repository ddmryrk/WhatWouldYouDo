namespace mv.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Posts
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Posts()
        {
            Comments = new HashSet<Comments>();
            Likes = new HashSet<Likes>();
            Pictures = new HashSet<Pictures>();
        }

        public long ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public byte SubjectNo { get; set; }

        [Required]
        public string Context { get; set; }

        public DateTime Datetime { get; set; }

        public int ViewCount { get; set; }

        public bool Deleted { get; set; }

        public long UserID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comments> Comments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Likes> Likes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pictures> Pictures { get; set; }

        public virtual Users Users { get; set; }
    }
}

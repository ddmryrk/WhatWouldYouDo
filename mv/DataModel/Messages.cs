namespace mv.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Messages
    {
        public long ID { get; set; }

        public DateTime Datetime { get; set; }

        public bool SendOrReceive { get; set; }

        [Required]
        public string Message { get; set; }

        public int ConversationID { get; set; }

        public virtual Conversations Conversations { get; set; }
    }
}

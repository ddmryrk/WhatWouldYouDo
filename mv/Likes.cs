//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mv
{
    using System;
    using System.Collections.Generic;
    
    public partial class Likes
    {
        public long ID { get; set; }
        public byte Type { get; set; }
        public long PostID { get; set; }
    
        public virtual Posts Posts { get; set; }
    }
}
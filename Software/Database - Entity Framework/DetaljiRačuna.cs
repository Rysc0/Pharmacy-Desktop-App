//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ljekarna.Database___Entity_Framework
{
    using System;
    using System.Collections.Generic;
    
    public partial class DetaljiRačuna
    {
        public int RačunID { get; set; }
        public int LijekID { get; set; }
        public double Iznos { get; set; }
        public int Količina { get; set; }
        public int Popust { get; set; }
        public int ID { get; set; }
    
        public virtual Lijek Lijek { get; set; }
        public virtual Račun Račun { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PretplatniciDA.DATA
{
    using System;
    using System.Collections.Generic;
    
    public partial class StrucnaSprema
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StrucnaSprema()
        {
            this.Pretplatnici = new HashSet<Pretplatnici>();
        }
    
        public int StrucnaSpremaID { get; set; }
        public string Naziv { get; set; }
        public string Skracenica { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pretplatnici> Pretplatnici { get; set; }
    }
}

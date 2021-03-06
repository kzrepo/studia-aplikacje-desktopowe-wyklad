//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVVMFirma.Model.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Faktura
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Faktura()
        {
            this.PozycjaFaktury = new HashSet<PozycjaFaktury>();
        }
    
        public int IdFaktury { get; set; }
        public string Numer { get; set; }
        public Nullable<System.DateTime> DataWystawienia { get; set; }
        public Nullable<int> IdKontrahenta { get; set; }
        public Nullable<System.DateTime> TerminPlatnosci { get; set; }
        public Nullable<int> IdSposobuPlatnosci { get; set; }
        public Nullable<bool> CzyAktywny { get; set; }
    
        public virtual Kontrahent Kontrahent { get; set; }
        public virtual SposobPlatnosci SposobPlatnosci { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PozycjaFaktury> PozycjaFaktury { get; set; }
    }
}

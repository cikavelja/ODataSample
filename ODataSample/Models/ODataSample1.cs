//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ODataSample.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ODataSample1
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ODataSample1()
        {
            this.ODataSample2 = new HashSet<ODataSample2>();
        }
    
        public int ODataSample1Id { get; set; }
        public string Column1 { get; set; }
        public string Column2 { get; set; }
        public string Column3 { get; set; }
        public string Column4 { get; set; }
        public string Column5 { get; set; }
        public string Column6 { get; set; }
        public string Column7 { get; set; }
        public string Column8 { get; set; }
        public string Column9 { get; set; }
        public string Column10 { get; set; }
        public string Column11 { get; set; }
        public string Column12 { get; set; }
        public string Column13 { get; set; }
        public string Column14 { get; set; }
        public string Column15 { get; set; }
        public string Column16 { get; set; }
        public string Column17 { get; set; }
        public string Column18 { get; set; }
        public string Column19 { get; set; }
        public string Column20 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ODataSample2> ODataSample2 { get; set; }
    }
}

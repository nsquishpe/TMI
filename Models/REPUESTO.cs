//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DemoRest_vPrueba.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class REPUESTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public REPUESTO()
        {
            this.ORDENTRABAJODET = new HashSet<ORDENTRABAJODET>();
        }
    
        public int IDREPUESTO { get; set; }
        public string DESREPUESTO { get; set; }
        public double COSTREPUESTO { get; set; }
        public int STOCKREPUESTO { get; set; }
        public int IDCATEGORIA { get; set; }
    
        public virtual CATEGORIA CATEGORIA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDENTRABAJODET> ORDENTRABAJODET { get; set; }
    }
}

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
    
    public partial class CATEGORIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CATEGORIA()
        {
            this.REPUESTO = new HashSet<REPUESTO>();
        }
    
        public int IDCATEGORIA { get; set; }
        public string DESCATEGORIA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REPUESTO> REPUESTO { get; set; }
    }
}

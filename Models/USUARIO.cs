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
    
    public partial class USUARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USUARIO()
        {
            this.AUTOMOVIL = new HashSet<AUTOMOVIL>();
            this.ORDENTRABAJOENCAB = new HashSet<ORDENTRABAJOENCAB>();
        }
    
        public int IDUSU { get; set; }
        public int IDROL { get; set; }
        public string NOMBREUSU { get; set; }
        public string EMAILUSU { get; set; }
        public string CELUSU { get; set; }
        public string DIRECCIONUSU { get; set; }
        public string SESIONUSU { get; set; }
        public string CLAVEUSU { get; set; }
        public string CEDULUSU { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AUTOMOVIL> AUTOMOVIL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDENTRABAJOENCAB> ORDENTRABAJOENCAB { get; set; }
        public virtual ROL ROL { get; set; }
    }
}

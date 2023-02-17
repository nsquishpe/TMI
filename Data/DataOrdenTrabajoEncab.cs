using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoRest_vPrueba.Data
{
    public class DataOrdenTrabajoEncab
    {
        //Instancia de la BD 
        Models.TecniMecanica_vPruebaEntities2 Contexto;
        //Constructor
        public DataOrdenTrabajoEncab()
        {
            Contexto = new Models.TecniMecanica_vPruebaEntities2();
            //Framework acorde a nuestros cambios IMPORTANTE
            Contexto.Configuration.ProxyCreationEnabled = false;
        }
        //METODOS PRIVADO
        //Consultar integridad BD, claves foraneas
        private bool IdEnc_Det(int ID)
        {
            List<Models.ORDENTRABAJODET> det = new List<Models.ORDENTRABAJODET>();
            det = Contexto.ORDENTRABAJODET.Where(o => o.IDORDENCLI == ID).ToList();
            if (det.Count() != 0)
                return true; //existen detalles con dicho encab
            return false;
        }
        //METODOS
        //consultar todas los ordenes de trabajo encabezado
        public List<Models.ORDENTRABAJOENCAB> SeleccionarOrdenesTrabajoEncab()
        {
            return Contexto.ORDENTRABAJOENCAB.ToList();
        }
        //consultar Orden de trabajo encabezado por ID
        public Models.ORDENTRABAJOENCAB OrdenTrabajoEncabporID(int ID)
        {
            return Contexto.ORDENTRABAJOENCAB.Where(or_encab => or_encab.IDORDENCLI == ID).SingleOrDefault();
        }
        //insertar Orden de trabajo encabezado
        public void InsertarOrdenTrabajoEncab(Models.ORDENTRABAJOENCAB or_encab)
        {
            Contexto.ORDENTRABAJOENCAB.Add(or_encab);
            Contexto.SaveChanges();
        }
        //editar Orden de trabajo encabezado
        public bool ActualizarOrdenTrabajoEncab(Models.ORDENTRABAJOENCAB or_encab)
        {
            Models.ORDENTRABAJOENCAB or_encabtemporal = OrdenTrabajoEncabporID(or_encab.IDORDENCLI);
            if (OrdenTrabajoEncabporID(or_encab.IDORDENCLI) != null)
            {
                or_encabtemporal.IDAUTO = or_encab.IDAUTO;
                or_encabtemporal.IDESTADO = or_encab.IDESTADO;
                or_encabtemporal.IDUSU = or_encab.IDUSU;
                or_encabtemporal.FECHAORDEN = or_encab.FECHAORDEN;
                or_encabtemporal.COMENTARIOCLI = or_encab.COMENTARIOCLI;
                or_encabtemporal.INVENTARIOVEHIC = or_encab.INVENTARIOVEHIC;
                or_encabtemporal.DANIOSAUTOCLI = or_encab.DANIOSAUTOCLI;
                or_encabtemporal.KILOMAUTOCLI = or_encab.KILOMAUTOCLI;
                or_encabtemporal.FALLASAUTOCLI = or_encab.FALLASAUTOCLI;
                or_encabtemporal.TRABFINALIZADO = or_encab.TRABFINALIZADO;
                Contexto.SaveChanges();
                return true;
            }
            return false;
        }
        //eliminar Orden de trabajo encabezado
        public bool EliminarOrdenTrabajoEncab(int ID)
        {
            Models.ORDENTRABAJOENCAB or_encabtemporal = OrdenTrabajoEncabporID(ID);
            if (OrdenTrabajoEncabporID(ID) != null)
            {
                //Valido integridad claves foraneas
                if (IdEnc_Det(ID) == true)
                    return false; //No puedo eliminar encb heredados a detalles
                Contexto.ORDENTRABAJOENCAB.Remove(or_encabtemporal);
                Contexto.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
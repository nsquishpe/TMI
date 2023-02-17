using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoRest_vPrueba.Data
{
    public class DataEstadoOrden
    {
        //Instancia de la BD 
        Models.TecniMecanica_vPruebaEntities2 Contexto;
        //Constructor
        public DataEstadoOrden()
        {
            Contexto = new Models.TecniMecanica_vPruebaEntities2();
            //Framework acorde a nuestros cambios IMPORTANTE
            Contexto.Configuration.ProxyCreationEnabled = false;
        }
        //METODOS PRIVADO
        //consultar existencia de estado de orden por descripcion
        private bool OrdenPorDescrip(string des)
        {
            List<Models.ESTADOORDEN> des_est_ordenes = new List<Models.ESTADOORDEN>();
            des_est_ordenes = Contexto.ESTADOORDEN.Where(or_des => or_des.DESESTADO.ToLower() == des.ToLower()).ToList();
            if (des_est_ordenes.Count() == 1) //existe la descripcion 
                return true;
            return false;
        }
        //Consultar integridad BD, claves foraneas
        private bool EstOrden_EncOrden(int ID)
        {
            List<Models.ORDENTRABAJOENCAB> est_ordenes = new List<Models.ORDENTRABAJOENCAB>();
            est_ordenes = Contexto.ORDENTRABAJOENCAB.Where(or_des => or_des.IDESTADO== ID).ToList();
            if (est_ordenes.Count() != 0)
                return true; //existen ordenes con dicho estado
            return false;
        }
        //METODOS
        //consultar todas los estados de las ordenes 
        public List<Models.ESTADOORDEN> SeleccionarEstadosOrden()
        {
            return Contexto.ESTADOORDEN.ToList();
        }
        //consultar estado de orden por ID
        public Models.ESTADOORDEN EstadoOrdenporID(int ID)
        {
            return Contexto.ESTADOORDEN.Where(est => est.IDESTADO == ID).SingleOrDefault();
        }
        //insertar estado de orden
        public bool InsertarEstadoOrden(Models.ESTADOORDEN est)
        {
            if (OrdenPorDescrip(est.DESESTADO) == false)
            {
                Contexto.ESTADOORDEN.Add(est);
                Contexto.SaveChanges();
                return true;
            }
            return false;
        }
        //editar estado de orden
        public bool ActualizarEstadoOrden(Models.ESTADOORDEN est)
        {
            Models.ESTADOORDEN esttemporal = EstadoOrdenporID(est.IDESTADO);
            if (EstadoOrdenporID(est.IDESTADO) != null)
            {
                //Edita descripcion
                if(esttemporal.DESESTADO != est.DESESTADO)
                {
                    if (OrdenPorDescrip(est.DESESTADO) == true) //existe
                        return false;
                }
                esttemporal.DESESTADO = est.DESESTADO;
                Contexto.SaveChanges();
                return true;
            }
            return false;
        }
        //eliminar estado de orden
        public bool EliminarEstadoOrden(int ID)
        {
            Models.ESTADOORDEN esttemporal = EstadoOrdenporID(ID);
            if (EstadoOrdenporID(ID) != null)
            {
                //Valido integridad claves foraneas
                if (EstOrden_EncOrden(ID) == true)
                    return false; //No puedo eliminar estados heredados a ordenes
                Contexto.ESTADOORDEN.Remove(esttemporal);
                Contexto.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
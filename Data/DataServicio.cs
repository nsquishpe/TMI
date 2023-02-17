using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoRest_vPrueba.Data
{
    public class DataServicio
    {
        //Instancia de la BD 
        Models.TecniMecanica_vPruebaEntities2 Contexto;
        //Constructor
        public DataServicio()
        {
            Contexto = new Models.TecniMecanica_vPruebaEntities2();
            //Framework acorde a nuestros cambios IMPORTANTE
            Contexto.Configuration.ProxyCreationEnabled = false;
        }
        //METODOS PRIVADO
        //consultar existencia de servicio por descripcion
        private bool ServicioPorDescrip(string des)
        {
            List<Models.SERVICIO> des_ser = new List<Models.SERVICIO>();
            des_ser = Contexto.SERVICIO.Where(s => s.DESSERVICIO.Trim().ToLower() == des.Trim().ToLower()).ToList();
            if (des_ser.Count() == 1) //existe la descripcion 
                return true;
            return false;
        }
        //Consultar integridad BD, claves foraneas
        private bool IdSer_Ord(int ID)
        {
            List<Models.ORDENTRABAJODET> ser_or = new List<Models.ORDENTRABAJODET>();
            ser_or = Contexto.ORDENTRABAJODET.Where(s => s.IDSERVICIO == ID).ToList();
            if (ser_or.Count() != 0)
                return true; //existen servicios en ordenes
            return false;
        }
        //METODOS
        //consultar todas los servicios
        public List<Models.SERVICIO> SeleccionarServicios()
        {
            return Contexto.SERVICIO.ToList();
        }
        //consultar servicio por ID
        public Models.SERVICIO ServicioporID(int ID)
        {
            return Contexto.SERVICIO.Where(ser => ser.IDSERVICIO == ID).SingleOrDefault();
        }
        //insertar servicio
        public bool InsertarServicio(Models.SERVICIO ser)
        {
            if (ServicioPorDescrip(ser.DESSERVICIO) == false)
            {
                Contexto.SERVICIO.Add(ser);
                Contexto.SaveChanges();
                return true;
            }
            return false;
        }
        //editar servicio
        public bool ActualizarServicio(Models.SERVICIO ser)
        {
            Models.SERVICIO sertemporal = ServicioporID(ser.IDSERVICIO);
            if (ServicioporID(ser.IDSERVICIO) != null)
            {
                //Edita descripcion
                if (sertemporal.DESSERVICIO != ser.DESSERVICIO)
                {
                    if (ServicioPorDescrip(ser.DESSERVICIO) == true) //existe
                        return false;
                }
                sertemporal.DESSERVICIO = ser.DESSERVICIO;
                sertemporal.COSTSERVICIO = ser.COSTSERVICIO;
                sertemporal.TIPOSERVICIO = ser.TIPOSERVICIO;
                Contexto.SaveChanges();
                return true;
            }
            return false;
        }
        //eliminar servicio
        public bool EliminarServicio(int ID)
        {
            Models.SERVICIO roltemporal = ServicioporID(ID);
            if (ServicioporID(ID) != null)
            {
                //Valido integridad claves foraneas
                if (IdSer_Ord(ID) == true)
                    return false; //No puedo eliminar servicios heredados a ordenes
                Contexto.SERVICIO.Remove(roltemporal);
                Contexto.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
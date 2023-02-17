using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoRest_vPrueba.Logica
{
    public class LogicaServicio
    {
        //Instancia de datos
        Data.DataServicio crud_ser = new Data.DataServicio();
        //METODOS
        //consultar todas los servicios
        public List<Models.SERVICIO> SeleccionarServicios()
        {
            return crud_ser.SeleccionarServicios();
        }
        //consultar servicio por ID
        public Models.SERVICIO ServicioporID(int ID)
        {
            return crud_ser.ServicioporID(ID);
        }
        //insertar servicio
        public bool InsertarServicio(Models.SERVICIO ser)
        {
            return crud_ser.InsertarServicio(ser);
        }
        //editar servicio
        public bool ActualizarServicio(Models.SERVICIO ser)
        {
            return crud_ser.ActualizarServicio(ser);
        }
        //eliminar servicio
        public bool EliminarServicio(int ID)
        {
            return crud_ser.EliminarServicio(ID);
        }
    }
}
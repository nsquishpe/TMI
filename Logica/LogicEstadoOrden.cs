using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoRest_vPrueba.Logica
{
    public class LogicEstadoOrden
    {
        //Instancia de datos
        Data.DataEstadoOrden crud_est = new Data.DataEstadoOrden();
        //METODOS
        //consultar todas los estados de las ordenes 
        public List<Models.ESTADOORDEN> SeleccionarEstadosOrden()
        {
            return crud_est.SeleccionarEstadosOrden();
        }
        //consultar estado de orden por ID
        public Models.ESTADOORDEN EstadoOrdenporID(int ID)
        {
            return crud_est.EstadoOrdenporID(ID);
        }
        //insertar estado de orden
        public bool InsertarEstadoOrden(Models.ESTADOORDEN est)
        {
            return crud_est.InsertarEstadoOrden(est);
        }
        //editar estado de orden
        public bool ActualizarEstadoOrden(Models.ESTADOORDEN est)
        {
            return crud_est.ActualizarEstadoOrden(est);
        }
        //eliminar estado de orden
        public bool EliminarEstadoOrden(int ID)
        {
            return crud_est.EliminarEstadoOrden(ID);
        }
    }
}
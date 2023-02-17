using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoRest_vPrueba.Logica
{
    public class LogicOrdenTrabajoDet
    {
        //Instancia de datos
        Data.DataOrdenTrabajoDet crud_ord_det = new Data.DataOrdenTrabajoDet();
        //METODOS
        //consultar todas las ordenes de trabajo detalle
        public List<Models.ORDENTRABAJODET> SeleccionarOrdenesTrabajoDet()
        {
            return crud_ord_det.SeleccionarOrdenesTrabajoDet();
        }
        //consultar orden de trabajo detalle por ID
        public Models.ORDENTRABAJODET OrdenTrabajoDetporID(int ID)
        {
            return crud_ord_det.OrdenTrabajoDetporID(ID);
        }
        //insertar orden de trabajo detalle - IMPORTANTE
        public string InsertarOrdenTrabajoDet(Models.ORDENTRABAJODET or_det)
        {
            return crud_ord_det.InsertarOrdenTrabajoDet(or_det);
        }
        //editar orden de trabajo detalle
        public string ActualizarOrdenTrabajoDet(Models.ORDENTRABAJODET or_det)
        {
            return crud_ord_det.ActualizarOrdenTrabajoDet(or_det);
        }
        //eliminar orden de trabajo detalle
        public bool EliminarOrdenTrabajoDet(int ID)
        {
            return crud_ord_det.EliminarOrdenTrabajoDet(ID);
        }
    }
}
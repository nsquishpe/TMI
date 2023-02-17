using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoRest_vPrueba.Logica
{
    public class LogicOrdenTrabajoEncab
    {
        //Instancia de datos
        Data.DataOrdenTrabajoEncab crud_ord_encab = new Data.DataOrdenTrabajoEncab();
        //METODOS
        //consultar todas los ordenes de trabajo encabezado
        public List<Models.ORDENTRABAJOENCAB> SeleccionarOrdenesTrabajoEncab()
        {
            return crud_ord_encab.SeleccionarOrdenesTrabajoEncab();
        }
        //consultar Orden de trabajo encabezado por ID
        public Models.ORDENTRABAJOENCAB OrdenTrabajoEncabporID(int ID)
        {
            return crud_ord_encab.OrdenTrabajoEncabporID(ID);
        }
        //insertar Orden de trabajo encabezado
        public void InsertarOrdenTrabajoEncab(Models.ORDENTRABAJOENCAB or_encab)
        {
            crud_ord_encab.InsertarOrdenTrabajoEncab(or_encab);
        }
        //editar Orden de trabajo encabezado
        public bool ActualizarOrdenTrabajoEncab(Models.ORDENTRABAJOENCAB or_encab)
        {
            return crud_ord_encab.ActualizarOrdenTrabajoEncab(or_encab);
        }
        //eliminar Orden de trabajo encabezado
        public bool EliminarOrdenTrabajoEncab(int ID)
        {
            return crud_ord_encab.EliminarOrdenTrabajoEncab(ID);
        }
    }
}
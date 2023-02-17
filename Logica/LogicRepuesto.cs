using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoRest_vPrueba.Logica
{
    public class LogicRepuesto
    {
        //Instancia de datos
        Data.DataRepuesto crud_rep = new Data.DataRepuesto();
        //METODOS
        //consultar todas los repuestos
        public List<Models.REPUESTO> SeleccionarRepuestos()
        {
            return crud_rep.SeleccionarRepuestos();
        }
        //consultar repuesto por ID
        public Models.REPUESTO RepuestoporID(int ID)
        {
            return crud_rep.RepuestoporID(ID);
        }
        //insertar repuesto
        public bool InsertarRepuesto(Models.REPUESTO rep)
        {
           return crud_rep.InsertarRepuesto(rep);
        }
        //editar repuesto
        public bool ActualizarRepuesto(Models.REPUESTO rep)
        {
            return crud_rep.ActualizarRepuesto(rep);
        }
        //eliminar repuesto
        public bool EliminarRepuesto(int ID)
        {
            return crud_rep.EliminarRepuesto(ID);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoRest_vPrueba.Logica
{
    public class LogicAutomovil
    {
        //Instancia de datos
        Data.DataAutomovil crud_aut = new Data.DataAutomovil();
        //METODOS
        //consultar todos los automoviles
        public List<Models.AUTOMOVIL> SeleccionarAutos()
        {
            return crud_aut.SeleccionarAutos();
        }
        //consultar auto por ID
        public Models.AUTOMOVIL AutoporID(int ID)
        {
            return crud_aut.AutoporID(ID);
        }
        //insertar auto
        public bool InsertarAuto(Models.AUTOMOVIL aut)
        {
            return crud_aut.InsertarAuto(aut);
        }
        //editar auto
        public bool ActualizarAuto(Models.AUTOMOVIL aut)
        {
            return crud_aut.ActualizarAuto(aut);
        }
        //eliminar auto
        public bool EliminarAuto(int ID)
        {
            return crud_aut.EliminarAuto(ID);
        }
    }
}
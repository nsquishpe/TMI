using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoRest_vPrueba.Logica
{
    public class LogicModelo
    {
        //Instancia de datos
        Data.DataModelo crud_modelo = new Data.DataModelo();
        //METODOS
        //consultar todas los modelos
        public List<Models.MODELO> SeleccionarModelos()
        {
            return crud_modelo.SeleccionarModelos();
        }
        //consultar modelo por ID
        public Models.MODELO ModeloporID(int ID)
        {
            return crud_modelo.ModeloporID(ID);
        }
        //insertar modelo
        public bool InsertarModelo(Models.MODELO mod)
        {
           return crud_modelo.InsertarModelo(mod);
        }
        //editar modelo
        public bool ActualizarModelo(Models.MODELO mod)
        {
            return crud_modelo.ActualizarModelo(mod);
        }
        //eliminar modelo
        public bool EliminarModelo(int ID)
        {
            return crud_modelo.EliminarModelo(ID);
        }
    }
}
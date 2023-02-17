using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoRest_vPrueba.Logica
{
    public class LogicMarca
    {
        //Instancia de datos
        Data.DataMarca crud_marca = new Data.DataMarca();
        //METODOS
        //consultar todas las marcas
        public List<Models.MARCA> SeleccionarMarcas()
        {
            return crud_marca.SeleccionarMarcas();
        }
        //consultar marca por ID
        public Models.MARCA MarcaporID(int ID)
        {
            return crud_marca.MarcaporID(ID);
        }
        //insertar marca
        public bool InsertarMarca(Models.MARCA mar)
        {
            return crud_marca.InsertarMarca(mar);
        }
        //editar marca
        public bool ActualizarMarca(Models.MARCA mar)
        {
            return crud_marca.ActualizarMarca(mar);
        }
        //eliminar marca
        public bool EliminarMarca(int ID)
        {
            return crud_marca.EliminarMarca(ID);
        }
    }
}
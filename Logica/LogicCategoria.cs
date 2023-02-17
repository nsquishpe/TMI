using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoRest_vPrueba.Logica
{
    public class LogicCategoria
    {
        //Instancia de datos
        Data.DataCategoria crud_cat = new Data.DataCategoria();
        //METODOS
        //consultar todas las categorias de repuestos
        public List<Models.CATEGORIA> SeleccionarCategorias()
        {
            return crud_cat.SeleccionarCategorias();
        }
        //consultar categoria por ID
        public Models.CATEGORIA CategoriaporID(int ID)
        {
            return crud_cat.CategoriaporID(ID);
        }
        //insertar categoria
        public bool InsertarCategoria(Models.CATEGORIA cat)
        {
           return crud_cat.InsertarCategoria(cat);
        }
        //editar categoria
        public bool ActualizarCategoria(Models.CATEGORIA cat)
        {
            return crud_cat.ActualizarCategoria(cat);
        }
        //eliminar categoria
        public bool EliminarCategoria(int ID)
        {
            return crud_cat.EliminarCategoria(ID);
        }
    }
}
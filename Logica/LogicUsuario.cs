using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoRest_vPrueba.Logica
{
    public class LogicUsuario
    {
        //Instancia de datos
        Data.DataUsuario crud_us = new Data.DataUsuario();
        //METODOS
        //consultar todas los usuarios
        public List<Models.USUARIO> SeleccionarUsuarios()
        {
            return crud_us.SeleccionarUsuarios();
        }
        //consultar usuario por ID
        public Models.USUARIO UsuarioporID(int ID)
        {
            return crud_us.UsuarioporID(ID);
        }
        //insertar usuario
        public string InsertarUsuario(Models.USUARIO us)
        {
            return crud_us.InsertarUsuario(us);
        }
        //editar usuario
        public string ActualizarUsuario(Models.USUARIO us)
        {
            return crud_us.ActualizarUsuario(us);
        }
        //eliminar usuario
        public bool EliminarUsuario(int ID)
        {
            return crud_us.EliminarUsuario(ID);
        }
    }
}
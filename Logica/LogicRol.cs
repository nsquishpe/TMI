using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoRest_vPrueba.Logica
{
    public class LogicRol
    {
        //Instancia de datos
        Data.DataRol crud_rol = new Data.DataRol();
        //METODOS
        //consultar todas los roles
        public List<Models.ROL> SeleccionarRoles()
        {
            return crud_rol.SeleccionarRoles();
        }
        //consultar rol por ID
        public Models.ROL RolporID(int ID)
        {
            return crud_rol.RolporID(ID);
        }
        //insertar rol
        public bool InsertarRol(Models.ROL rol)
        {
            return crud_rol.InsertarRol(rol);
        }
        //editar rol
        public bool ActualizarRol(Models.ROL rol)
        {
            return crud_rol.ActualizarRol(rol);
        }
        //eliminar rol
        public bool EliminarRol(int ID)
        {
            return crud_rol.EliminarRol(ID);
        }
    }
}
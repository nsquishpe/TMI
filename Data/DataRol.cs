using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoRest_vPrueba.Data
{
    public class DataRol
    {
        //Instancia de la BD 
        Models.TecniMecanica_vPruebaEntities2 Contexto;
        //Constructor
        public DataRol()
        {
            Contexto = new Models.TecniMecanica_vPruebaEntities2();
            //Framework acorde a nuestros cambios IMPORTANTE
            Contexto.Configuration.ProxyCreationEnabled = false;
        }
        //METODOS PRIVADO
        //consultar existencia de rol por descripcion
        private bool RolPorDescrip(string des)
        {
            List<Models.ROL> des_roles = new List<Models.ROL>();
            des_roles = Contexto.ROL.Where(r => r.DESROL.ToLower() == des.ToLower()).ToList();
            if (des_roles.Count() == 1) //existe la descripcion 
                return true;
            return false;
        }
        //Consultar integridad BD, claves foraneas
        private bool IdRol_Usuario(int ID)
        {
            List<Models.USUARIO> rol_usu = new List<Models.USUARIO>();
            rol_usu = Contexto.USUARIO.Where(r => r.IDUSU == ID).ToList();
            if (rol_usu.Count() != 0)
                return true; //existen usuarios con dicho rol
            return false;
        }
        //METODOS
        //consultar todas los roles
        public List<Models.ROL> SeleccionarRoles()
        {
            return Contexto.ROL.ToList();
        }
        //consultar rol por ID
        public Models.ROL RolporID(int ID)
        {
            return Contexto.ROL.Where(rol => rol.IDROL == ID).SingleOrDefault();
        }
        //insertar rol
        public bool InsertarRol(Models.ROL rol)
        {
            if (RolPorDescrip(rol.DESROL) == false)
            {
                Contexto.ROL.Add(rol);
                Contexto.SaveChanges();
                return true;
            }
            return false;
        }
        //editar rol
        public bool ActualizarRol(Models.ROL rol)
        {
            Models.ROL roltemporal = RolporID(rol.IDROL);
            if (RolporID(rol.IDROL) != null)
            {
                //Edita descripcion
                if (roltemporal.DESROL != rol.DESROL)
                {
                    if (RolPorDescrip(rol.DESROL) == true) //existe
                        return false;
                }
                roltemporal.DESROL = rol.DESROL;
                Contexto.SaveChanges();
                return true;
            }
            return false;
        }
        //eliminar rol
        public bool EliminarRol(int ID)
        {
            Models.ROL roltemporal = RolporID(ID);
            if (RolporID(ID) != null)
            {
                //Valido integridad claves foraneas
                if (IdRol_Usuario(ID) == true)
                    return false; //No puedo eliminar roles heredados a usuarios
                Contexto.ROL.Remove(roltemporal);
                Contexto.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoRest_vPrueba.Data
{
    public class DataModelo
    {
        //Instancia de la BD 
        Models.TecniMecanica_vPruebaEntities2 Contexto;
        //Constructor
        public DataModelo()
        {
            Contexto = new Models.TecniMecanica_vPruebaEntities2();
            //Framework acorde a nuestros cambios IMPORTANTE
            Contexto.Configuration.ProxyCreationEnabled = false;
        }
        //METODOS PRIVADO
        //consultar existencia de marca por descripcion
        private bool ModeloPorDescrip(string des)
        {
            List<Models.MODELO> des_mod = new List<Models.MODELO>();
            des_mod = Contexto.MODELO.Where(m => m.DESMODELO.ToLower() == des.ToLower()).ToList();
            if (des_mod.Count() == 1) //existe la descripcion 
                return true;
            return false;
        }
        //Consultar integridad BD, claves foraneas
        private bool IdMod_Auto(int ID)
        {
            List<Models.AUTOMOVIL> mod_auto = new List<Models.AUTOMOVIL>();
            mod_auto = Contexto.AUTOMOVIL.Where(m => m.IDMODELO == ID).ToList();
            if (mod_auto.Count() != 0)
                return true; //modelo registrados en autos
            return false;
        }
        //METODOS
        //consultar todas los modelos
        public List<Models.MODELO> SeleccionarModelos()
        {
            return Contexto.MODELO.ToList();
        }
        //consultar modelo por ID
        public Models.MODELO ModeloporID(int ID)
        {
            return Contexto.MODELO.Where(mod => mod.IDMODELO == ID).SingleOrDefault();
        }
        //insertar modelo
        public bool InsertarModelo(Models.MODELO mod)
        {
            if (ModeloPorDescrip(mod.DESMODELO) == false)
            {
                Contexto.MODELO.Add(mod);
                Contexto.SaveChanges();
                return true;
            }
            return false;
        }
        //editar modelo
        public bool ActualizarModelo(Models.MODELO mod)
        {
            Models.MODELO modtemporal = ModeloporID(mod.IDMODELO);
            if (ModeloporID(mod.IDMODELO) != null)
            {
                //Edita descripcion
                if (modtemporal.DESMODELO != mod.DESMODELO)
                {
                    if (ModeloPorDescrip(mod.DESMODELO) == true) //existe
                        return false;
                }
                modtemporal.DESMODELO = mod.DESMODELO;
                modtemporal.IDMARCA = mod.IDMARCA;
                Contexto.SaveChanges();
                return true;
            }
            return false;
        }
        //eliminar modelo
        public bool EliminarModelo(int ID)
        {
            Models.MODELO modtemporal = ModeloporID(ID);
            if (ModeloporID(ID) != null)
            {
                //Valido integridad claves foraneas
                if (IdMod_Auto(ID) == true)
                    return false; //No puedo eliminar modelos heredados a autos
                Contexto.MODELO.Remove(modtemporal);
                Contexto.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
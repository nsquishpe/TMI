using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoRest_vPrueba.Data
{
    public class DataMarca
    {
        //Instancia de la BD 
        Models.TecniMecanica_vPruebaEntities2 Contexto;
        //Constructor
        public DataMarca()
        {
            Contexto = new Models.TecniMecanica_vPruebaEntities2();
            //Framework acorde a nuestros cambios IMPORTANTE
            Contexto.Configuration.ProxyCreationEnabled = false;
        }
        //METODOS PRIVADO
        //consultar existencia de marca por descripcion
        private bool MarcaPorDescrip(string des)
        {
            List<Models.MARCA> des_marca = new List<Models.MARCA>();
            des_marca = Contexto.MARCA.Where(m => m.DESMARCA.ToLower() == des.ToLower()).ToList();
            if (des_marca.Count() == 1) //existe la descripcion 
                return true;
            return false;
        }
        //Consultar integridad BD, claves foraneas
        private bool IdMarca_Modelo(int ID)
        {
            List<Models.MODELO> mar_model = new List<Models.MODELO>();
            mar_model = Contexto.MODELO.Where(m => m.IDMARCA == ID).ToList();
            if (mar_model.Count() != 0)
                return true; //existen modelos con dicha marca
            return false;
        }
        //METODOS
        //consultar todas las marcas
        public List<Models.MARCA> SeleccionarMarcas()
        {
            return Contexto.MARCA.ToList();
        }
        //consultar marca por ID
        public Models.MARCA MarcaporID(int ID)
        {
            return Contexto.MARCA.Where(mar => mar.IDMARCA == ID).SingleOrDefault();
        }
        //insertar marca
        public bool InsertarMarca(Models.MARCA mar)
        {
            if (MarcaPorDescrip(mar.DESMARCA) == false)
            {
                Contexto.MARCA.Add(mar);
                Contexto.SaveChanges();
                return true;
            }
            return false;
        }
        //editar marca
        public bool ActualizarMarca(Models.MARCA mar)
        {
            Models.MARCA martemporal = MarcaporID(mar.IDMARCA);
            if (MarcaporID(mar.IDMARCA) != null)
            {
                //Edita descripcion
                if (martemporal.DESMARCA != mar.DESMARCA)
                {
                    if (MarcaPorDescrip(mar.DESMARCA) == true) //existe
                        return false;
                }
                martemporal.DESMARCA = mar.DESMARCA;
                Contexto.SaveChanges();
                return true;
            }
            return false;
        }
        //eliminar marca
        public bool EliminarMarca(int ID)
        {
            Models.MARCA martemporal = MarcaporID(ID);
            if (MarcaporID(ID) != null)
            {
                //Valido integridad claves foraneas
                if (IdMarca_Modelo(ID) == true)
                    return false; //No puedo eliminar marcas heredados a modelos
                Contexto.MARCA.Remove(martemporal);
                Contexto.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
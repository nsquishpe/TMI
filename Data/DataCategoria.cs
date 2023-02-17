using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoRest_vPrueba.Data
{
    public class DataCategoria
    {
        //Instancia de la BD 
        Models.TecniMecanica_vPruebaEntities2 Contexto;
        //Constructor
        public DataCategoria()
        {
            Contexto = new Models.TecniMecanica_vPruebaEntities2();
            //Framework acorde a nuestros cambios IMPORTANTE
            Contexto.Configuration.ProxyCreationEnabled = false;
        }
        //METODOS PRIVADO
        //consultar existencia de categoría por descripcion
        private bool RepPorDescrip(string des)
        {
            List<Models.CATEGORIA> des_rep = new List<Models.CATEGORIA>();
            des_rep = Contexto.CATEGORIA.Where(r => r.DESCATEGORIA.ToLower() == des.ToLower()).ToList();
            if (des_rep.Count() == 1) //existe la descripcion 
                return true;
            return false;
        }
        //Consultar integridad BD, claves foraneas
        private bool CatRep_Rep(int ID)
        {
            List<Models.REPUESTO> des_rep = new List<Models.REPUESTO>();
            des_rep = Contexto.REPUESTO.Where(r => r.IDCATEGORIA == ID).ToList();
            if (des_rep.Count() != 0)
                return true; //existen repuestos con dicha categoria
            return false;
        }
        //METODOS
        //consultar todas las categorias de repuestos
        public List<Models.CATEGORIA> SeleccionarCategorias()
        {
            return Contexto.CATEGORIA.ToList();
        }
        //consultar categoria por ID
        public Models.CATEGORIA CategoriaporID(int ID)
        {
            return Contexto.CATEGORIA.Where(cat => cat.IDCATEGORIA == ID).SingleOrDefault();
        }
        //insertar categoria
        public bool InsertarCategoria(Models.CATEGORIA cat)
        {
            if (RepPorDescrip(cat.DESCATEGORIA) == false)
            {
                Contexto.CATEGORIA.Add(cat);
                Contexto.SaveChanges();
                return true;
            }
            return false;
        }
        //editar categoria
        public bool ActualizarCategoria(Models.CATEGORIA cat)
        {
            Models.CATEGORIA cattemporal = CategoriaporID(cat.IDCATEGORIA);
            if (CategoriaporID(cat.IDCATEGORIA) != null)
            {
                //Edita descripcion
                if (cattemporal.DESCATEGORIA != cat.DESCATEGORIA)
                {
                    if (RepPorDescrip(cat.DESCATEGORIA) == true) //existe
                        return false;
                }
                cattemporal.DESCATEGORIA = cat.DESCATEGORIA;
                Contexto.SaveChanges();
                return true;
            }
            return false;
        }
        //eliminar categoria
        public bool EliminarCategoria(int ID)
        {
            Models.CATEGORIA cattemporal = CategoriaporID(ID);
            if (CategoriaporID(ID) != null)
            {
                //Valido integridad claves foraneas
                if (CatRep_Rep(ID) == true)
                    return false; //No puedo eliminar categorias heredados a repuestos
                Contexto.CATEGORIA.Remove(cattemporal);
                Contexto.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
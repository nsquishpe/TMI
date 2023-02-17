using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoRest_vPrueba.Data
{
    public class DataRepuesto
    {
        //Instancia de la BD 
        Models.TecniMecanica_vPruebaEntities2 Contexto;
        //Constructor
        public DataRepuesto()
        {
            Contexto = new Models.TecniMecanica_vPruebaEntities2();
            //Framework acorde a nuestros cambios IMPORTANTE
            Contexto.Configuration.ProxyCreationEnabled = false;
        }
        //METODOS PRIVADO
        //consultar existencia de repuesto por descripcion
        private bool RepPorDescrip(string des)
        {
            List<Models.REPUESTO> des_rep = new List<Models.REPUESTO>();
            des_rep = Contexto.REPUESTO.Where(m => m.DESREPUESTO.ToLower() == des.ToLower()).ToList();
            if (des_rep.Count() == 1) //existe la descripcion 
                return true;
            return false;
        }
        //Consultar integridad BD, claves foraneas
        private bool IdRep_OrdDet(int ID)
        {
            List<Models.ORDENTRABAJODET> rep_or = new List<Models.ORDENTRABAJODET>();
            rep_or = Contexto.ORDENTRABAJODET.Where(m => m.IDREPUESTO == ID).ToList();
            if (rep_or.Count() != 0)
                return true; //existen ordenes con dicho repuesto
            return false;
        }
        //METODOS
        //consultar todas los repuestos
        public List<Models.REPUESTO> SeleccionarRepuestos()
        {
            return Contexto.REPUESTO.ToList();
        }
        //consultar repuesto por ID
        public Models.REPUESTO RepuestoporID(int ID)
        {
            return Contexto.REPUESTO.Where(rep => rep.IDREPUESTO == ID).SingleOrDefault();
        }
        //insertar repuesto
        public bool InsertarRepuesto(Models.REPUESTO rep)
        {
            if (RepPorDescrip(rep.DESREPUESTO) == false)
            {
                Contexto.REPUESTO.Add(rep);
                Contexto.SaveChanges();
                return true;
            }
            return false;
        }
        //editar repuesto
        public bool ActualizarRepuesto(Models.REPUESTO rep)
        {
            Models.REPUESTO reptemporal = RepuestoporID(rep.IDREPUESTO);
            if (RepuestoporID(rep.IDREPUESTO) != null)
            {
                //Edita descripcion
                if (reptemporal.DESREPUESTO != rep.DESREPUESTO)
                {
                    if (RepPorDescrip(rep.DESREPUESTO) == true) //existe
                        return false;
                }
                reptemporal.DESREPUESTO = rep.DESREPUESTO;
                reptemporal.COSTREPUESTO = rep.COSTREPUESTO;
                reptemporal.STOCKREPUESTO = rep.STOCKREPUESTO;
                reptemporal.IDCATEGORIA = rep.IDCATEGORIA;
                Contexto.SaveChanges();
                return true;
            }
            return false;
        }
        //eliminar repuesto
        public bool EliminarRepuesto(int ID)
        {
            Models.REPUESTO reptemporal = RepuestoporID(ID);
            if (RepuestoporID(ID) != null)
            {
                //Valido integridad claves foraneas
                if (IdRep_OrdDet(ID) == true)
                    return false; //No puedo eliminar repuestos heredados a ordenes
                Contexto.REPUESTO.Remove(reptemporal);
                Contexto.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
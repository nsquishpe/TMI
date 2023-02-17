using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace DemoRest_vPrueba.Data
{
    public class DataAutomovil
    {
        //Instancia de la BD 
        Models.TecniMecanica_vPruebaEntities2 Contexto;
        //Constructor
        public DataAutomovil()
        {
            Contexto = new Models.TecniMecanica_vPruebaEntities2();
            //Framework acorde a nuestros cambios IMPORTANTE
            Contexto.Configuration.ProxyCreationEnabled = false;
        }
        //METODOS PRIVADO
        //Verifica placa de auto valida
        #region validar placa    
        private bool ValidaPlaca(string placa)
        {
            int num;
            string[] aux = placa.Split('-');
            //3 letras - 3 o 4 numeros
            if ((Regex.IsMatch(aux[0], @"^[a-zA-Z]+$")) && (int.TryParse(aux[1], out num)))
            {
                if ((aux[0].Length == 3) && (aux[1].Length == 3 || aux[1].Length == 4))
                    return true;
            }
            return false;
        }
        #endregion
        //consultar existencia de placa
        private bool ValidarExisPlaca(string des)
        {
            List<Models.AUTOMOVIL> placas = new List<Models.AUTOMOVIL>();
            placas = Contexto.AUTOMOVIL.Where(p => p.PLACAAUTO.ToUpper() == des.ToUpper()).ToList();
            if (placas.Count() == 1) //existe la placa 
                return true;
            return false;
        }
        //Consultar integridad BD, claves foraneas
        private bool idAuto_Cab(int ID)
        {
            List<Models.ORDENTRABAJOENCAB> ord_aut = new List<Models.ORDENTRABAJOENCAB>();
            ord_aut = Contexto.ORDENTRABAJOENCAB.Where(r => r.IDAUTO == ID).ToList();
            if (ord_aut.Count() != 0)
                return true; //existen ordenes con dicha auto
            return false;
        }
        //METODOS
        //consultar todos los automoviles
        public List<Models.AUTOMOVIL> SeleccionarAutos()
        {
            return Contexto.AUTOMOVIL.ToList();
        }
        //consultar auto por ID
        public Models.AUTOMOVIL AutoporID(int ID)
        {
            return Contexto.AUTOMOVIL.Where(aut => aut.IDAUTO == ID).SingleOrDefault();
        }
        //insertar auto
        public bool InsertarAuto(Models.AUTOMOVIL aut)
        {
            if (ValidaPlaca(aut.PLACAAUTO) == true)
            {
                if (ValidarExisPlaca(aut.PLACAAUTO) == false)
                {
                    Contexto.AUTOMOVIL.Add(aut);
                    Contexto.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        //editar auto
        public bool ActualizarAuto(Models.AUTOMOVIL aut)
        {
            Models.AUTOMOVIL auttemporal = AutoporID(aut.IDAUTO);
            if (AutoporID(aut.IDAUTO) != null)
            {
                //Edita placa
                if (auttemporal.PLACAAUTO != aut.PLACAAUTO)
                {
                    if (ValidaPlaca(aut.PLACAAUTO) == true)
                    {
                        if (ValidarExisPlaca(aut.PLACAAUTO) == true) //existe
                            return false;
                    }
                    else
                        return false;
                }
                auttemporal.IDUSU = aut.IDUSU;
                auttemporal.IDMODELO = aut.IDMODELO;
                auttemporal.COLORAUTO = aut.COLORAUTO;
                auttemporal.KILOMAUTO = aut.KILOMAUTO;
                auttemporal.ANIO = aut.ANIO;
                auttemporal.TRANSMICION = aut.TRANSMICION;
                auttemporal.TIPOCOMBUSTIBLE = aut.TIPOCOMBUSTIBLE;
                auttemporal.PLACAAUTO = aut.PLACAAUTO;
                Contexto.SaveChanges();
                return true;
            }
            return false;
        }
        //eliminar auto
        public bool EliminarAuto(int ID)
        {
            Models.AUTOMOVIL auttemporal = AutoporID(ID);
            if (AutoporID(ID) != null)
            {
                //Valido integridad claves foraneas
                if (idAuto_Cab(ID) == true)
                    return false; //No puedo eliminar autos heredados a ordenes
                Contexto.AUTOMOVIL.Remove(auttemporal);
                Contexto.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
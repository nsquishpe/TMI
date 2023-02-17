using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoRest_vPrueba.Data
{
    public class DataOrdenTrabajoDet
    {
        //Instancia de la BD 
        Models.TecniMecanica_vPruebaEntities2 Contexto;
        //Constructor
        public DataOrdenTrabajoDet()
        {
            Contexto = new Models.TecniMecanica_vPruebaEntities2();
            //Framework acorde a nuestros cambios IMPORTANTE
            Contexto.Configuration.ProxyCreationEnabled = false;
        }
        //METODOS PRIVADO
        //Actualiza el stock del repuesto ingresado o actualizado
        private bool Valida_ActualizaStock(Models.ORDENTRABAJODET OrdenDetRep)
        {
            int ID = (int)OrdenDetRep.IDREPUESTO;
            DataRepuesto op = new DataRepuesto();
            Models.REPUESTO rep_temporal = op.RepuestoporID(ID);
            //Valido stock del repuesto 
            if (OrdenDetRep.CANTORDENDET <= rep_temporal.STOCKREPUESTO)
            {
                //Actualizo stock del repuesto 
                rep_temporal.STOCKREPUESTO = (rep_temporal.STOCKREPUESTO - OrdenDetRep.CANTORDENDET);
                op.ActualizarRepuesto(rep_temporal);
                return true;
            }
            return false;
        }
        private bool Valida_ExistenciaDetalle(Models.ORDENTRABAJODET OrdenDetRep)
        {
            List<Models.ORDENTRABAJODET> lineas = new List<Models.ORDENTRABAJODET>();
            //ID Cabecera Orden
            int NumOrden = OrdenDetRep.IDORDENCLI;
            if (OrdenDetRep.IDREPUESTO != null) //Es un repuesto
            {
                //Lineas de repuesto de la orden
                lineas = Contexto.ORDENTRABAJODET.Where(or_det => or_det.IDORDENCLI == NumOrden && or_det.IDREPUESTO!=null).ToList();
                //Repuesto que desea ingresar
                int id_rep = (int)OrdenDetRep.IDREPUESTO;
                //Busqueda del repuesto a ingresar
                if (lineas.Count()!=0)
                {
                    for (int i = 0; i < lineas.Count(); i++)
                    {
                        if (lineas[i].IDREPUESTO == id_rep)
                            return true; //ya existe el repuesto en una linea de detalle
                    }
                }

            }
            else //Es un servicio
            {
                //Lineas de servicio de la orden
                lineas = Contexto.ORDENTRABAJODET.Where(or_det => or_det.IDORDENCLI == NumOrden && or_det.IDSERVICIO != null).ToList();
                //Servicio que desea ingresar
                int id_ser = (int)OrdenDetRep.IDSERVICIO;
                //Busqueda del servicio a ingresar
                if (lineas.Count() != 0)
                {
                    for (int i = 0; i < lineas.Count(); i++)
                    {
                        if (lineas[i].IDSERVICIO == id_ser)
                            return true; //ya existe el servicio en una linea de detalle
                    }
                }

            }
            return false; //No hay existencia del serv o rep en la linea detalle
        }
        //METODOS
        //consultar todas las ordenes de trabajo detalle
        public List<Models.ORDENTRABAJODET> SeleccionarOrdenesTrabajoDet()
        {
            return Contexto.ORDENTRABAJODET.ToList();
        }
        //consultar orden de trabajo detalle por ID
        public Models.ORDENTRABAJODET OrdenTrabajoDetporID(int ID)
        {
            return Contexto.ORDENTRABAJODET.Where(or_det => or_det.IDORDENDET == ID).SingleOrDefault();
        }
        //insertar orden de trabajo detalle - IMPORTANTE
        public string InsertarOrdenTrabajoDet(Models.ORDENTRABAJODET or_det)
        {
            /*Una linea de detalle debe tener registrado un servicio o un repuesto*/
            //No se acepta un servicio y un repuesto para un registro en la BD
            if (!( or_det.IDREPUESTO!=null && or_det.IDSERVICIO!=null)){
                //En el caso de que no se ingrese un servicio o repuesto =>
                //Se valida que una linea de detalle contenga un servicio o repuesto
                if (or_det.IDREPUESTO != null || or_det.IDSERVICIO != null){
                    //Se valida que no se haya ingresado el ser o rep en una linea anterior
                    if (Valida_ExistenciaDetalle(or_det) == false)
                    {
                        if (or_det.IDREPUESTO != null) //Es un repuesto
                        {
                            if (Valida_ActualizaStock(or_det) == false)
                                return "Error Stock";
                        }
                        Contexto.ORDENTRABAJODET.Add(or_det); //Inserto linea detalleo rep o serv
                        Contexto.SaveChanges();
                        return "Correcto";
                    }
                    else
                        return "Existe linea";
                }
            }
            return "No nulos";
        }
        //editar orden de trabajo detalle
        public string ActualizarOrdenTrabajoDet(Models.ORDENTRABAJODET or_det)
        {
            Models.ORDENTRABAJODET ord_dettemporal = OrdenTrabajoDetporID(or_det.IDORDENDET);
            if (OrdenTrabajoDetporID(or_det.IDORDENDET) != null)
            {
                //Se valida que no se haya ingresado para actualizar el ser o rep en una linea anterior =>
                //No edit rep o serv
                if(ord_dettemporal.IDREPUESTO!=or_det.IDREPUESTO || ord_dettemporal.IDSERVICIO != or_det.IDSERVICIO)
                {
                    if (Valida_ExistenciaDetalle(or_det) == false)
                    {
                        if (ord_dettemporal.IDREPUESTO != null) //Es un repuesto
                        {
                            if (Valida_ActualizaStock(or_det) == false)
                                return "Error Stock";
                        }
                    }
                    else
                        return "Existe linea";
                }
                else //Mismo serv o rep
                {
                    if (ord_dettemporal.IDREPUESTO != null) //Es un repuesto
                    {
                        //Almaceno stock anterior
                        int ID = (int)ord_dettemporal.IDREPUESTO;
                        DataRepuesto op = new DataRepuesto();
                        Models.REPUESTO rep_temporal = op.RepuestoporID(ID);
                        //Editar cantidad
                        int Stock= (rep_temporal.STOCKREPUESTO + ord_dettemporal.CANTORDENDET);
                        if (or_det.CANTORDENDET <= Stock) {
                            rep_temporal.STOCKREPUESTO = (Stock - or_det.CANTORDENDET);
                            op.ActualizarRepuesto(rep_temporal);
                        }
                        else
                            return "Error Stock";
                    }
                }
                ord_dettemporal.IDORDENCLI = or_det.IDORDENCLI;
                ord_dettemporal.IDSERVICIO = or_det.IDSERVICIO;
                ord_dettemporal.IDREPUESTO = or_det.IDREPUESTO;
                ord_dettemporal.DESCRIPCIONDET = or_det.DESCRIPCIONDET;
                ord_dettemporal.TIEMPSERVHORAS = or_det.TIEMPSERVHORAS;
                ord_dettemporal.CANTORDENDET = or_det.CANTORDENDET;
                ord_dettemporal.PRECIOORDENDET = or_det.PRECIOORDENDET;
                Contexto.SaveChanges();
                return "Correcto";

            }
            return "No existe linea";
        }
        //eliminar orden de trabajo detalle
        public bool EliminarOrdenTrabajoDet(int ID)
        {
            Models.ORDENTRABAJODET ord_dettemporal = OrdenTrabajoDetporID(ID);
            if (OrdenTrabajoDetporID(ID) != null)
            {
                if (ord_dettemporal.IDREPUESTO != null) //Es un repuesto
                {
                    //Actualizo Stock del repuesto eliminado
                    int id = (int)ord_dettemporal.IDREPUESTO;
                    DataRepuesto op = new DataRepuesto();
                    Models.REPUESTO rep_temporal = op.RepuestoporID(id);
                    rep_temporal.STOCKREPUESTO = (rep_temporal.STOCKREPUESTO + ord_dettemporal.CANTORDENDET);
                    op.ActualizarRepuesto(rep_temporal);
                }
                Contexto.ORDENTRABAJODET.Remove(ord_dettemporal);
                Contexto.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
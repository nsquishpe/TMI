using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DemoRest_vPrueba.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class OrdenTrabajoDetController : ApiController
    {
        //Instancia de logica
        Logica.LogicOrdenTrabajoDet op = new Logica.LogicOrdenTrabajoDet();
        // GET: api/OrdenTrabajoDet
        public List<Models.ORDENTRABAJODET> Get()
        {
            return op.SeleccionarOrdenesTrabajoDet();
        }

        // GET: api/OrdenTrabajoDet/5
        public Models.ORDENTRABAJODET Get(int id)
        {
            return op.OrdenTrabajoDetporID(id);
        }

        // POST: api/OrdenTrabajoDet
        public string Post(Models.ORDENTRABAJODET ord_det)
        {
            return op.InsertarOrdenTrabajoDet(ord_det);
        }

        // PUT: api/OrdenTrabajoDet/5
        public string Put(Models.ORDENTRABAJODET ord_det)
        {
            return op.ActualizarOrdenTrabajoDet(ord_det);
        }

        // DELETE: api/OrdenTrabajoDet/5
        public bool Delete(int id)
        {
            return op.EliminarOrdenTrabajoDet(id);
        }
    }
}

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
    public class OrdenTrabajoEncabController : ApiController
    {
        //Instancia de logica
        Logica.LogicOrdenTrabajoEncab op = new Logica.LogicOrdenTrabajoEncab();
        // GET: api/OrdenTrabajoEncab
        public List<Models.ORDENTRABAJOENCAB> Get()
        {
            return op.SeleccionarOrdenesTrabajoEncab();
        }

        // GET: api/OrdenTrabajoEncab/5
        public Models.ORDENTRABAJOENCAB Get(int id)
        {
            return op.OrdenTrabajoEncabporID(id);
        }

        // POST: api/OrdenTrabajoEncab
        public void Post(Models.ORDENTRABAJOENCAB ord_encab)
        {
            op.InsertarOrdenTrabajoEncab(ord_encab);
        }

        // PUT: api/OrdenTrabajoEncab/5
        public bool Put(Models.ORDENTRABAJOENCAB ord_encab)
        {
            return op.ActualizarOrdenTrabajoEncab(ord_encab);
        }

        // DELETE: api/OrdenTrabajoEncab/5
        public bool Delete(int id)
        {
            return op.EliminarOrdenTrabajoEncab(id);
        }
    }
}

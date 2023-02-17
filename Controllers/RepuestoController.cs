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
    public class RepuestoController : ApiController
    {
        //Instancia de logica
        Logica.LogicRepuesto op = new Logica.LogicRepuesto();
        // GET: api/Repuesto
        public List<Models.REPUESTO> Get()
        {
            return op.SeleccionarRepuestos();
        }

        // GET: api/Repuesto/5
        public Models.REPUESTO Get(int id)
        {
            return op.RepuestoporID(id);
        }

        // POST: api/Repuesto
        public bool Post(Models.REPUESTO rep)
        {
            return op.InsertarRepuesto(rep);
        }

        // PUT: api/Repuesto/5
        public bool Put(Models.REPUESTO rep)
        {
            return op.ActualizarRepuesto(rep);
        }

        // DELETE: api/Repuesto/5
        public bool Delete(int id)
        {
            return op.EliminarRepuesto(id);
        }
    }
}

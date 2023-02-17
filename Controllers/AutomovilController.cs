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
    public class AutomovilController : ApiController
    {
        //Instancia de logica
        Logica.LogicAutomovil op = new Logica.LogicAutomovil();
        // GET: api/Automovil
        public List<Models.AUTOMOVIL> Get()
        {
            return op.SeleccionarAutos();
        }

        // GET: api/Automovil/5
        public Models.AUTOMOVIL Get(int id)
        {
            return op.AutoporID(id);
        }

        // POST: api/Automovil
        public bool Post(Models.AUTOMOVIL aut)
        {
            return op.InsertarAuto(aut);
        }

        // PUT: api/Automovil/5
        public bool Put(Models.AUTOMOVIL aut)
        {
            return op.ActualizarAuto(aut);
        }

        // DELETE: api/Automovil/5
        public bool Delete(int id)
        {
            return op.EliminarAuto(id);
        }
    }
}

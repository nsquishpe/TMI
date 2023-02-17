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
    public class EstadoOrdenController : ApiController
    {
        //Instancia de logica
        Logica.LogicEstadoOrden op = new Logica.LogicEstadoOrden();
        // GET: api/EstadoOrden
        public List<Models.ESTADOORDEN> Get()
        {
            return op.SeleccionarEstadosOrden();
        }

        // GET: api/EstadoOrden/5
        public Models.ESTADOORDEN Get(int id)
        {
            return op.EstadoOrdenporID(id);
        }

        // POST: api/EstadoOrden
        public bool Post(Models.ESTADOORDEN est)
        {
            return op.InsertarEstadoOrden(est);
        }

        // PUT: api/EstadoOrden/5
        public bool Put(Models.ESTADOORDEN est)
        {
            return op.ActualizarEstadoOrden(est);
        }

        // DELETE: api/EstadoOrden/5
        public bool Delete(int id)
        {
            return op.EliminarEstadoOrden(id);
        }
    }
}

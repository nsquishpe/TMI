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
    public class ServicioController : ApiController
    {
        //Instancia de logica
        Logica.LogicaServicio op = new Logica.LogicaServicio();
        // GET: api/Servicio
        public List<Models.SERVICIO> Get()
        {
            return op.SeleccionarServicios();
        }

        // GET: api/Servicio/5
        public Models.SERVICIO Get(int id)
        {
            return op.ServicioporID(id);
        }

        // POST: api/Servicio
        public bool Post(Models.SERVICIO ser)
        {
            return op.InsertarServicio(ser);
        }

        // PUT: api/Servicio/5
        public bool Put(Models.SERVICIO ser)
        {
            return op.ActualizarServicio(ser);
        }

        // DELETE: api/Servicio/5
        public bool Delete(int id)
        {
            return op.EliminarServicio(id);
        }
    }
}

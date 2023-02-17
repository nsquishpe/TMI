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
    public class ModeloController : ApiController
    {
        //Instancia de logica
        Logica.LogicModelo op = new Logica.LogicModelo();
        // GET: api/Modelo
        public List<Models.MODELO> Get()
        {
            return op.SeleccionarModelos();
        }

        // GET: api/Modelo/5
        public Models.MODELO Get(int id)
        {
            return op.ModeloporID(id);
        }

        // POST: api/Modelo
        public bool Post(Models.MODELO mod)
        {
            return op.InsertarModelo(mod);
        }

        // PUT: api/Modelo/5
        public bool Put(Models.MODELO mod)
        {
            return op.ActualizarModelo(mod);
        }

        // DELETE: api/Modelo/5
        public bool Delete(int id)
        {
            return op.EliminarModelo(id);
        }
    }
}

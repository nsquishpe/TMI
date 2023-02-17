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
    public class MarcaController : ApiController
    {
        //Instancia de logica
        Logica.LogicMarca op = new Logica.LogicMarca();
        // GET: api/Marca
        public List<Models.MARCA> Get()
        {
            return op.SeleccionarMarcas();
        }

        // GET: api/Marca/5
        public Models.MARCA Get(int id)
        {
            return op.MarcaporID(id);
        }

        // POST: api/Marca
        public bool Post(Models.MARCA mar)
        {
            return op.InsertarMarca(mar);
        }

        // PUT: api/Marca/5
        public bool Put(Models.MARCA mar)
        {
            return op.ActualizarMarca(mar);
        }

        // DELETE: api/Marca/5
        public bool Delete(int id)
        {
            return op.EliminarMarca(id);
        }
    }
}

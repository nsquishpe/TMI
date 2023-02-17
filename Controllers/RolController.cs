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
    public class RolController : ApiController
    {
        //Instancia de logica
        Logica.LogicRol op = new Logica.LogicRol();
        // GET: api/Rol
        public List<Models.ROL> Get()
        {
            return op.SeleccionarRoles();
        }

        // GET: api/Rol/5
        public Models.ROL Get(int id)
        {
            return op.RolporID(id);
        }

        // POST: api/Rol
        public bool Post(Models.ROL rol)
        {
            return op.InsertarRol(rol);
        }

        // PUT: api/Rol/5
        public bool Put(Models.ROL rol)
        {
            return op.ActualizarRol(rol);
        }

        // DELETE: api/Rol/5
        public bool Delete(int id)
        {
            return op.EliminarRol(id);
        }
    }
}

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
    public class UsuarioController : ApiController
    {
        //Instancia de logica
        Logica.LogicUsuario op = new Logica.LogicUsuario();
        // GET: api/Usuario
        public List<Models.USUARIO> Get()
        {
            return op.SeleccionarUsuarios();
        }

        // GET: api/Usuario/5
        public Models.USUARIO Get(int id)
        {
            return op.UsuarioporID(id);
        }

        // POST: api/Usuario
        public string Post(Models.USUARIO us)
        {
            return op.InsertarUsuario(us);
        }

        // PUT: api/Usuario/5
        public string Put(Models.USUARIO us)
        {
            return op.ActualizarUsuario(us);
        }

        // DELETE: api/Usuario/5
        public bool Delete(int id)
        {
            return op.EliminarUsuario(id);
        }
    }
}

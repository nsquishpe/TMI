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
    public class CategoriaController : ApiController
    {
        //Instancia de logica
        Logica.LogicCategoria op = new Logica.LogicCategoria();
        // GET: api/Categoria
        public List<Models.CATEGORIA> Get()
        {
            return op.SeleccionarCategorias();
        }

        // GET: api/Categoria/5
        public Models.CATEGORIA Get(int id)
        {
            return op.CategoriaporID(id);
        }

        // POST: api/Categoria
        public bool Post(Models.CATEGORIA cat)
        {
            return op.InsertarCategoria(cat);
        }

        // PUT: api/Categoria/5
        public bool Put(Models.CATEGORIA cat)
        {
            return op.ActualizarCategoria(cat);
        }

        // DELETE: api/Categoria/5
        public bool Delete(int id)
        {
            return op.EliminarCategoria(id);
        }
    }
}

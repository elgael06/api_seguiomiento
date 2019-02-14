using api_seguimiento.Manager.Productos_clasificador;
using api_seguimiento.Models.Productos_clasificador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api_seguimiento.Controllers.Productos_clasificador
{
    public class Productos_clasificador_por_folioController : ApiController
    {

        // GET api/Productos_clasificador_por_folio/
        public Clasificador_producto Post([FromUri] string  folio, [FromBody] string establecimiento)
        {
            return  new Clasificador_obtener_productos().Obtener(folio, establecimiento);
        }
    }
}
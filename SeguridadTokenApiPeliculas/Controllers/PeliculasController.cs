using SeguridadTokenApiPeliculas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SeguridadTokenApiPeliculas.Controllers
{
    public class PeliculasController : ApiController
    {
        ModeloPeliculas modelo;
        public PeliculasController()
        {
            this.modelo = new ModeloPeliculas();
        }

        [Authorize]
        [HttpGet]
        [Route("MostrarDistribuidoras")]
        public List<Distribuidoras> MostrarDistribuidoras()
        {
            return modelo.GetDistribuidoras();
        }

        [HttpGet]
        [Route("MostrarPelis")]
        public List<Peliculas> MostrarPelis()
        {
            return modelo.GetPeliculas();
        }
    }
}

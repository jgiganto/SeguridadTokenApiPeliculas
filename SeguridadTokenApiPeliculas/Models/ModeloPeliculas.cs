using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeguridadTokenApiPeliculas.Models
{
    public class ModeloPeliculas
    {
        ContextoPeliculas contexto;
        public ModeloPeliculas()
        {
            contexto = new ContextoPeliculas();
        }

        public List<Distribuidoras> GetDistribuidoras()
        {
            var consulta = from datos in contexto.Distribuidoras
                           select datos;
            return consulta.ToList();
        }

        public List<Peliculas> GetPeliculas()
        {
            var consulta = from datos in contexto.Peliculas
                           select datos;
            return consulta.ToList();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security.OAuth;
using System.Threading.Tasks;
using System.Security.Claims;
using SeguridadTokenApiPeliculas.Models;

namespace SeguridadTokenApiPeliculas.Credentials
{
    public class AutorizacionCredencialesToken:OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            using (ContextoPeliculas db = new ContextoPeliculas())
            {
                int empno = int.Parse(context.Password);
                var cliente = db.Clientes.FirstOrDefault(z => z.Email == context.UserName && z.IdCliente == empno);
                if (cliente == null)
                {
                    context.SetError("Acceso denegado", "Ususario o Pw incorrectos");
                    return;
                }
            }
            ClaimsIdentity identidad = new ClaimsIdentity(context.Options.AuthenticationType);
            identidad.AddClaim(new Claim(ClaimTypes.Name, context.Password));
            identidad.AddClaim(new Claim(ClaimTypes.Role, "EMPLEADO"));
            context.Validated(identidad);

        }
    }
}
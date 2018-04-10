using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(SeguridadTokenApiPeliculas.Startup))]

namespace SeguridadTokenApiPeliculas
{
    public class Startup
    {
        public void ConfigurarOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions opcionesautorizacion = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/recuperartoken"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(1),
                Provider = new Credentials.AutorizacionCredencialesToken()
            };
            app.UseOAuthAuthorizationServer(opcionesautorizacion);
            OAuthBearerAuthenticationOptions opcionesoauth = new OAuthBearerAuthenticationOptions()
            {
                AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active
            };
            app.UseOAuthBearerAuthentication(opcionesoauth);
        }

        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            ConfigurarOAuth(app);
            app.UseWebApi(config);

        }
    }
}

using System;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Questionnaire.HttpEndpoint.Startup))]

namespace Questionnaire.HttpEndpoint
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Run(context =>
            {
                string t = DateTime.Now.Millisecond.ToString();
                return context.Response.WriteAsync(t + " Production OWIN App");


            });
        }
    }
}

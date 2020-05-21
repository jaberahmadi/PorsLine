using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Questionnaire.HttpEndpoint.Startup))]

namespace Questionnaire.HttpEndpoint
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}

using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Questionnaire.Composition.Installers
{
	public class EndpointInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(Classes.FromAssemblyNamed("Questionnaire.HttpEndpoint")
				.Pick()
				.WithService
				.DefaultInterfaces()
				.LifestyleTransient()
			);
		}
	}
}
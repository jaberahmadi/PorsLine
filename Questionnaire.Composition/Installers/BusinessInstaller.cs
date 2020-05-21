using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Questionnaire.Business.Definitions.Factories;
using Questionnaire.Business.Definitions.Services;
using Questionnaire.DataAccess.MSSQL;
using Questionnaire.DataAccess.Repositories;

namespace Questionnaire.Composition.Installers
{
    public class BusinessInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{

			container.Register(Classes.FromAssemblyContaining<IQuestionnaireService>()
				.Pick()
				.WithServiceAllInterfaces()
				.LifestyleTransient());
            container.Register(Classes.FromAssemblyContaining<ILogQuestionnaireService>()
                .Pick()
                .WithServiceAllInterfaces()
                .LifestyleTransient());
            container.Register(Classes.FromAssemblyContaining<IQuestionnaireRepository>()
                .Pick()
                .WithServiceAllInterfaces()
                .LifestyleTransient());
            container.Register(Classes.FromAssemblyContaining<SqlUnitOfWork>()
                .Pick()
                .WithServiceAllInterfaces()
                .LifestyleTransient());
            container.Register(Classes.FromAssemblyContaining<IQuestionnaireFactory>()
                .Pick()
                .WithServiceAllInterfaces()
                .LifestyleTransient());
            container.Register(Classes.FromAssemblyContaining<ILogQuestionnaireFactory>()
                .Pick()
                .WithServiceAllInterfaces()
                .LifestyleTransient());
            container.Register(Classes.FromAssemblyContaining<IQuestionnaireRepository>()
                .Pick()
                .WithServiceAllInterfaces()
                .LifestyleTransient());
            container.Register(Classes.FromAssemblyContaining<ILogQuestionnaireRepository>()
                .Pick()
                .WithServiceAllInterfaces()
                .LifestyleTransient());
        }
	}
}

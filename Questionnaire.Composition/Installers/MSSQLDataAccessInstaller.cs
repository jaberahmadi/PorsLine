using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Questionnaire.DataAccess.MSSQL;
using Questionnaire.DataAccess.MSSQL.Repositories;


namespace Questionnaire.Composition.Installer
{
    public class MsSqlDataAccessInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {

            container.Register(Classes.FromAssemblyContaining<QuestionnaireRepository>()
                .Pick()
                .WithServiceAllInterfaces()
                .LifestyleTransient());

        }
    }
}
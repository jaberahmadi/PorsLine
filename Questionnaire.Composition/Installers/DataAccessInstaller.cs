using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Questionnaire.DataAccess.MSSQL;

namespace Questionnaire.Composition.Installer
{
    public class DataAccessInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {

            container.Register(Classes.FromAssemblyContaining<SqlUnitOfWork>()
                .Pick()
                .WithServiceAllInterfaces()
                .LifestyleTransient());
        }
    }
}

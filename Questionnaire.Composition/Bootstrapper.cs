using System;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace Questionnaire.Composition
{
    public static class Bootstrapper
    {
        private static IWindsorContainer container;

        private static IWindsorContainer Container
        {
            get
            {
                if (container == null)
                {
                    container = new WindsorContainer();
                    container.Install(FromAssembly.This());
                }
                return container;
            }

        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        public static object Resolve(Type type)
        {
            return Container.Resolve(type);
        }
    }
}
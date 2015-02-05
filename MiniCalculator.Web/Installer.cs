using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MiniCalculator.Logic.Calculator;
using MiniCalculator.Json;

namespace MiniCalculator
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            this.InstallControllers(container);
            this.InstallCalculator(container);
        }

        private void InstallControllers(IWindsorContainer container)
        {
            container.Register(Classes.FromThisAssembly().BasedOn<IController>().LifestyleTransient());
        }

        private void InstallCalculator(IWindsorContainer container)
        {
            container.Register(Component.For<ICombinedProbabilityCalculator>().ImplementedBy<CombinedProbabilityCalculator>());
            container.Register(Component.For<IEitherProbabilityCalculator>().ImplementedBy<EitherProbabilityCalculator>());

            container.Register(Component.For<IJsonCombinedProbabilityCalculator>().ImplementedBy<JsonCombinedProbabilityCalculator>());
            container.Register(Component.For<IJsonEitherProbabilityCalculator>().ImplementedBy<JsonEitherProbabilityCalculator>());
        }
    }
}

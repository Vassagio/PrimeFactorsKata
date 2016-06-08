using Autofac;
using PrimeFactors.Core;

namespace PrimeFactors.UI {
    public class Program {

        public static IContainer Container { get; set; }
        public static int Main(string[] args) {
            var builder = new ContainerBuilder();
            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<ConsoleIO>().As<IInputOutput>();
            builder.RegisterType<PrimeFactorService>().As<IPrimeFactorService>();
            Container = builder.Build();

            using (var scope = Container.BeginLifetimeScope())
                scope.Resolve<IApplication>().Run();

            return 0;
        }
    }
}
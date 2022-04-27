using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using R5T.D0085;
using R5T.D1001;
using R5T.D1001.A001;using R5T.T0064;


namespace R5T.I0085_1001
{[ServiceImplementationMarker]
    public abstract class ServicesConfigurerBase : IServicesConfigurer,IServiceImplementation
    {
        protected IServiceX ServiceX { get; }


        public ServicesConfigurerBase(
            IServiceX serviceX)
        {
            this.ServiceX = serviceX;
        }

        public async Task ConfigureServices(IServiceCollection services)
        {
            Console.WriteLine($"In {nameof(ServicesConfigurerBase)}.{nameof(ServicesConfigurerBase)}.");

            await this.ServiceX.RunX();

            // Services.
            var serviceZActionAggregation = Instances.ServiceAction.AddServiceZActionAggregation();

            await this.ConfigureServices(services,
                serviceZActionAggregation);
        }

        protected abstract Task ConfigureServices(IServiceCollection services,
            IServiceZActionAggregation serviceZActionAggregation);
    }
}

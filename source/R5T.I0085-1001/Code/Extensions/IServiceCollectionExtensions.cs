using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.D1001;
using R5T.D1001.I001;
using R5T.T0063;


namespace R5T.I0085_1001
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection UseServicesConfigurer<TServicesConfigurer>(this IServiceCollection services)
            where TServicesConfigurer : ServicesConfigurerBase
        {
            SyncOverAsyncHelper.ExecuteSynchronously(async () =>
            {
                var serviceXAction = Instances.ServiceAction.AddServiceXAction();

                var servicesConfigurerAction = Instances.ServiceAction.AddServicesConfigurerAction<TServicesConfigurer>(
                    serviceXAction)
                    ;

                using var servicesConfigurerServiceProvider = Instances.ServiceOperator.GetServiceInstance(
                    servicesConfigurerAction,
                    out TServicesConfigurer servicesConfigurer);

                await servicesConfigurer.ConfigureServices(services);
            });


            return services;
        }

        /// <summary>
        /// Adds the <see cref="ServicesConfigurerBase"/> operation as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddServicesConfigurer<TServicesConfigurer>(this IServiceCollection services,
            IServiceAction<IServiceX> serviceXAction)
            where TServicesConfigurer : ServicesConfigurerBase
        {
            services.AddSingleton<TServicesConfigurer>()
                .Run(serviceXAction)
                ;

            return services;
        }
    }
}

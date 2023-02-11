using System;

using R5T.D1001;
using R5T.T0062;
using R5T.T0063;


namespace R5T.I0085_1001
{
    public static class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="ServicesConfigurerBase"/> operation as a <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<TServicesConfigurer> AddServicesConfigurerAction<TServicesConfigurer>(this IServiceAction _,
            IServiceAction<IServiceX> serviceXAction)
            where TServicesConfigurer : ServicesConfigurerBase
        {
            var serviceAction = _.New<TServicesConfigurer>(services => services.AddServicesConfigurer<TServicesConfigurer>(
                serviceXAction));

            return serviceAction;
        }
    }
}

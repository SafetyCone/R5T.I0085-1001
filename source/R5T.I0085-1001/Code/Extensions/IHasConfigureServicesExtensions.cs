using System;

using R5T.T0072;

using R5T.I0085_1001;


namespace System
{
    public static class IHasConfigureServicesExtensions
    {
        public static TServicesBuilder UseServicesConfigurer<TServicesConfigurer, TServicesBuilder>(this TServicesBuilder servicesBuilder)
            where TServicesBuilder : IHasConfigureServices<TServicesBuilder>
            where TServicesConfigurer : ServicesConfigurerBase
        {
            servicesBuilder.ConfigureServices(services =>
            {
                services.UseServicesConfigurer<TServicesConfigurer>();
            });

            return servicesBuilder;
        }
    }
}

using CBTPreparation.Application.Abstractions.Service;
using CBTPreparation.Application.Handlers;
using CBTPreparation_Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;

namespace CBTPreparation.Application
{
    public static class DependencyInjection
    {
        private const string Url = "Aloc:BaseUrl";

        public static IServiceCollection ConfigureApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {

            var application = typeof(IAssemblyMarker);

            services.AddMediatR(configure =>
            {
                configure.RegisterServicesFromAssembly(application.Assembly);
                configure.AddOpenBehavior(typeof(UnitOfWorkBehaviour<,>));
            });

            services
            .AddRefitClient<IGetApiQuestionService>(new RefitSettings
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore
                })
            })
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(configuration[Url]))
            .AddHttpMessageHandler<AuthenticationDelegatingHandler>(); ;

            return services;
        }
    }
}

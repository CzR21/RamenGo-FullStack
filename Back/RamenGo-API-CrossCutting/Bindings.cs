using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RamenGo_API_Application.Implementations;
using RamenGo_API_Application.Interfaces;
using RamenGo_API_Data.Context;
using RamenGo_API_Data.Repositories;
using RamenGo_API_Domain.Interfaces.Repositories;
using RamenGo_API_Domain.Interfaces.Services;
using RamenGo_API_Domain.Options;
using RamenGo_API_Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamenGo_API_CrossCutting
{
    public class Bindings
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            #region Options
            ConnectionStringOption connectionStrings = configuration.GetSection("ConnectionStrings").Get<ConnectionStringOption>();
            APIKeyOption apiKey = configuration.GetSection("APIKey").Get<APIKeyOption>();
            APIRedVenturesOption apiRedVentures = configuration.GetSection("APIRedVentures").Get<APIRedVenturesOption>();
           
            services.AddSingleton(connectionStrings);
            services.AddSingleton(apiKey);
            services.AddSingleton(apiRedVentures);
            #endregion

            #region DI
            //AppService
            services.AddScoped<IRamenAppService, RamenAppService>();

            //Services
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddScoped<IBrothService, BrothService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProteinService, ProteinService>();

            //Repository
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IBrothRepository, BrothRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProteinRepository, ProteinRepository>();
            #endregion

            #region Context
            services.AddDbContext<RamenContext>(options => options.UseNpgsql(connectionStrings?.Database));
            #endregion

            #region HttpClient
            services.AddHttpClient<IRamenAppService, RamenAppService>()
                .ConfigureHttpMessageHandlerBuilder(builder =>
                {
                    builder.PrimaryHandler = new HttpClientHandler
                    {
                        ServerCertificateCustomValidationCallback = (m, c, ch, e) => true
                    };
                });
            #endregion
        }
    }
}

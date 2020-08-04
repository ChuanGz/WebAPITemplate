using Integration.BLL;
using Integration.BLL.Contracts;
using Integration.BLL.Models;
using Integration.DAL;
using Integration.DAL.Contract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class WebServiceExtensions
    {
        public static IServiceCollection AddWebServices(
            this IServiceCollection services,
            IConfigurationSection BLLOptionsSection,
            IConfigurationSection DALOptionSection)
        {
            if (BLLOptionsSection == null)
            {
                throw new ArgumentNullException(nameof(BLLOptionsSection));
            }

            if (DALOptionSection == null)
            {
                throw new ArgumentNullException(nameof(DALOptionSection));
            }

            var bllSettings = BLLOptionsSection.Get<BLLOptions>();

            services.Configure<BLLOptions>(opt =>
            {
                opt.JwtSecretKey = BLLOptionsSection.GetValue<string>("JwtSecretKey");
                opt.WebApiUrl = BLLOptionsSection.GetValue<string>("WebApiUrl");
            });
            services.Configure<RepositoryOption>(opt =>
            {
                opt.SqlServerDbConnectionString = DALOptionSection.GetValue<string>("SqlServerDbConnectionString");
                opt.HanaDbConnectionString = DALOptionSection.GetValue<string>("HanaDbConnectionString");
                opt.MySQLDbConnectionString = DALOptionSection.GetValue<string>("MySQLDbConnectionString");
                opt.SqlQueryStoreProcedure = DALOptionSection.GetValue<string>("SqlQueryStoreProcedure");
                opt.SqlQueryText = DALOptionSection.GetValue<string>("SqlQueryText");
            });

            services.TryAddSingleton<IAgreementsRepository, AgreementsRepository>();

            services.TryAddScoped<IAgreementsService, AgreementsService>();
            services.TryAddScoped<IJwtTokenService, JwtTokenService>();

            services.AddHttpClient();

            services.AddHealthChecks()
                .AddCheck<AgreementsRepository>("AgreementsRepository");

            return services;
        }

        public static IApplicationBuilder UseWebServices(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/api/health", new HealthCheckOptions()
            {
                ResponseWriter = (httpContext, result) =>
                {
                    httpContext.Response.ContentType = "application/json";

                    var json = new JObject(
                        new JProperty("status", result.Status.ToString()),
                        new JProperty("results", new JObject(result.Entries.Select(pair =>
                            new JProperty(pair.Key, new JObject(
                                new JProperty("status", pair.Value.Status.ToString())))))));
                    return httpContext.Response.WriteAsync(
                        json.ToString(Formatting.Indented));
                }
            });

            return app;
        }
    }
}

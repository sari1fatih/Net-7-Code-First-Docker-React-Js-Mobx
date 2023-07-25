using System.Net;
using System.Threading.RateLimiting;
using Common.Classes.ApplicationSettings;
using Common.Classes.BaseLimits;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NpgsqlTypes;
using Persistence;
using Persistence.Log.Serilog;
using RealEstate.Application;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.PostgreSQL;

namespace Bootstrapper
{
    public static class ServiceRegistration
    {
        public static void AddBootstrapper(this IServiceCollection services, IConfiguration configuration, IHostEnvironment hostEnvironment, ConfigureHostBuilder configureHostBuilder)
        {
            #region AppSettings           

            services.Configure<RateLimit>(configuration.GetSection(nameof(RateLimit)));

            var appOptions = configuration.GetSection(nameof(AppOptions)).Get<AppOptions>();
            RateLimit rateLimit = configuration.GetSection("RateLimit").Get<RateLimit>();

            #endregion

            #region Web Api 
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            Logger log = new LoggerConfiguration()
              .WriteTo.PostgreSQL(connectionString: appOptions?.ConnectionString,
                  tableName: "Logs",
                  needAutoCreateTable: true,
                  columnOptions: new Dictionary<string, ColumnWriterBase>
                  {
                        {"message", new RenderedMessageColumnWriter(NpgsqlDbType.Text)},
                        {"message_template", new MessageTemplateColumnWriter(NpgsqlDbType.Text)},
                        {"level", new LevelColumnWriter(true , NpgsqlDbType.Varchar)},
                        {"time_stamp", new TimestampColumnWriter(NpgsqlDbType.Timestamp)},
                        {"exception", new ExceptionColumnWriter(NpgsqlDbType.Text)},
                        {"log_event", new LogEventSerializedColumnWriter(NpgsqlDbType.Json)},
                        {"request", new RequestColumnWriter()},
                        {"ip_address", new IpAddressColumnWriter()}
                  })
              .Enrich.FromLogContext()
              .MinimumLevel.Warning()
              .CreateLogger();

            configureHostBuilder.UseSerilog(log);
             
            services.AddRateLimiter(options =>
            {
                options.AddSlidingWindowLimiter(nameof(rateLimit.StandartSliding), _options =>
                {
                    _options.Window = TimeSpan.FromMinutes(rateLimit.StandartSliding.FromMinute);
                    _options.PermitLimit = rateLimit.StandartSliding.PermitLimit;
                    _options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                    _options.QueueLimit = rateLimit.StandartSliding.QueueLimit;
                    _options.SegmentsPerWindow = rateLimit.StandartSliding.SegmentsPerWindow;
                });

                options.RejectionStatusCode = (int)HttpStatusCode.TooManyRequests;
            });
            #endregion

            #region Application

            services.AddApplicationLayer();

            #endregion

            #region Persistance

            services.AddPersistance(configuration, hostEnvironment); 

            #endregion
        }
    }
}


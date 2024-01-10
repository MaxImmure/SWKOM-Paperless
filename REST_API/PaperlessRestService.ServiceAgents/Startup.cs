using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using PaperlessRestService.BusinessLogic.DataAccess.Database;
using PaperlessRestService.BusinessLogic.DataAccess.RabbitMQ;
using PaperlessRestService.BusinessLogic.DataAccess;
using PaperlessRestService.Queue;
using Newtonsoft.Json.Converters;
using PaperlessRestService.ServiceAgents.Controllers;

namespace PaperlessRestService.ServiceAgents
{
    public class Startup
    {
        private readonly IWebHostEnvironment _hostingEnv;

        private IConfiguration Configuration { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="env"></param>
        /// <param name="configuration"></param>
        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            _hostingEnv = env;
            Configuration = configuration;
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services
                .AddMvc(options =>
                {
                    options.InputFormatters.RemoveType<Microsoft.AspNetCore.Mvc.Formatters.SystemTextJsonInputFormatter>();
                    options.OutputFormatters.RemoveType<Microsoft.AspNetCore.Mvc.Formatters.SystemTextJsonOutputFormatter>();
                })
                .AddNewtonsoftJson(opts =>
                {
                    opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    opts.SerializerSettings.Converters.Add(new StringEnumConverter(new CamelCaseNamingStrategy()));
                })
                .AddXmlSerializerFormatters();


            services
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("1.0", new OpenApiInfo
                    {
                        Version = "1.0",
                        Title = "Paperless Rest Server Services",
                        Description = "Paperless Rest Server Services (ASP.NET Core 3.1)",
                        Contact = new OpenApiContact()
                        {
                            Name = "Swagger Codegen Contributors",
                            Url = new Uri("https://github.com/swagger-api/swagger-codegen"),
                            Email = ""
                        },
                        TermsOfService = new Uri("https://google.at")
                    });
                    c.CustomSchemaIds(type => type.FullName);
                   // c.IncludeXmlComments($"{AppContext.BaseDirectory}{Path.DirectorySeparatorChar}{_hostingEnv.ApplicationName}.xml");

                    // Include DataAnnotation attributes on Controller Action parameters as Swagger validation rules (e.g required, pattern, ..)
                    // Use [ValidateModelState] on Actions to actually validate it in C# as well!
                    //c.OperationFilter<GeneratePathParamsValidationFilter>();
                });

            //services.AddAutoMapper(typeof(DTOMapperProfile));
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            services.AddLogging();

            RegisterDAL(services);
            RegisterBusinsessLogic(services);

        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseRouting();

            //TODO: Uncomment this if you need wwwroot folder
            // app.UseStaticFiles();

            app.UseAuthorization();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                //TODO: Either use the SwaggerGen generated Swagger contract (generated from C# classes)
                c.SwaggerEndpoint("/swagger/1.0/swagger.json", "Paperless Rest Server Services");

                //TODO: Or alternatively use the original Swagger contract that's included in the static files
                // c.SwaggerEndpoint("/swagger-original.json", "Paperless Rest Server Original");
            });

            //TODO: Use Https Redirection
            // app.UseHttpsRedirection();

            app.UseCors();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //TODO: Enable production exception handling (https://docs.microsoft.com/en-us/aspnet/core/fundamentals/error-handling)
                app.UseExceptionHandler("/Error");

                app.UseHsts();
            }
        }

        private void RegisterDAL(IServiceCollection services)
        {
            services.AddSingleton<IDbConnectionStringContainer>(new DbConnectionStringContainer(Configuration["DB_ConnectionString"]));

            services.AddSingleton<PaperlessDbContextFactory>();
            services.AddSingleton<DALActionExcecuterMiddleware>();

            var rabbitmq = new RabbitmqQueueReceiver(new OptionsWrapper<RabbitmqQueueOptions>(new RabbitmqQueueOptions(
                ConnectionString: Configuration["RABBITMQ_ConnectionString"],
                QueueName: Configuration["RABBITMQ_QueueName"])), null);
            services.AddSingleton<RabbitmqQueueReceiver>(rabbitmq);

            //Document d = new Document();
            //d.Title = "test124";
            //udl.UploadDocument(d);

            RegisterRepositories(services);
        }

        private void RegisterRepositories(IServiceCollection services)
        {

        }

        private void RegisterBusinsessLogic(IServiceCollection services)
        {
            services.AddSingleton<OCRController>();
        }
    }
}

/*
 * Paperless Rest Server
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 1.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using PaperlessRestService.BusinessLogic.DataAccess;
using PaperlessRestService.BusinessLogic.Entities;
using PaperlessRestService.BusinessLogic.Validators;
using PaperlessRestService.Filters;
using System;
using System.IO;
using Microsoft.Extensions.Options;
using PaperlessRestService.Queue;
using PaperlessRestService.BusinessLogic.DataAccess.Database;
using PaperlessRestService.BusinessLogic.DataAccess.RabbitMQ;
using PaperlessRestService.BusinessLogic;
using PaperlessRestService.BusinessLogic.DataAccess.MinIO;
using PaperlessRestService.BusinessLogic.Repositories;
using PaperlessRestService.Logging;
using PaperlessRestService.BusinessLogic.ExceptionHandling;
using PaperlessRestService.BusinessLogic.DataAccess.Repositories;
using PaperlessRestService.BusinessLogic.Interfaces.Components;

namespace PaperlessRestService
{
    /// <summary>
    /// Startup
    /// </summary>
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
                        Title = "Paperless Rest Server",
                        Description = "Paperless Rest Server (ASP.NET Core 3.1)",
                        Contact = new OpenApiContact()
                        {
                            Name = "Swagger Codegen Contributors",
                            Url = new Uri("https://github.com/swagger-api/swagger-codegen"),
                            Email = ""
                        },
                        TermsOfService = new Uri("https://google.at")
                    });
                    c.CustomSchemaIds(type => type.FullName);
                    c.IncludeXmlComments($"{AppContext.BaseDirectory}{Path.DirectorySeparatorChar}{_hostingEnv.ApplicationName}.xml");

                    // Include DataAnnotation attributes on Controller Action parameters as Swagger validation rules (e.g required, pattern, ..)
                    // Use [ValidateModelState] on Actions to actually validate it in C# as well!
                    c.OperationFilter<GeneratePathParamsValidationFilter>();
                });

            services.AddAutoMapper(typeof(DTOMapperProfile));
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

            RegisterValidators(services);
            RegisterDAL(services);
            RegisterBusinsessLogic(services);

            services.AddSingleton<IErrorHandler, ErrorHandler>();
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
            app.UseWebSockets();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                //TODO: Either use the SwaggerGen generated Swagger contract (generated from C# classes)
                c.SwaggerEndpoint("/swagger/1.0/swagger.json", "Paperless Rest Server");

                //TODO: Or alternatively use the original Swagger contract that's included in the static files
                // c.SwaggerEndpoint("/swagger-original.json", "Paperless Rest Server Original");
            });

            //TODO: Use Https Redirection
            // app.UseHttpsRedirection();

            app.UseMiddleware<LoggingMiddleware>();

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

            AutoMigrateService migrateService = app.ApplicationServices.GetService<AutoMigrateService>();
            migrateService.Migrate();
        }

        private void RegisterValidators(IServiceCollection services)
        {
            services.AddScoped<IValidator<DocumentType>, DocumentTypeValidator>();
            services.AddScoped<IValidator<Correspondents>, CorrespondentsValidator>();
            services.AddScoped<IValidator<Document>, DocumentValidator>();

            services.AddScoped<IValidator<Group>, GroupValidator>();
            services.AddScoped<IValidator<Notes>, NotesValidator>();
            services.AddScoped<IValidator<User>, UserValidator>();

            services.AddScoped<IUploadDocumentLogic, UploadDocumentLogic>();
        }

        private void RegisterDAL(IServiceCollection services)
        {
            services.AddSingleton<IDbConnectionStringContainer>(new DbConnectionStringContainer(Configuration["DB_ConnectionString"]));

            services.AddSingleton<AutoMigrateService>();
            services.AddSingleton<PaperlessDbContextFactory>();
            services.AddSingleton<DALActionExcecuterMiddleware>();

            services.AddSingleton<RabbitmqQueueOCRJob>(_ => new RabbitmqQueueOCRJob(new OptionsWrapper<RabbitmqQueueOptions>(new RabbitmqQueueOptions(
                ConnectionString: Configuration["RABBITMQ_ConnectionString"],
                QueueName: Configuration["RABBITMQ_QueueName"]))));

            services.AddSingleton<IMinioRepository>(_ => new MinioRepository(new MinioOptions(
                endpoint: Configuration["MINIO_Endpoint"],
                accessKey: Configuration["MINIO_AccessKey"],
                secretKey: Configuration["MINIO_SecretKey"],
                bucketName: Configuration["MINIO_BucketName"])));


            //Document d = new Document();
            //d.Title = "test124";
            //udl.UploadDocument(d);

            RegisterRepositories(services);
        }

        private void RegisterRepositories(IServiceCollection services)
        {
            services.AddSingleton<IDocumentRepository, DocumentRepository>();
            services.AddSingleton<ITagRepository, TagRepository>();
        }

        private void RegisterBusinsessLogic(IServiceCollection services)
        {
            services.AddSingleton<BLActionExecuterMiddleware>();
            services.AddSingleton<IUploadDocumentLogic, UploadDocumentLogic>();
            services.AddSingleton<IDocumentCRUDLogic, DocumentCRUDLogic>();
            services.AddSingleton<IElasticSearchAccessLogic, ElasticSearchAccessLogic>();
            services.AddSingleton<ITexterkennungLogic, TexterkennungLogic>();
            services.AddSingleton<ITagCRUDLogic, TagCRUDLogic>();
        }
    }
}

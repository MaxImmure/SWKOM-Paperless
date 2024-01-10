using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using PaperlessRestService.BusinessLogic.DataAccess.Database;
using PaperlessRestService.BusinessLogic.DataAccess.MinIO;
using PaperlessRestService.BusinessLogic.DataAccess.Options;
using PaperlessRestService.BusinessLogic.DataAccess.RabbitMQ;
using PaperlessRestService.ServiceAgents;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Worker>();

        services.Configure<DatabaseOptions>(hostContext.Configuration.GetSection("DatabaseOptions"));
        services.AddSingleton<DatabaseOptions>(sp => sp.GetRequiredService<IOptions<DatabaseOptions>>().Value);
        services.AddSingleton<IDbConnectionStringContainer, DbConnectionStringContainer>();

        services.Configure<QueueOptions>(hostContext.Configuration.GetSection("RabbitMqOptions"));
        services.AddSingleton(sp => sp.GetRequiredService<IOptions<QueueOptions>>().Value);
        services.AddSingleton<IQueueOCRJob, QueueOcrJob>();

        services.Configure<MinioOptions>(hostContext.Configuration.GetSection("MinioOptions"));
        services.AddSingleton(sp => sp.GetRequiredService<IOptions<MinioOptions>>().Value);
        services.AddSingleton<IMinioRepository, MinioRepository>();

        services.Configure<ElasticSearchOptions>(hostContext.Configuration.GetSection("ElasticSearchOptions"));
        services.AddSingleton(sp => sp.GetRequiredService<IOptions<ElasticSearchOptions>>().Value);
        //services.AddSingleton<IElasticSearchServiceAgent, ElasticSearchServiceAgent>();
    })
    .Build();

host.Run();

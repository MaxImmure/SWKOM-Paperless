using Microsoft.AspNetCore;

using PaperlessRestService;
using PaperlessRestService.ServiceAgents;

CreateWebHostBuilder(args).Build().Run();

/// <summary>
/// Create the web host builder.
/// </summary>
/// <param name="args"></param>
/// <returns>IWebHostBuilder</returns>
IWebHostBuilder CreateWebHostBuilder(string[] args) =>
    WebHost.CreateDefaultBuilder(args)
        .UseStartup<Startup>();
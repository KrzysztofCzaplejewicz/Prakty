using System.Configuration;
using LigaFutbolu.DataContexts;
using Microsoft.Extensions.DependencyInjection;

public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, LigaContext context)
{
loggerFactory.AddConsole(Configuration.GetSection("Logging"));
loggerFactory.AddDebug();

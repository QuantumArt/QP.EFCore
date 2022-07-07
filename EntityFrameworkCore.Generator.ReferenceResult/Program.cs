
using EntityFrameworkCore.Generator.ReferenceResult;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Npgsql;
using QA.DotNetCore.Caching;
using QA.DotNetCore.Caching.Interfaces;
using QA.DotNetCore.Engine.CacheTags;
using QA.DotNetCore.Engine.CacheTags.Configuration;
using QA.DotNetCore.Engine.Persistent.Interfaces;
using QA.DotNetCore.Engine.Persistent.Interfaces.Settings;
using QA.DotNetCore.Engine.QpData.Persistent.Dapper;
using QA.EF;
using Quantumart.QP8.EntityFrameworkCore.Generator.Models;

var builder = Host.CreateDefaultBuilder(args);
builder.ConfigureServices((context, services) =>
{
	var qpSettings = context.Configuration.GetSection("QpSettings").Get<QpSettings>();
	qpSettings.ConnectionString = context.Configuration.GetConnectionString("DatabaseQPPostgres");

	services.AddSingleton(qpSettings);
	
	services.AddScoped(_ => new NpgsqlConnection(qpSettings.ConnectionString));
	services.AddScoped(sp => EF6Model.CreateWithStaticMapping(
		qpSettings.IsStage
			? ContentAccess.Stage
			: ContentAccess.Live,
		sp.GetService<NpgsqlConnection>()));

	services.AddScoped<Test>();
});

var host = builder.Build();

var factory = host.Services.GetRequiredService<IServiceScopeFactory>();
using var scope = factory.CreateScope();
var test = scope.ServiceProvider.GetRequiredService<Test>();
await test.Run();

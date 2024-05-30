using dotb.releases;
using dotb.releases.repository;
using Microsoft.EntityFrameworkCore;
using Plisky.Plumbing;

ConfigHub ch = new ConfigHub();
ch.AddDirectoryFallbackProvider("%PLISKYAPPROOT%\\config", "dotb_releases.donotcommit");
string s = ch.GetSetting("dbconstr");
if (string.IsNullOrEmpty(s)) {
    throw new InvalidOperationException("No connection string found in configuration");
}

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();
string connectionString = s;
builder.Services.AddDbContext<ReleasesDbContext>(options => options.UseSqlServer(connectionString));
WebApplication app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
app.MapGrpcService<ReleaseService>();
app.MapGrpcReflectionService();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();

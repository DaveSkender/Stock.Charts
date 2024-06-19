// STARTUP CONFIGURATION

using Microsoft.Net.Http.Headers;
using WebApi.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

IServiceCollection services = builder.Services;
ConfigurationManager configuration = builder.Configuration;

// add framework services
services.AddControllers();

// get CORS origins from appsettings
// reminder: production origins defined in cloud host settings » API » CORS
// so these are really only for localhost / development
IConfigurationSection corsOrigins = configuration.GetSection("CorsOrigins");
string? allowedOrigin = corsOrigins["Website"];

List<string> origins = [];

if (!string.IsNullOrEmpty(allowedOrigin))
{
    origins.Add(item: allowedOrigin);
}

// setup CORS for website
services.AddCors(options => {
    options.AddPolicy("CorsPolicy",
    cors => {
        cors.AllowAnyHeader();
        cors.AllowAnyMethod();
        cors.AllowCredentials();
        cors.WithOrigins([.. origins])
            .SetIsOriginAllowedToAllowWildcardSubdomains();
    });
});

Console.WriteLine($"CORS Origin: {allowedOrigin}");

// register services
services.AddHostedService<StartupService>();
services.AddTransient<QuoteService>();

// build application
WebApplication app = builder.Build();

// configure the HTTP request pipeline
_ = app.Environment.IsDevelopment()
  ? app.UseDeveloperExceptionPage()
  : app.UseHsts();

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("CorsPolicy");
app.UseResponseCaching();

// controller endpoints
app.MapControllers();
app.Run();


using Pacagroup.Ecommerce.Service.WebApi.Modules.Swagger;
using Pacagroup.Ecommerce.Service.WebApi.Modules.Authentication;
using Pacagroup.Ecommerce.Service.WebApi.Modules.Mapper;
using Pacagroup.Ecommerce.Service.WebApi.Modules.Feature;
using Pacagroup.Ecommerce.Service.WebApi.Modules.Injection;
using Pacagroup.Ecommerce.Service.WebApi.Modules.Validator;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Pacagroup.Ecommerce.Service.WebApi.Modules.Versioning;
using Pacagroup.Ecommerce.Service.WebApi.Modules.HealthCheck;
using HealthChecks.UI.Client;
using WatchDog;
using Pacagroup.Ecommerce.Service.WebApi.Modules.WatchDog;


var builder = WebApplication.CreateBuilder(args);

string myPolicy = "policyApiEcommerce";
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//addAutoMapper
MapperExtensions.AddMapper(builder.Services);
//addCors
FeatureExtensions.AddFeature(builder.Services, builder.Configuration);
//injection services Interface-implement
InjectionExtensions.AddInjection(builder.Services);
//autentication jwt
AutheticationExtensions.AddAuthentication(builder.Services,builder.Configuration);
VersioningExtensions.AddVersioning(builder.Services);
//add library validator
ValidatorExtensions.addValidator(builder.Services);
HealthChenkExtensions.AddHealtCheck(builder.Services,builder.Configuration);
//add visualizador UI de logger
//WatchDogExtensions.AddWatchDog(builder.Services, builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
SwaggerExtensions.AddSwagger(builder.Services);
builder.Services.AddWatchDog(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
        foreach (var description in provider.ApiVersionDescriptions)
        {
            c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
        }
    });
}
app.UseWatchDogExceptionLogger();
app.UseHttpsRedirection();
app.UseCors(myPolicy);
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapHealthChecksUI();
app.MapHealthChecks("/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
app.UseWatchDog(conf =>
{
    conf.WatchPageUsername = builder.Configuration["WatchDog:WatchPageUserName"];
    conf.WatchPagePassword = builder.Configuration["WatchDog:WatchPagePassword"];
    //opt.Blacklist = "Test/testPost, weatherforecast";
});
app.Run();

public partial class Program { };
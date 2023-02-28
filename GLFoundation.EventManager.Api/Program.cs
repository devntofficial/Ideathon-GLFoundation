using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using GLFoundation.EventManager.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(x =>
{
    x.AddProfile<Mappings>();
});
builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.AddFastEndpoints();
builder.Services.AddResponseCaching();
builder.Services.AddJWTBearerAuth("JWTSigningKeyHere128BitsLongAtleast");
builder.Services.AddSwaggerDoc(maxEndpointVersion: 1, settings: settings =>
{
    settings.DocumentName = "Release 1.0";
    settings.Title = "GLFoundation Event Manager API";
    settings.Version = "v1.0";
})
.AddSwaggerDoc(maxEndpointVersion: 2, settings: settings =>
{
    settings.DocumentName = "Release 2.0";
    settings.Title = "GLFoundation Event Manager API";
    settings.Version = "v2.0";
});

var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseResponseCaching();
app.UseFastEndpoints(x =>
{
    x.Endpoints.RoutePrefix = "api";
    x.Versioning.Prefix = "v";
});
app.UseSwaggerGen();

app.Run();
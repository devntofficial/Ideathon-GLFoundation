using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using GLFoundation.Identity.Api;
using GLFoundation.Identity.Api.Domain;
using GLFoundation.Identity.Api.Persistence;
using GLFoundation.Shared.Library.Constants;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUserService, UserService>();
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
    settings.Title = "GLFoundation Identity API";
    settings.Version = "v1.0";
})
.AddSwaggerDoc(maxEndpointVersion: 2, settings: settings =>
{
    settings.DocumentName = "Release 2.0";
    settings.Title = "GLFoundation Identity API";
    settings.Version = "v2.0";
});
builder.Services.AddDbContext<IdentityDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<IdentityDbContext>();
    dataContext.Database.Migrate();

    if (!dataContext.Users.Any(x => x.Role.Equals(UserRoles.SuperAdmin)))
    {
        await dataContext.Users.AddAsync(new User
        {
            EmailId = "superadmin",
            Password = "superadmin",
            FullName = "Super Administrator",
            Role = UserRoles.SuperAdmin
        });
        await dataContext.SaveChangesAsync();
    }
}

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
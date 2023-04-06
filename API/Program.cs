global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
using API.Domain;
using API.Extensions;
using Microsoft.AspNetCore.Identity;
using ReactivitiesV1.Data;
using ReactivitiesV1.Extensions;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddApplicationIdentityServices(builder.Configuration);

var app = builder.Build();
app.UseCors("CorsPolicy");
// Configure the HTTP request pipeline.
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
    var context = services.GetRequiredService<DataContext>();
    var userManager = services.GetRequiredService<UserManager<AppUser>>();
    await context.Database.MigrateAsync();
    await Seed.SeedData(context, userManager);
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "Something went wrong");
}
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

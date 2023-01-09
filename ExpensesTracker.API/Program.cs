using Microsoft.OpenApi.Models;
using System.Net;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

#region Services
    // Services scope
#endregion

#region Repositories
    // Repositories scope
#endregion

var config = builder.Configuration;
var env = builder.Environment;

// Add services to the container.
services.AddControllersWithViews();

services.AddRazorPages();

services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ExpensesTracker API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStatusCodePages(context =>
{
    var agent = context.HttpContext.Request.Headers["User-Agent"].ToString().ToLower();

    if (agent.Contains("android") || agent.Contains("iphone"))
    {
        return Task.CompletedTask;
    }

    var response = context.HttpContext.Response;

    if (response.StatusCode == (int)HttpStatusCode.Unauthorized)
    {
        context.HttpContext.Response.Cookies.Append("redirectUrl", context.HttpContext.Request.Path + context.HttpContext.Request.QueryString);
        response.Redirect("/Account/SignIn");
    }
    else
    {
        response.Redirect($"/HttpError/{response.StatusCode}");
    }

    return Task.CompletedTask;
});

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapControllerRoute(
        name: "areaRoute",
        pattern: "{area:exists}/{controller}/{action}/{id?}");
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Dashboard}/{action=Index}/{id?}");
});

app.MapRazorPages();

app.UseSwagger();
app.UseSwaggerUI(c => {
    c.DocumentTitle = "Documentação - ExpensesTracker API";
    c.RoutePrefix = "docs";
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});

app.Run();

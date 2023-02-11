using ExpensesTracker.DAO.Data;
using ExpensesTracker.DAO.IRepository;
using ExpensesTracker.DAO.IService;
using ExpensesTracker.DAO.Models;
using ExpensesTracker.DAO.Repository;
using ExpensesTracker.DAO.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Net;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

#region Services

services.AddScoped<IServiceTransactions, ServiceTransactions>();

#endregion

#region Repositories

services.AddScoped<IRepositoryTransactions, RepositoryTransactions>();

#endregion

var config = builder.Configuration;
var env = builder.Environment;

var connectionString = config.GetConnectionString(env.EnvironmentName);

/**
 * Database context
 */
services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

/**
 * Default identity
 */
services.AddDefaultIdentity<AspNetUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

/**
 * Authentication
 */
services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config.GetValue<string>("Secret"))),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

/**
 * Cookies
 */
services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromDays(30);
        options.SlidingExpiration = true;
        options.LoginPath = "/Account/SignIn";
        options.LogoutPath = "/Account/SignOut";
        options.AccessDeniedPath = "/Account/AccessDenied";
    });

/**
 * Authorization
 */
services.AddAuthorization(options =>
{
    options.DefaultPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .AddAuthenticationSchemes("Bearer")
        .Build();
});

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

app.UseAuthentication();

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
    c.DocumentTitle = "Documenta��o - ExpensesTracker API";
    c.RoutePrefix = "docs";
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});

app.Run();

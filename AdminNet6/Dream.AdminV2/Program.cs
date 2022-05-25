using Dream.Logger;
using Dream.Security.LoginUtil;
using Dream.Util;
using Dream.Util.Cache;
using Microsoft.AspNetCore.Rewrite;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using NLog;
using NLog.Web;
using Dream.Admin.AppCode;
using EnvironmentName = Microsoft.Extensions.Hosting.EnvironmentName;

var logger = NLog.LogManager.GetLogger("error");
try
{

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddControllersWithViews();
    builder.Services.AddMemoryCache();
    builder.Services.AddSingleton<ILog, Log>();
    builder.Services.AddSingleton<IAuthenticationService, AuthenticationService>();
    builder.Services.AddSingleton<ICache, RedisCache>();
    //solve unicode issue
    builder.Services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.All));
    builder.Services.AddHttpContextAccessor();
    builder.Services.AddMvc();

    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    builder.Host.UseNLog();

    var app = builder.Build();

    app.Environment.EnvironmentName = EnvironmentName.Production;

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/error/{0}");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }
    else app.UseDeveloperExceptionPage();

    app.UseStaticHttpContext();
    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    var urls = ConfigUtil.GetURLRewriteConfig();
    foreach (var t in urls) app.UseRewriter(new RewriteOptions().AddRewrite(t.url, t.to, true));

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Login}/{action=Index}/{id?}");

    app.UseCustomErrorPages();

    
    app.Run();
}

catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}
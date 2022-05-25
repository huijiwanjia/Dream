using Dream.Logger;
using Dream.Security.LoginUtil;
using Dream.Util;
using Dream.Util.Cache;
using Microsoft.AspNetCore.Rewrite;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using NLog;
using EnvironmentName = Microsoft.Extensions.Hosting.EnvironmentName;
using NLog.Web;
using Newtonsoft.Json.Serialization;
using Dream.DataAccess.IService;
using Dream.DataAccess.Service;
using Dream.DataApi.Extensions;

var logger = NLog.LogManager.GetLogger("error");


try
{

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddMemoryCache();
    builder.Services.AddSingleton<ILog, Log>();
    builder.Services.AddSingleton<IUserService, UserService>();
    builder.Services.AddSingleton<IAccountService, AccountService>();
    builder.Services.AddSingleton<IPaymentService, PaymentService>();
    builder.Services.AddSingleton<IRecommentService, RecommentService>();
    builder.Services.AddSingleton<IOrderService, OrderService>();
    builder.Services.AddSingleton<IClickLogService, ClickLogService>();
    builder.Services.AddSingleton<IProfitService, ProfitService>();
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("any", policy =>
        {
            policy.AllowAnyOrigin(); //允许任何来源的主机访问
        });
    });

    //solve unicode issue
    builder.Services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.All));
    builder.Services.AddHttpContextAccessor();
    builder.Services.AddMvc();

    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    builder.Host.UseNLog();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    //if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseAuthorization();

    app.UseCors("any");
    app.UseStaticHttpContext();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=home}/{action=Index}/{id?}");
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

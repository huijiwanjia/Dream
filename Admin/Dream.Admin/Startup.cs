using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog.Web;
using Dream.Logger;
using Dream.Model;
using Dream.Security.LoginUtil;
using Dream.Util;
using Dream.Util.Cache;
using Dream.Admin.AppCode;

namespace Dream.Admin
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ILog, Log>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<ICache, RedisCache>();
            //解决unicode编码问题
            services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.All));
            services.AddHttpContextAccessor();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            env.EnvironmentName = EnvironmentName.Production;
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseStatusCodePagesWithReExecute("/error/{0}");
                //app.UseExceptionHandler("/Error");
                app.UseCustomErrorPages();
            }
            env.ConfigureNLog(string.Format("{0}{1}", Directory.GetCurrentDirectory(), "/Config/nlog.config"));//读取Nlog配置文件
            app.UseStaticFiles();
            app.UseStaticHttpContext();
            var urls = ConfigUtil.GetURLRewriteConfig();
            foreach (var t in urls) app.UseRewriter(new RewriteOptions().AddRewrite(t.url, t.to, true));
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=login}/{action=index}/{id?}");
            });
        }
    }
}

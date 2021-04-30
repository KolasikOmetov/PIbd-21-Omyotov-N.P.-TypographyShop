using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading;
using TypographyShopBusinessLogic.BusinessLogics;
using TypographyShopBusinessLogic.HelperModels;
using TypographyShopBusinessLogic.Interfaces;
using TypographyShopDatabaseImplement.Implements;

namespace TypographyShopRestApi
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
            services.AddTransient<IClientStorage, ClientStorage>();
            services.AddTransient<IOrderStorage, OrderStorage>();
            services.AddTransient<IPrintedStorage, PrintedStorage>();
            services.AddTransient<IMessageInfoStorage, MessageInfoStorage>();
            services.AddTransient<OrderLogic>();
            services.AddTransient<ClientLogic>();
            services.AddTransient<PrintedLogic>();
            services.AddTransient<MailLogic>();
            services.AddControllers().AddNewtonsoftJson();
            MailLogic.MailConfig(new MailConfig
            {
                SmtpClientHost = "smtp.gmail.com",
                SmtpClientPort = 587,
                MailLogin = "lab7using@gmail.com",
                MailPassword = "321ewq#@!",
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMessageInfoStorage messageInfoStorage)
        {
            // создаем таймер
            var timer = new Timer(new TimerCallback(MailCheck), new MailCheckInfo
            {
                PopHost = "pop.gmail.com",
                PopPort = 995,
                Storage = messageInfoStorage
            }, 0, 100000);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void MailCheck(object obj)
        {
            MailLogic.MailCheck((MailCheckInfo)obj);
        }
    }
}

using System;
using System.Threading.Tasks;
using CoroCure.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CoroCure
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
            var dbConnectionString = Configuration.GetConnectionString("CoroCureDb");
            services.AddDbContext<ApplicationDbContext>(options => {
                options.UseNpgsql(dbConnectionString, m => m.MigrationsAssembly("CoroCure"));
            });

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200", "http://localhost:8200")
                               .AllowAnyHeader()
                               .AllowAnyMethod()
                               .AllowCredentials();
                    });
            });

            services.AddLogging();

            services.AddControllers()
                .AddNewtonsoftJson();

            services.AddHttpContextAccessor();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options =>
                    {
                        options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                        options.LoginPath = string.Empty;
                        options.AccessDeniedPath = string.Empty;
                        options.ReturnUrlParameter = string.Empty;
                        options.LogoutPath = string.Empty;
                        options.Cookie.HttpOnly = true;
                        options.Events.OnSignedIn = context =>
                        {
                            context.Response.StatusCode = 200;
                            return Task.CompletedTask;
                        };
                        options.Events.OnRedirectToLogin = context =>
                        {
                            context.Response.StatusCode = 401;
                            return Task.CompletedTask;
                        };
                    });

            services.AddDistributedMemoryCache();

            services.AddAuthorization();

            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

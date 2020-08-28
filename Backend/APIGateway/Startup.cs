using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using API.Security;
using Core.Services.Interfaces;
using APIGateway.Extensions;
using Core.Services;
using API.HR;
using API.Training;
using Database.Sql.ERP;
using Core.Utility.Middlewares;
using Core.Utility.Filters;
using API.System;
using API.Common;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace APIGateway
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
            // Add Polity
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.WithOrigins(Configuration["Cors"])
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                });
            });
            services.AddControllers().AddNewtonsoftJson();
            services.AddMvc(options =>
            {
                options.Filters.Add(new AuthenticationFilter());
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
           
            // Add JWT Authentication
            services.AddJwtToken(Configuration);

            services.AddResponseCaching(options =>
            {
                options.SizeLimit = (1024 * 1024);
                options.UseCaseSensitivePaths = true;
            });

            // Staic file
            services.AddDirectoryBrowser();

            // Use http context
            // Omitted for clarity
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Caching
            services.AddScoped<IMemoryCachingService, MemoryCachingService>();
            // Use filter (Not working with Cors origin)
            services.AddFilter();

            // Declare connect to sql server
            services.AddDbContext<ERPContext>(option => option.UseSqlServer(Configuration.GetConnectionString("ERPConnection")), ServiceLifetime.Scoped);
            services.AddScoped<IERPUnitOfWork, ERPUnitOfWork>();

            //Use Security services
            services.AddCommonService(Configuration);
            services.AddSecurityServices(Configuration);
            services.AddHrServices(Configuration);
            services.AddTrainingServices(Configuration);
            services.AddRoleServices(Configuration);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //Use cors
            app.UseCors("CorsPolicy");

            app.UseMiddleware<JwtMiddleware>();

            //Use Authentication
            app.UseAuthentication();

            // Staic file
            app.UseStaticFilesFromCustomLocation(Configuration);

            app.UseAuthorization();

            app.UseHttpsRedirection();

            app.UseResponseCaching();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using API.Security;
using APIGateway.Extensions;
using API.HR;
using API.Training;
using Core.Utility.Middlewares;
using Core.Utility.Filters;
using API.System;
using API.Common;

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


            // Staic file
            services.AddDirectoryBrowser();

            // Use http context
            // Omitted for clarity
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Caching
            services.AddCaching();
            // Use filter (Not working with Cors origin)
            services.AddFilter();

            // Declare connect to sql server
            services.AddDatabase(Configuration);

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

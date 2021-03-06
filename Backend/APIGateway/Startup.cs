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
            services.AddCrossOriginResourceSharing(Configuration);


            // Add JWT Authentication
            services.AddJwtToken(Configuration);


            // Staic file
            services.AddDirectoryBrowser();

            // Use http context
            // Omitted for clarity
            services.AddMvc(options =>
            {
                options.Filters.Add(new AuthenticationFilter());
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpContextAccessor();
            services.AddControllers().AddNewtonsoftJson();

            // Caching
            services.AddCaching();
            // Use filter (Not working with Cors origin)
            services.AddFilter();

            // Declare connect to sql server
            services.AddDatabase(Configuration);

            //Use Security services
            services.AddCommonService(Configuration);
            services.AddHrServices(Configuration);
            services.AddTrainingServices(Configuration);
            services.AddRoleServices(Configuration);
            services.AddTransient<JwtMiddleware>();

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
            app.UseAuthorization();

            // Staic file
            app.UseStaticFilesFromCustomLocation(Configuration);

            app.UseHttpsRedirection();

            app.UseResponseCaching();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
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

            // Add JWT Authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    // Gets or Sets the parameters used to validate identity token.
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,  // Will be validated during token validation
                        ValidateAudience = true,    // To  control if the audience will be validated during token validation.
                        ValidateLifetime = true,    // To control if the lifetime will be validated during token validation
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"], // Represents a valid issuer that will be used to check against the token's issuer
                        ValidAudience = Configuration["Jwt:Audience"], //Represents a valid audience that will be used to check against the token's audience.
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SecretKey"])),
                    };
                });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            //Use http context
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Use for logger
            services.AddScoped<ILoggerService, LoggerService>();
            // Use filter (Not working with Cors origin)
            services.AddFilter();

            // Declare connect to sql server
            services.AddDbContext<ERPContext>(option => option.UseSqlServer(Configuration.GetConnectionString("ERPConnection")), ServiceLifetime.Scoped);
            services.AddScoped<IERPUnitOfWork, ERPUnitOfWork>();
            //Use Security services
            services.AddSecurityServices(Configuration);
            services.AddHrServices(Configuration);
            services.AddTrainingServices(Configuration);
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

            app.UseHttpsRedirection();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

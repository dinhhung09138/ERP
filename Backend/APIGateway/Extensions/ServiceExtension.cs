﻿using APIGateway.Fliters;
using Core.Services;
using Core.Services.Interfaces;
using Database.Sql.ERP;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIGateway.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddFilter(this IServiceCollection services)
        {
            //
            services.AddMvc().AddMvcOptions(options =>
            {
                options.Filters.Add<LoggerFilter>();
                options.Filters.Add<ActionFilter>();
                options.Filters.Add<AsyncActionFilter>();
            });

            return services;
        }

        public static IServiceCollection AddJwtToken(this IServiceCollection services, IConfiguration config)
        {
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
                        ValidIssuer = config["Jwt:Issuer"], // Represents a valid issuer that will be used to check against the token's issuer
                        ValidAudience = config["Jwt:Audience"], //Represents a valid audience that will be used to check against the token's audience.
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:SecretKey"])),
                    };
                });
            return services;
        }

        public static IServiceCollection AddCaching(this IServiceCollection services)
        {
            services.AddScoped<IMemoryCachingService, MemoryCachingService>();
            services.AddResponseCaching(options =>
            {
                options.SizeLimit = (1024 * 1024);
                options.UseCaseSensitivePaths = true;
            });
            return services;
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ERPContext>(option => option.UseSqlServer(config.GetConnectionString("ERPConnection")), ServiceLifetime.Scoped);
            services.AddScoped<IERPUnitOfWork, ERPUnitOfWork>();
            return services;
        }

        public static IServiceCollection AddCrossOriginResourceSharing(this IServiceCollection services, IConfiguration config)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.WithOrigins(config["Cors"])
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                });
            });
            return services;
        }
    }
}

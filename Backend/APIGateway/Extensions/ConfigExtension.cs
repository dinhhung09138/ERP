using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.Extensions
{
    public static class ConfigExtension
    {
        public static IApplicationBuilder UseStaticFilesFromCustomLocation(this IApplicationBuilder app, IConfiguration config)
        {
            string path = Directory.GetCurrentDirectory();
            string route = config["FileUpload:ServerFile:Route"];
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(path, route)),
                RequestPath = new PathString("/" + route),
            });

            app.UseDirectoryBrowser(new DirectoryBrowserOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(path, route)),
                RequestPath = new PathString("/" + route),
            });
            return app;
        }
    }
}

using Core.CommonModel;
using Core.Services;
using Database.Sql.ERP;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Service.Common.Interfaces;
using Service.Common.Models;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Core.CommonModel.Exceptions;
using System.IO;

namespace Service.Common
{
    public class ImageServerService : BaseService, IImageServerService
    {
        private readonly IERPUnitOfWork _context;
        private readonly IConfiguration _config;
        private readonly ILogger<ImageServerService> _logger;

        private readonly string serverPath = string.Empty;
        private readonly string configPath = string.Empty;

        public ImageServerService(
            IERPUnitOfWork context,
            IConfiguration config,
            ILogger<ImageServerService> logger,
            IHttpContextAccessor httpContext)
        {
            _context = context;
            _config = config;
            _logger = logger;
            base._httpContext = httpContext;

            serverPath = _config["FileUpload:ServerFile:ServerPath"];
            configPath = _config["FileUpload:ServerFile:ImagePath"];

            if (!Directory.Exists(Path.Combine(configPath)))
            {
                Directory.CreateDirectory(Path.Combine(configPath));
            }
        }


        public Task<ResponseModel> Delete(FileModel model)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> GetList(FilterModel filter)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Insert(FileModel model)
        {
            if (model.File == null)
            {
                throw new NullParameterException();
            }

            var filePath = Path.Combine(configPath);
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Item(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Update(FileModel model)
        {
            throw new NotImplementedException();
        }
    }
}

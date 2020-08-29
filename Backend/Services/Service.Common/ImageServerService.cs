using Core.CommonModel;
using Core.Services;
using Database.Sql.ERP;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Service.Common.Interfaces;
using Service.Common.Models;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Core.CommonModel.Exceptions;
using Core.Utility.Extensions;
using System.IO;
using System.Drawing;

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

            serverPath = _config["FileUpload:ServerFile:ServerPath"].ToLower();
            configPath = _config["FileUpload:ServerFile:ImagePath"].ToLower();

            if (!Directory.Exists(Path.Combine(configPath)))
            {
                Directory.CreateDirectory(Path.Combine(configPath));
            }
        }


        public Task<ResponseModel> GetList(FilterModel filter)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel> Item(int id)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                Database.Sql.ERP.Entities.Common.File md = await _context.FileRepository.FirstOrDefaultAsync(m => m.Id == id);

                if (md == null)
                {
                    return response;
                }

                FileModel model = new FileModel()
                {
                    Id = md.Id,
                    FileName = md.FileName,
                    FilePath = $"{serverPath}{md.FilePath}",
                    FilePath128 = $"{serverPath}{md.FilePath128}",
                    FilePath64 = $"{serverPath}{md.FilePath64}",
                    FilePath32 = $"{serverPath}{md.FilePath32}"
                };

                response.Result = model;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                response.Errors.Add(ex.Message);
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Warning;
            }
            return response;
        }

        public async Task<ResponseModel> Insert(FileModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                response.Result = await Save(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                response.Errors.Add(ex.Message);
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Warning;
            }

            return response;
        }

        public async Task<ResponseModel> Update(FileModel model)
        {
            ResponseModel response = new ResponseModel();

            try
            {

                response.Result = await Save(model);

                await ActiveWaitingForDeleteFileStatus(model.Id);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                response.Errors.Add(ex.Message);
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Warning;
            }

            return response;
        }

        public async Task<ResponseModel> Delete(FileModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                Database.Sql.ERP.Entities.Common.File md = await _context.FileRepository.FirstOrDefaultAsync(m => m.Id == model.Id);

                if (md == null)
                {
                    throw new NullParameterException();
                }

                if (!string.IsNullOrEmpty(md.FilePath) && System.IO.File.Exists(Path.Combine(md.FilePath)))
                {
                    System.IO.File.Delete(Path.Combine(md.FilePath));
                }

                if (!string.IsNullOrEmpty(md.FilePath128) && System.IO.File.Exists(Path.Combine(md.FilePath128)))
                {
                    System.IO.File.Delete(Path.Combine(md.FilePath128));
                }

                if (!string.IsNullOrEmpty(md.FilePath64) && System.IO.File.Exists(Path.Combine(md.FilePath64)))
                {
                    System.IO.File.Delete(Path.Combine(md.FilePath64));
                }

                if (!string.IsNullOrEmpty(md.FilePath32) && System.IO.File.Exists(Path.Combine(md.FilePath32)))
                {
                    System.IO.File.Delete(Path.Combine(md.FilePath32));
                }

                response.Result = model;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                response.Errors.Add(ex.Message);
                response.ResponseStatus = Core.CommonModel.Enums.ResponseStatus.Warning;
            }
            return response;
        }

        private async Task<int> Save(FileModel model)
        {
            var filePath = Path.Combine(configPath).ToLower();
            Database.Sql.ERP.Entities.Common.File md = new Database.Sql.ERP.Entities.Common.File();

            string fileName = Guid.NewGuid().ToString().Replace("-", "").ToLower();
            string ext = Path.GetExtension(model.File.FileName);

            string folderPath = Path.Combine(filePath, model.EmployeeCode).ToLower();

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string fullPath = Path.Combine(filePath, model.EmployeeCode, $"{fileName}{ext}").ToLower();

            md.FileName = model.File.FileName;
            md.FilePath = await SaveFile(model.File, fullPath);
            md.FilePath128 = ResizeAndSave(model.File, fullPath, 128, 128);
            md.FilePath64 = ResizeAndSave(model.File, fullPath, 64, 64);
            md.FilePath32 = ResizeAndSave(model.File, fullPath, 32, 32);
            md.Extension = ext;
            md.MineType = model.File.ContentType;
            md.Size = model.File.Length;
            md.SystemFileName = $"{fileName}{ext}";
            md.CreateBy = base.UserId;
            md.CreateDate = DateTime.Now;
            md.WaitForDeleted = false;

            await _context.FileRepository.AddAsync(md);
            await _context.SaveChangesAsync();

            return md.Id;
        }

        private async Task<string> SaveFile(IFormFile file, string fullPath)
        {
            try
            {
                await file.CopyToAsync(new FileStream(fullPath, FileMode.CreateNew, FileAccess.Write));
                return fullPath.Replace(@"\", @"/");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return string.Empty;
            }
        }

        private string ResizeAndSave(IFormFile file, string path, int width, int height)
        {
            try
            {
                string fileName = Guid.NewGuid().ToString().Replace("-", "").ToLower();
                string ext = Path.GetExtension(file.FileName);

                string fullPath = Path.Combine(path, $"{fileName}{ext}").ToLower();

                Image pic = new Bitmap(file.OpenReadStream());

                using (var source = new Bitmap(file.OpenReadStream()))
                {
                    using (var result = source.resizeImage(width, height))
                    {
                        result.Save(fullPath);
                    }
                }
                return fullPath.Replace(@"\", @"/");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return string.Empty;
            }
        }

        private async Task ActiveWaitingForDeleteFileStatus(int id)
        {
            if (id > 0)
            {
                Database.Sql.ERP.Entities.Common.File currentFile = await _context.FileRepository.FirstOrDefaultAsync(m => m.Id == id);

                if (currentFile != null)
                {
                    currentFile.WaitForDeleted = true;

                    _context.FileRepository.Update(currentFile);
                }
            }
        }

    }
}

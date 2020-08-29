using Core.CommonModel;
using Service.Common.Models;
using System.Threading.Tasks;

namespace Service.Common.Interfaces
{
    public interface IImageServerService : IFileService
    {
        Task<ResponseModel> SaveEmployeeAvatar(FileModel model);
    }
}

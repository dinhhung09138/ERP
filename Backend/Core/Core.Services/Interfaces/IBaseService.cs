using Core.CommonModel;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        Task<ResponseModel> GetList(FilterModel filter);
        Task<ResponseModel> Item(int id);
        Task<ResponseModel> Insert(T model);
        Task<ResponseModel> Update(T model);
        Task<ResponseModel> Delete(int id);
    }
}

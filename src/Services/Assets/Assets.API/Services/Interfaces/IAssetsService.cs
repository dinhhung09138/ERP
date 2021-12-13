namespace Assets.API.Services.Interfaces
{
    public interface IAssetsService
    {
        Task<List<Models.Assets>> GetAllAsync();

        Task<bool> InsertAsync();
    }
}

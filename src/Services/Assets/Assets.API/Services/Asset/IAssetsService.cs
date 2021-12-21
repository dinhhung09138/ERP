namespace Assets.API.Services.Asset
{
    public interface IAssetsService
    {
        Task<List<Entities.Asset>> GetAllAsync();

        Task<bool> InsertAsync();
    }
}

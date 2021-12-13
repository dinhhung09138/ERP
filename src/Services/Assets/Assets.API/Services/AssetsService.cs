using Assets;
using Assets.API.Infrastructures;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Assets.API.Services
{
    public class AssetsService : IAssetsService
    {
        private readonly IMongoCollection<Models.Assets> _assetCollection;

        public AssetsService(IOptions<DatabaseSetting> assetDatabaseSetting)
        {
            var mongoClient = new MongoClient(assetDatabaseSetting.Value.ConnectionString);
            var mongoDataBase = mongoClient.GetDatabase(assetDatabaseSetting.Value.DatabaseName);
            _assetCollection = mongoDataBase.GetCollection<Models.Assets>(assetDatabaseSetting.Value.AssetsCollectionName);
        }

        public async Task<List<Models.Assets>> GetAllAsync()
        {
            return await _assetCollection.Find(_ => true).ToListAsync();
        }

        public async Task<bool> InsertAsync()
        {
            Models.Assets asset = new Models.Assets()
            {
                Code = "001",
                Name = "Personal computer",
                DateBy = DateTime.Now,
                WantityDate = DateTime.Now
            };

            await _assetCollection.InsertOneAsync(asset);
            return true;
        }

    }
}

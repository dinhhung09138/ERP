using Assets;
using Assets.API.Infrastructures;
using DotNetCore.Objects;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Assets.API.Services.Asset
{
    public class AssetsService : IAssetsService
    {
        private readonly IMongoCollection<Entities.Asset> _assetCollection;

        public AssetsService(IOptions<DatabaseSetting> assetDatabaseSetting)
        {
            var mongoClient = new MongoClient(assetDatabaseSetting.Value.ConnectionString);
            var mongoDataBase = mongoClient.GetDatabase(assetDatabaseSetting.Value.DatabaseName);
            _assetCollection = mongoDataBase.GetCollection<Entities.Asset>(assetDatabaseSetting.Value.AssetsCollectionName);
        }

        public async Task<List<Entities.Asset>> GetAllAsync()
        {
            return await _assetCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Grid<Models.Asset.AssetGridVM>> GetGridAsync(Models.Asset.GridParameterVM model)
        {
            //Expression<Func<Entities.Asset, bool>> filter = m => m.Deleted == false
            //                                                     && m.Code.ToLower() == (string.IsNullOrEmpty(model.TextSearch) ? m.Code.ToLower() : model.TextSearch.ToLower())
            //                                                     && m.Name.ToLower() == (string.IsNullOrEmpty(model.TextSearch) ? m.Name.ToLower() : model.TextSearch.ToLower());

            //var data = await _assetCollection.FindAsync(filter);

            ////var filter = Builders<Entities.Asset>.Filter.Eq(m => m.Deleted, false);
            ////if (!string.IsNullOrEmpty(model.TextSearch))
            ////{
            ////    filter += 
            ////}

            //var query = _assetCollection.AsQueryable();
            //query = query.Where(m => m.Deleted == false);


            //var e = new GridParameters()
            //{
            //    Order = model.Order,
            //    Page = model.Page,
            //};

            return null;
        }

        public async Task<bool> InsertAsync()
        {
            Entities.Asset asset = new Entities.Asset()
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

using AkademiQMongoDb.DTOs.AboutDtos;
using AkademiQMongoDb.DTOs.ChefDtos;
using AkademiQMongoDb.Entities;
using AkademiQMongoDb.Settings;
using Mapster;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace AkademiQMongoDb.Services.ChefServices
{
    public class ChefService : IChefService
    {
        private readonly IMongoCollection<Chef> _chefCollection;

        public ChefService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _chefCollection = database.GetCollection<Chef>(databaseSettings.ChefCollectionName);
        }
        public async Task CreateAsync(CreateChefDto chefDto)
        {
            var chefs = chefDto.Adapt<Chef>();
            await _chefCollection.InsertOneAsync(chefs);
        }

        public async Task DeleteAsync(string id)
        {
            await _chefCollection.DeleteOneAsync(c => c.Id == id);
        }

        public async Task<List<ResultChefDto>> GetAllAsync()
        {
            var chefs = await _chefCollection.AsQueryable().ToListAsync();
            return chefs.Adapt<List<ResultChefDto>>().ToList();
        }

        public async Task<UpdateChefDto> GetByIdAsync(string id)
        {
            var chefs = await _chefCollection.Find(c => c.Id == id).FirstOrDefaultAsync();
            return chefs.Adapt<UpdateChefDto>();
        }

        public async Task UpdateAsync(UpdateChefDto chefDto)
        {
            var chef = chefDto.Adapt<Chef>();
            await _chefCollection.FindOneAndReplaceAsync(c => c.Id == chef.Id, chef);
        }
    }
}

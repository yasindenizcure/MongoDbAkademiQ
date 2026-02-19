using AkademiQMongoDb.DTOs.AboutDtos;
using AkademiQMongoDb.DTOs.ProductDtos;
using AkademiQMongoDb.Entities;
using AkademiQMongoDb.Settings;
using Mapster;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace AkademiQMongoDb.Services.AboutServices
{
    public class AboutService: IAboutService
    {
        private readonly IMongoCollection<About> _aboutCollection;

        public AboutService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _aboutCollection = database.GetCollection<About>(databaseSettings.AboutCollectionName);
        }

        public async Task CreateAsync(CreateAboutDto aboutDto)
        {
            var abouts = aboutDto.Adapt<About>();
            await _aboutCollection.InsertOneAsync(abouts);
        }

        public async Task DeleteAsync(string id)
        {
            await _aboutCollection.DeleteOneAsync(c=>c.Id == id);
        }

        public async Task<List<ResultAboutDto>> GetAllAsync()
        {
            var abouts = await _aboutCollection.AsQueryable().ToListAsync();
            return abouts.Adapt<List<ResultAboutDto>>().ToList();
        }

        public async Task<UpdateAboutDto> GetByIdAsync(string id)
        {
            var abouts = await _aboutCollection.Find(c => c.Id == id).FirstOrDefaultAsync();
            return abouts.Adapt<UpdateAboutDto>();
        }

        public async Task UpdateAsync(UpdateAboutDto aboutDto)
        {
            var about = aboutDto.Adapt<About>();
            await _aboutCollection.FindOneAndReplaceAsync(c => c.Id == about.Id, about);
        }
    }
}

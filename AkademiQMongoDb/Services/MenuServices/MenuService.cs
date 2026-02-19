using AkademiQMongoDb.DTOs.AboutDtos;
using AkademiQMongoDb.DTOs.MenuDtos;
using AkademiQMongoDb.Entities;
using AkademiQMongoDb.Settings;
using Mapster;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace AkademiQMongoDb.Services.MenuServices
{
    public class MenuService: IMenuService
    {
        private readonly IMongoCollection<Menu> _menuCollection;
        public MenuService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _menuCollection = database.GetCollection<Menu>(databaseSettings.MenuCollectionName);
        }
        public async Task CreateAsync(CreateMenuDto menuDto)
        {
            var menus = menuDto.Adapt<Menu>();
            await _menuCollection.InsertOneAsync(menus);
        }

        public async Task DeleteAsync(string id)
        {
            await _menuCollection.DeleteOneAsync(c => c.Id == id);
        }

        public async Task<List<ResultMenuDto>> GetAllAsync()
        {
            var menus = await _menuCollection.AsQueryable().ToListAsync();
            return menus.Adapt<List<ResultMenuDto>>().ToList();
        }

        public async Task<UpdateMenuDto> GetByIdAsync(string id)
        {
            var menus = await _menuCollection.Find(c => c.Id == id).FirstOrDefaultAsync();
            return menus.Adapt<UpdateMenuDto>();
        }

        public async Task UpdateAsync(UpdateMenuDto menuDto)
        {
            var menu = menuDto.Adapt<Menu>();
            await _menuCollection.FindOneAndReplaceAsync(c => c.Id == menu.Id, menu);
        }
    }
}

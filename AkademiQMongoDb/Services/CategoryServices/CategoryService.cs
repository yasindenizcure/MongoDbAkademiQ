using AkademiQMongoDb.DTOs.CategoryDtos;
using AkademiQMongoDb.Entities;
using AkademiQMongoDb.Settings;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace AkademiQMongoDb.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        // Collection = Tablo gibi düşünülebilir
        // Document = Entity
        public CategoryService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
        }
        public async Task CreateAsync(CreateCategoryDto categoryDto)
        {
           var category = new Category
           {
               CategoryName = categoryDto.CategoryName
           };
              await _categoryCollection.InsertOneAsync(category);
        }

        public async Task DeleteAsync(string id)
        {
            await _categoryCollection.DeleteOneAsync(c => c.Id == id);

        }

        public async Task<List<ResultCategoryDto>> GetAllAsync()
        {
            var categories =  await _categoryCollection.AsQueryable().ToListAsync();
            return categories.Select(c => new ResultCategoryDto
            {
                Id = c.Id,
                CategoryName = c.CategoryName
            }).ToList();
        }

        public async Task<UpdateCategoryDto> GetByIdAsync(string id)
        {
            var category =  await _categoryCollection.Find(x=>x.Id==id).FirstOrDefaultAsync();
            return new UpdateCategoryDto
            {
                Id = category.Id,
                CategoryName = category.CategoryName
            };
        }

        public async Task UpdateAsync(UpdateCategoryDto categoryDto)
        {
            var category = new Category
            {
                Id = categoryDto.Id,
                CategoryName = categoryDto.CategoryName
            };
            await _categoryCollection.FindOneAndReplaceAsync(c => c.Id == category.Id, category);
        }
    }
}

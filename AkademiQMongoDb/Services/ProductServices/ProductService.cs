using AkademiQMongoDb.DTOs.ProductDtos;
using AkademiQMongoDb.Entities;
using AkademiQMongoDb.Settings;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MongoDB.Driver;

namespace AkademiQMongoDb.Services.ProductServices
{
    public class ProductService: IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;

        public ProductService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
        }

        public async Task CreateAsync(CreateProductDto productDto)
        {
            var product = productDto.Adapt<Product>();
            await _productCollection.InsertOneAsync(product);
        }

        public async Task DeleteAsync(string id)
        {
            await _productCollection.DeleteOneAsync(c=>c.Id == id);
        }

        public async Task<List<ResultProductDto>> GetAllAsync()
        {
            var products = await _productCollection.AsQueryable().ToListAsync();
            return products.Adapt<List<ResultProductDto>>();

        }

        public async Task<UpdateProductDto> GetByIdAsync(string id)
        {
            var product = await _productCollection.Find(c => c.Id == id).FirstOrDefaultAsync();
            return product.Adapt<UpdateProductDto>();
        }

        public async Task UpdateAsync(UpdateProductDto productDto)
        {
            var product = productDto.Adapt<Product>();
            await _productCollection.FindOneAndReplaceAsync(c=>c.Id==product.Id, product);
        }
    }
}

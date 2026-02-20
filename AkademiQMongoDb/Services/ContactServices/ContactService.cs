using AkademiQMongoDb.DTOs.AboutDtos;
using AkademiQMongoDb.DTOs.ContactDtos;
using AkademiQMongoDb.Entities;
using AkademiQMongoDb.Settings;
using Mapster;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace AkademiQMongoDb.Services.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly IMongoCollection<Contact> _contactCollection;

        public ContactService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _contactCollection = database.GetCollection<Contact>(databaseSettings.ContactCollectionName);
        }
        public async Task CreateAsync(CreateContactDto contactDto)
        {
            var contacts = contactDto.Adapt<Contact>();
            await _contactCollection.InsertOneAsync(contacts);
        }

        public async Task DeleteAsync(string id)
        {
            await _contactCollection.DeleteOneAsync(c => c.Id == id);
        }

        public async Task<List<ResultContactDto>> GetAllAsync()
        {
            var contacts = await _contactCollection.AsQueryable().ToListAsync();
            return contacts.Adapt<List<ResultContactDto>>().ToList();
        }

        public async Task<UpdateContactDto> GetByIdAsync(string id)
        {
            var contacts = await _contactCollection.Find(c => c.Id == id).FirstOrDefaultAsync();
            return contacts.Adapt<UpdateContactDto>();
        }

        public async Task UpdateAsync(UpdateContactDto contactDto)
        {
            var contact = contactDto.Adapt<Contact>();
            await _contactCollection.FindOneAndReplaceAsync(c => c.Id == contact.Id, contact);
        }
    }
}

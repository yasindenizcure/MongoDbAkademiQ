using AkademiQMongoDb.DTOs.AboutDtos;
using AkademiQMongoDb.DTOs.BookingDtos;
using AkademiQMongoDb.Entities;
using AkademiQMongoDb.Settings;
using Mapster;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace AkademiQMongoDb.Services.BookingServices
{
    public class BookingService: IBookingService
    {
        private readonly IMongoCollection<Booking> _bookingCollection;

        public BookingService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _bookingCollection = database.GetCollection<Booking>(databaseSettings.BookingCollectionName);
        }

        public async Task CreateAsync(CreateBookingDto bookingDto)
        {
            var booking = bookingDto.Adapt<Booking>();
            await _bookingCollection.InsertOneAsync(booking);
        }

        public async Task DeleteAsync(string id)
        {
            await _bookingCollection.DeleteOneAsync(c => c.Id == id);
        }

        public async Task<List<ResultBookingDto>> GetAllAsync()
        {
            var booking = await _bookingCollection.AsQueryable().ToListAsync();
            return booking.Adapt<List<ResultBookingDto>>().ToList();
        }

        public async Task<UpdateBookingDto> GetByIdAsync(string id)
        {
            var bookings = await _bookingCollection.Find(c => c.Id == id).FirstOrDefaultAsync();
            return bookings.Adapt<UpdateBookingDto>();
        }

        public async Task UpdateAsync(UpdateBookingDto bookingDto)
        {
            var booking = bookingDto.Adapt<Booking>();
            await _bookingCollection.FindOneAndReplaceAsync(c => c.Id == booking.Id, booking);
        }
    }
}

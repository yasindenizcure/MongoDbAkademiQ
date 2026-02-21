using AkademiQMongoDb.DTOs.ProductDtos;
using AkademiQMongoDb.DTOs.SubscriberDtos;

namespace AkademiQMongoDb.Services.SubscriberServices
{
    public interface ISubscriberService
    {
        Task<List<ResultSubscriberDto>> GetAllAsync();
        Task<UpdateSubscriberDto> GetByIdAsync(string id);
        Task CreateAsync(CreateSubscriberDto subscriberDto);
        Task UpdateAsync(UpdateSubscriberDto subscriberDto);
        Task DeleteAsync(string id);
    }
}

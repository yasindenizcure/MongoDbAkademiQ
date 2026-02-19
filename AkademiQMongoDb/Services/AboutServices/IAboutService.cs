using AkademiQMongoDb.DTOs.AboutDtos;
using AkademiQMongoDb.DTOs.ProductDtos;

namespace AkademiQMongoDb.Services.AboutServices
{
    public interface IAboutService
    {
        Task<List<ResultAboutDto>> GetAllAsync();
        Task<UpdateAboutDto> GetByIdAsync(string id);
        Task CreateAsync(CreateAboutDto aboutDto);
        Task UpdateAsync(UpdateAboutDto aboutDto);
        Task DeleteAsync(string id);
    }
}

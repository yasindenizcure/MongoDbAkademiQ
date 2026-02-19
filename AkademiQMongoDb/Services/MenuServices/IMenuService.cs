using AkademiQMongoDb.DTOs.AboutDtos;
using AkademiQMongoDb.DTOs.MenuDtos;

namespace AkademiQMongoDb.Services.MenuServices
{
    public interface IMenuService
    {
        Task<List<ResultMenuDto>> GetAllAsync();
        Task<UpdateMenuDto> GetByIdAsync(string id);
        Task CreateAsync(CreateMenuDto menuDto);
        Task UpdateAsync(UpdateMenuDto menuDto);
        Task DeleteAsync(string id);
    }
}

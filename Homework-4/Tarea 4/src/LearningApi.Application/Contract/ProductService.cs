using LearningApi.Models.Dtos;

namespace LearningApi.Application.Contract
{
    public interface IProductService
    {
        Task<IEnumerable<ProductReadDto>> GetAll();
        Task<ProductReadDto> GetById(int id);
        Task<bool> Create(ProductCreateDto dto);
        Task<bool> Update(int id, ProductUpdateDto dto);
        Task<bool> Delete(int id);
    }
}

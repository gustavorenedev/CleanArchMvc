using CleanArchMvc.Application.DTOs;

namespace CleanArchMvc.Application.Interfces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDTO>> GetCategoriesAsync();
    Task<CategoryDTO> GetByIdAsync(int? id);
    Task AddAsync(CategoryDTO categoryDTO);
    Task UpdateAsync(CategoryDTO categoryDTO);
    Task RemoveAsync(int? id);
}

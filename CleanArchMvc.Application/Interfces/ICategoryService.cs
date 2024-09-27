using CleanArchMvc.Application.DTOs;

namespace CleanArchMvc.Application.Interfces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDTO>> GetCategories();
    Task<CategoryDTO> GetById(int? id);
    Task Add(CategoryDTO categoryDTO);
    Task Update(CategoryDTO categoryDTO);
    Task Remove(int? id);
}

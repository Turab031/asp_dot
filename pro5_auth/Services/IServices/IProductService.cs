using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pro5_auth.DTO;

namespace pro5_auth.Services.IServices
{
    public interface IProductService
    {
        Task<ProductResponseDto> Create(ProductCreateDto productCreateDto);

        Task<List<ProductResponseDto>> GetAll();

        Task<ProductResponseDto?> GetById(int id);

        Task<ProductResponseDto?> Update(ProductUpdateDto productUpdateDto);

        Task<string> Delete(int id);
    }
}
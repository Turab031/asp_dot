using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pro5_auth.DTO;
using pro5_auth.Models;
using pro5_auth.Services.IServices;

namespace pro5_auth.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDBContext _context;
        public ProductService(ApplicationDBContext context)
        {
            _context = context;

        }


        public async Task<ProductResponseDto> Create(ProductCreateDto productCreateDto)
        {
            var product = new ProductModel
            {
                Name = productCreateDto.Name,
                Description = productCreateDto.Description,
                Price = productCreateDto.Price

            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return new ProductResponseDto
            {
                Name = product.Name,
                Description = product.Description
            };

        }


        public async Task<string> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return "product not found";
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return "product deleted successfully";
        }

        public async Task<List<ProductResponseDto>> GetAll()
        {
            return await _context.Products.Select(p => new ProductResponseDto
            {
                Name = p.Name,
                Description = p.Description

            }).ToListAsync();
        }

        public async Task<ProductResponseDto?> GetById(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return null;

            }

            return new ProductResponseDto
            {
                Name = product.Name,
                Description = product.Description

            };
        }


        public async Task<ProductResponseDto?> Update(ProductUpdateDto productUpdateDto)
        {
            var product = await _context.Products.FindAsync(productUpdateDto.Id);

            if (product == null)
            {
                return null;
            }

            product.Name = productUpdateDto.Name;
            product.Description = productUpdateDto.Description;
            product.Price = productUpdateDto.Price;
            await _context.SaveChangesAsync();
            return new ProductResponseDto
            {
                Name = product.Name,
                Description = product.Description

            };

        }


    }
}
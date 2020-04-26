﻿using System.Linq;
using ShopSharp.Application.Products.ViewModels;
using ShopSharp.Database;

namespace ShopSharp.Application.Products
{
    public class GetProduct
    {
        private readonly ApplicationDbContext _context;

        public GetProduct(ApplicationDbContext context)
        {
            _context = context;
        }

        public ProductViewModel Exec(int id)
        {
            return _context.Products.Where(x => x.Id == id).Select(x => new ProductViewModel
            {
                Name = x.Name,
                Description = x.Description,
                Value = $"$ {x.Value:N2}" // 69420.60 => $ 69,420.60
            }).FirstOrDefault();
        }
    }
}
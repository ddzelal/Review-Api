using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_app1.Data;
using web_app1.Interfaces;
using web_app1.Models;

namespace web_app1.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private DataContext _context;
        public CategoryRepository(DataContext context)
        {
            _context = context;

        }
        public bool CategoryExist(int id)
        {
            return _context.Categories.Any(c => c.Id == id);

        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Where(e => e.Id == id).FirstOrDefault();
        }

        public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
        {
            return _context.PokemonCategories.Where(pc => pc.CategoryId == categoryId).Select(c => c.Pokemon).ToList();
        }
    }
}
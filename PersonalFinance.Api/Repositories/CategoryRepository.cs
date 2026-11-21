using PersonalFinance.Api.Context;
using PersonalFinance.Api.Models;
using PersonalFinance.Api.Repositories.Interfaces;

namespace PersonalFinance.Api.Repositories;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }
}
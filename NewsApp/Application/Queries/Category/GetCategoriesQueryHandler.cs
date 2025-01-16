using MediatR;
using NewsApp.Application.Interfaces;
using NewsApp.Models;

namespace NewsApp.Application.Queries;

public class GetCategoriesQueryHandler(ICategoryRepository categoryRepository) : IRequestHandler<GetCategoriesQuery, ICollection<Category?>>
{
    public async Task<ICollection<Category?>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await categoryRepository.GetAllCategories();
        return categories;
    }
}
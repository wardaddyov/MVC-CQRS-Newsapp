using MediatR;
using NewsApp.Application.Interfaces;
using NewsApp.Application.Queries.CategoryQueries;

namespace NewsApp.Application.Queries.Category;

public class GetCategoriesQueryHandler(ICategoryRepository categoryRepository) : IRequestHandler<GetCategoriesQuery, ICollection<Models.Category?>>
{
    public async Task<ICollection<Models.Category?>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await categoryRepository.GetAllCategories();
        return categories;
    }
}
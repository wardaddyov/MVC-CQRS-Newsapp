using MediatR;
using NewsApp.Application.Interfaces;

namespace NewsApp.Application.Queries.CategoryQueries;

public class CategoryNameQueryHandler (ICategoryRepository categoryRepository) : IRequestHandler<CategoryNameQuery, bool>
{
    public Task<bool> Handle(CategoryNameQuery request, CancellationToken cancellationToken)
    {
        return categoryRepository.CategoryExistsWithTheNameAsync(request.Name);
    }
}
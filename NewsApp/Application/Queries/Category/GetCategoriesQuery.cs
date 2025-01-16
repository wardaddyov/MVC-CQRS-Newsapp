using MediatR;
using NewsApp.Models;

namespace NewsApp.Application.Queries;

public class GetCategoriesQuery : IRequest<ICollection<Category?>>
{
    
}
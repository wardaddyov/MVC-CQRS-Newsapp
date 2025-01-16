using MediatR;
using NewsApp.Models;

namespace NewsApp.Application.Commands;

public record EditCategoryCommand(Category Category): IRequest<Category>;
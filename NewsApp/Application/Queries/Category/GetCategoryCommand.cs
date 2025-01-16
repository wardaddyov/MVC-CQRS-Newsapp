using MediatR;
using NewsApp.Models;

namespace NewsApp.Application.Queries;

public record GetCategoryCommand(int Id) : IRequest<Category?>;
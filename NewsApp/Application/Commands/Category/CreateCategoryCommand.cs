using MediatR;
using NewsApp.Models;

namespace NewsApp.Application.Commands;

public record CreateCategoryCommand : IRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
}
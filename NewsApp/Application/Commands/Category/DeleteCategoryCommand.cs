using MediatR;

namespace NewsApp.Application.Commands;

public record DeleteCategoryCommand(int Id) : IRequest;
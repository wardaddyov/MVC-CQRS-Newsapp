using MediatR;

namespace NewsApp.Application.Commands.NewsCommands;

public record DeleteMultipleNewsCommand(int[] Ids) : IRequest;

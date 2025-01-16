using MediatR;
using NewsApp.Models;

namespace NewsApp.Application.Commands.NewsCommands;

public record EditNewsCommand(News News, int[] CategoryIds) : IRequest;
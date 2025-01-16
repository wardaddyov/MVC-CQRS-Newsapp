using MediatR;
using NewsApp.Models;

namespace NewsApp.Application.Commands.NewsCommands;

public record CreateNewsCommand(News News, int[] CategoryIds) : IRequest;
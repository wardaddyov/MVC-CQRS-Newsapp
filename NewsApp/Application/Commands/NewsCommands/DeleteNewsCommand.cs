using MediatR;
using NewsApp.Models;

namespace NewsApp.Application.Commands.NewsCommands;

public record DeleteNewsCommand(News News) : IRequest;
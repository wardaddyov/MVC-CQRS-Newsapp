using MediatR;
using NewsApp.Application.Interfaces;

namespace NewsApp.Application.Commands.NewsCommands;

public class DeleteMultipleNewsCommandHandler(INewsRepository newsRepository): IRequestHandler<DeleteMultipleNewsCommand>
{
    public async Task Handle(DeleteMultipleNewsCommand request, CancellationToken cancellationToken)
    {
        var newsToDelete = await newsRepository.GetMultipleNewsByIdAsync(request.Ids);
        
        if (!newsToDelete.Any())
        {
            throw new Exception("No valid news items found to delete.");
        }

        var deletionSuccess = newsRepository.DeleteMultipleNews(newsToDelete.ToArray());

        if (!deletionSuccess)
            throw new Exception("Could not successfully delete the desired items");
    }
}
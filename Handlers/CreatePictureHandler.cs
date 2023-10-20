using GalleryApi.Data;
using MediatR;

class CreatePictureHandler : IRequestHandler<CreatePictureCommand, IAsyncResult>
{
    private readonly IRepository<Picture> repository;
    public CreatePictureHandler(IRepository<Picture> repository) 
    {
        this.repository = repository;
    }

    public Task<IAsyncResult> Handle(CreatePictureCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(repository.Create(request.picture));
    }
}
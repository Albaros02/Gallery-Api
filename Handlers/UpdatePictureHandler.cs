using GalleryApi.Data;
using MediatR;

class UpdatePictureHandler : IRequestHandler<UpdatePictureCommand, IAsyncResult>
{
    private readonly IRepository<Picture> repository;
    public UpdatePictureHandler(IRepository<Picture> repository) 
    {
        this.repository = repository;
    }

    public Task<IAsyncResult> Handle(UpdatePictureCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(repository.Update(request.id,request.picture));
    }
}
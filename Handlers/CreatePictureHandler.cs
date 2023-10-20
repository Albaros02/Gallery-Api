using GalleryApi.Data;
using MediatR;

class CreatePictureHandler : IRequestHandler<CreatePictureCommand, IAsyncResult>
{
    private readonly IRepository<PictureDto, Picture> repository;
    public CreatePictureHandler(IRepository<PictureDto, Picture> repository) 
    {
        this.repository = repository;
    }
    public async Task<IAsyncResult> Handle(CreatePictureCommand request, CancellationToken cancellationToken)
    {
        return await repository.Create(request.picture);
    }
}
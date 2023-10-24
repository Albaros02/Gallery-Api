using GalleryApi.Data;
using MediatR;

class CreatePictureHandler : IRequestHandler<CreatePictureCommand, IAsyncResult>
{
    private readonly IPictureRepository<PictureDto, Picture> repository;
    public CreatePictureHandler(IPictureRepository<PictureDto, Picture> repository) 
    {
        this.repository = repository;
    }
    public async Task<IAsyncResult> Handle(CreatePictureCommand request, CancellationToken cancellationToken)
    {
        var name = (request.name is null)? "nullName": request.name;
        return await repository.Create(request.picture,name);
    }
}
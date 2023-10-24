using GalleryApi.Data;
using MediatR;

class GetPictureHandler : IRequestHandler<GetPictureQuery, IEnumerable<Picture>>
{
    private readonly IPictureRepository<PictureDto, Picture> repository;
    public GetPictureHandler(IPictureRepository<PictureDto, Picture> repository) 
    {
        this.repository = repository;
    }
    Task<IEnumerable<Picture>> IRequestHandler<GetPictureQuery, IEnumerable<Picture>>.Handle(GetPictureQuery request, CancellationToken cancellationToken)
    {
        var name = (request.userName is null)? "nullName": request.userName;
        return Task.FromResult(repository.GetAll(name));
    }
}
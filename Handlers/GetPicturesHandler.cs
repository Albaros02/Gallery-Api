using GalleryApi.Data;
using MediatR;

class GetPictureHandler : IRequestHandler<GetPictureQuery, IEnumerable<Picture>>
{
    private readonly IRepository<PictureDto, Picture> repository;
    public GetPictureHandler(IRepository<PictureDto, Picture> repository) 
    {
        this.repository = repository;
    }
    Task<IEnumerable<Picture>> IRequestHandler<GetPictureQuery, IEnumerable<Picture>>.Handle(GetPictureQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(repository.GetAll());
    }
}
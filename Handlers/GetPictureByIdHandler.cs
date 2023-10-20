using GalleryApi.Data;
using MediatR;

class GetPictureByIdHandler : IRequestHandler<GetPictureByIdQuery, Picture>
{
    private readonly IRepository<Picture> repository;
    public GetPictureByIdHandler(IRepository<Picture> repository) 
    {
        this.repository = repository;
    }
    public async Task<Picture> Handle(GetPictureByIdQuery request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(repository.Get(request.id));
    }
}
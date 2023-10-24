using GalleryApi.Data;
using MediatR;

class UserExistsHandler : IRequestHandler<UserExistsQuery, bool>
{
    private readonly ApplicationDbContext applicationDbContext;

    public UserExistsHandler(ApplicationDbContext applicationDbContext) 
    {
        this.applicationDbContext = applicationDbContext;
    }
    public Task<bool> Handle(UserExistsQuery request, CancellationToken cancellationToken)
    {
        var user = applicationDbContext.Users.FirstOrDefault(x => x.UserName == request.name);
        return Task.FromResult(user is not null);
    }
}
using MediatR;
public record GetPictureQuery(string userName) : IRequest<IEnumerable<Picture>>; 

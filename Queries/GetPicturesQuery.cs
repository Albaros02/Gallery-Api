using MediatR;
public record GetPictureQuery() : IRequest<IEnumerable<Picture>>; 

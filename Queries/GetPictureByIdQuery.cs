using MediatR;
public record GetPictureByIdQuery(int id) : IRequest<Picture>; 

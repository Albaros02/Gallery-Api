using MediatR;
public record GetPictureByIdDetailsQuery(int id, string userName) : IRequest<Picture?>; 

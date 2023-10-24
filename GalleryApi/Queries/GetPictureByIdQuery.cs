using MediatR;
public record GetPictureByIdQuery(int id, string userName) : IRequest<(byte[],string)>; 

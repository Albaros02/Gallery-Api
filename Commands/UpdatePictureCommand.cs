using MediatR;
public record UpdatePictureCommand(int id, Picture picture) : IRequest<IAsyncResult>; 

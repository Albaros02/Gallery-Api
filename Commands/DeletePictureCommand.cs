using MediatR;
public record DeletePictureCommand(int id) : IRequest<IAsyncResult>; 

using MediatR;
public record UserExistsQuery(string name) : IRequest<bool>; 

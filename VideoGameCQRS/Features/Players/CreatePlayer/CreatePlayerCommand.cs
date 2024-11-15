using MediatR;

namespace VideoGameCQRS.Features.Players.CreatePlayer
{
    public record CreatePlayerCommand(string Name, int Level) : IRequest<int>;
   
}

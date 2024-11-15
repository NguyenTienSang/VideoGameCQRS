using MediatR;
using VideoGameCQRS.Models;

namespace VideoGameCQRS.Features.Players.GetPlayerById
{
    public record GetPlayerIdQuery(int Id) : IRequest<Player?>;

}

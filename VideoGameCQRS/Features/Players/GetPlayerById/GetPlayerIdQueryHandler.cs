using MediatR;
using VideoGameCQRS.Data;
using VideoGameCQRS.Models;

namespace VideoGameCQRS.Features.Players.GetPlayerById
{
    public class GetPlayerIdQueryHandler : IRequestHandler<GetPlayerIdQuery, Player?>
    {
        private readonly VideoGameAppDbContext _context;

        public GetPlayerIdQueryHandler(VideoGameAppDbContext context)
        {
            _context = context;
        }

        public async Task<Player?> Handle(GetPlayerIdQuery request, CancellationToken cancellationToken)
        {
            var player = await _context.Players.FindAsync(request.Id);
            return player;
        }
    }
}

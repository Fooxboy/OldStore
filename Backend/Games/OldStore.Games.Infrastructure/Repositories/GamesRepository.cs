using Microsoft.EntityFrameworkCore;
using OldStore.Games.Infrastructure.Database;
using OldStore.Games.Infrastructure.Models;

namespace OldStore.Games.Infrastructure.Repositories
{
    public class GamesRepository : IGamesRepository
    {
        private readonly GamesContext _context;

        public GamesRepository(GamesContext context)
        {
            _context = context;
        }

        public List<Game> GetGamesByIds(params int[] ids)
        {
            return _context.Games.Where(c => ids.Contains(c.Id))
                .Include(g=> g.Developers)
                .Include(g=> g.Images)
                .ToList();
        }

        public Game? GetGameById(int id)
        {
            return _context.Games
                .Include(g=> g.Developers)
                .Include(g=> g.Images)
                .FirstOrDefault(g => g.Id == id);
        }
    }
}

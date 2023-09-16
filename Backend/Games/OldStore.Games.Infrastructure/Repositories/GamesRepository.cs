using Microsoft.EntityFrameworkCore;
using OldStore.Games.Infrastructure.Database;
using OldStore.Games.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return _context.Games.Where(c => ids.Contains(c.Id)).Include(x=> x.Developers).Include(x=> x.Images).ToList();
        }
    }
}

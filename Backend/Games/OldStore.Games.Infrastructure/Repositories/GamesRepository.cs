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
        public List<Game> GetGamesByIds(params int[] ids)
        {
            throw new NotImplementedException();
        }
    }
}

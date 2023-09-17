using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldStore.Shared.Models
{
    public class Game
    {
        public int Id { get; private set; }
        
        public string Title { get; private set; }

        public int Year { get; private set; }

        public string Description { get; }

        public List<GameImage> Images { get; private set; }

        public string Publisher { get; private set; }

        public List<GameDeveloper> Developers { get; private set; }

        public List<GameGenre> Genres { get; private set; }
    }
}

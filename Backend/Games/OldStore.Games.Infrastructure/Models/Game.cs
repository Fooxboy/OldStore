using OldStore.Games.Domain.AggregatesModel.GameAggregate;
using System.ComponentModel.DataAnnotations;


namespace OldStore.Games.Infrastructure.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Description { get; }

        public List<Image> Images { get; set; }

        public string Publisher { get; set; }

        public List<Developer> Developers { get; set; }

        public List<GameGenre> Genres { get; set; }
    }
}

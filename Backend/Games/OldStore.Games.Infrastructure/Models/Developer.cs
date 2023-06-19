using System.ComponentModel.DataAnnotations.Schema;


namespace OldStore.Games.Infrastructure.Models
{
    public class Developer
    {
        public string Name { get; set; }

        public string? Payload { get; set; }

        public int GameId { get; set; }

        [ForeignKey("GameId")]
        public Game Game { get; set; }
    }
}

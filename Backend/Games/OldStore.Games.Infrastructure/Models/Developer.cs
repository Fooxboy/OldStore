using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OldStore.Games.Infrastructure.Models
{
    public class Developer
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string? Payload { get; set; }

        public List<Game> Games { get; set; }
    }
}

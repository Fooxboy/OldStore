using OldStore.Games.Domain.Events;
using OldStore.Services.Shared.Domain;

namespace OldStore.Games.Domain.AggregatesModel.GameAggregate
{
    public class Game : DomainEntity, IAggregateRoot
    {
        public string Title { get; private set; }

        public int Year { get; private set; }

        public string? Description { get; }

        public IReadOnlyCollection<GameImage> Images { get; private set; }

        public string? Publisher { get; private set; }

        public IReadOnlyCollection<GameDeveloper> Developers { get; private set; }

        public IReadOnlyCollection<GameGenre> Genres { get; private set; }


        public Game(string title, int year, string description, IEnumerable<GameImage> images,
            string publisher, IEnumerable<GameDeveloper> developers, IEnumerable<GameGenre> genres)
        {
            this.Title = title;
            this.Year = year;
            this.Description = description;
            this.Images = images.ToList();
            this.Publisher = publisher;
            this.Developers = developers.ToList();
            this.Genres = genres.ToList();
        }


        public void ChangeTitle(string newTitle)
        {
            var oldTitle = this.Title;

            this.Title = newTitle;

            var changeTitleEvent = new ChangeTitleEvent(this.Id, oldTitle, newTitle);

            this.AddDomainEvent(changeTitleEvent);

        }
    }
}

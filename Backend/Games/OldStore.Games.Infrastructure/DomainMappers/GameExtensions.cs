using OldStore.Games.Domain.AggregatesModel.GameAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldStore.Games.Infrastructure.DomainMappers
{
    public static class GameExtensions
    {
        public static Game CreateDomainEntity(this Models.Game gameDb)
        {
            var entity = new Game(gameDb.Title, 
                gameDb.Year,
                gameDb.Description,
                gameDb.Images.Select(i => i.CreateDomainEntity()),
                gameDb.Publisher,
                gameDb.Developers.Select(d => d.CreateDomainEntity()),
                gameDb.Genres);

            return entity;
        }

        public static GameDeveloper CreateDomainEntity(this Models.Developer developerDb)
        {
            return new (developerDb.Name, payload: developerDb.Payload);
        }

        public static GameImage CreateDomainEntity(this Models.Image imageDb)
        {
            return new(imageDb.Url);
        }
    }
}

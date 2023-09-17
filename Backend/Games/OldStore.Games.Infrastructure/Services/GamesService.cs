using OldStore.Games.Domain.AggregatesModel.GameAggregate;
using OldStore.Games.Infrastructure.DomainMappers;
using OldStore.Games.Infrastructure.Repositories;

namespace OldStore.Games.Infrastructure.Services
{
    public class GamesService
    {
        private readonly IGamesRepository _gamesRepository;

        public GamesService(IGamesRepository gamesRepository)
        {
            _gamesRepository = gamesRepository;
        }

        public async Task<List<Game>> GetGamesByIdsAsync(params int[] ids)
        {
            var games = _gamesRepository.GetGamesByIds(ids);

            var domainEntities = games.Select(g => g.CreateDomainEntity());

            return domainEntities.ToList();
        }

        public async Task<Game?> GetGameById(int id)
        {
            var game = _gamesRepository.GetGameById(id);

            return game?.CreateDomainEntity();
        }
    }
}

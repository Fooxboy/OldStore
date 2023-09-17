using OldStore.Shared.Models;

namespace OldStore.API.Services;

public interface IGamesService
{
    public Task<Game> GetGameById(int id);

    public Task<List<Game>> GetGamesByIds(int[] id);
}
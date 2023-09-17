using AutoMapper;
using GrpcGames;
using OldStore.Shared.Models;

namespace OldStore.API.Services;

public class GamesService : IGamesService
{
    private readonly GamesGrpc.GamesGrpcClient _client;
    private readonly IMapper _mapper;

    public GamesService(GamesGrpc.GamesGrpcClient client, IMapper mapper)
    {
        _client = client;
        _mapper = mapper;
    }

    public async Task<Game> GetGameById(int id)
    {
        var game = await _client.GetByIdAsync(new GetByIdRequest { Id = id });

        return _mapper.Map<Game>(game);
    }

    public async Task<List<Game>> GetGamesByIds(int[] id)
    {
        var games = (await _client.GetByIdsAsync(new GetByIdsRequest() { Items = { id } }))
            .Items
            .Select(g=> _mapper.Map<Game>(g));

        return games.ToList();
    }
}
using AutoMapper;
using Grpc.Core;
using GrpcGames;
using OldStore.Games.Infrastructure.Services;

namespace OldStore.Games.API.Grpc
{
    public class GamesGrpcService : GrpcGames.GamesGrpc.GamesGrpcBase
    {
        private readonly GamesService _gameService;

        private readonly IMapper _mapper;

        public GamesGrpcService(GamesService gameService, IMapper mapper)
        {
            _gameService = gameService;
            _mapper = mapper;
        }

        public override async Task<GetByIdsResponse> GetByIds(GetByIdsRequest request, ServerCallContext context)
        {
            var games = await _gameService.GetGamesByIdsAsync(request.Items.ToArray());

            var gamesEntity = games.Select(x => _mapper.Map<GameGrpc>(x));

            var response = new GetByIdsResponse();
            response.Items.AddRange(gamesEntity);

            return response;
        }
    }
}

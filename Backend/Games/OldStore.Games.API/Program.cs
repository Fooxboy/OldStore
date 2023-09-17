using Microsoft.EntityFrameworkCore;
using OldStore.Games.API.Grpc;
using OldStore.Games.API.Helpers;
using OldStore.Games.Infrastructure.Database;
using OldStore.Games.Infrastructure.Repositories;
using OldStore.Games.Infrastructure.Services;

namespace OldStore.Games.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAutoMapper(typeof(GamesMappingProfile));
            builder.Services.AddDbContext<GamesContext>(options =>
                options.UseNpgsql(builder.Configuration.GetValue<string>("Database")));
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddTransient<IGamesRepository, GamesRepository>();
            builder.Services.AddTransient<GamesService>();
            
            builder.Services.AddGrpc();

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseAuthorization();
            
            app.MapGrpcService<GamesGrpcService>();

            app.MapControllers();

            app.Run();
        }
    }
}
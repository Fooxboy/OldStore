using Microsoft.EntityFrameworkCore;
using OldStore.Catalogs.API.Grpc;
using OldStore.Catalogs.API.Helpers;
using OldStore.Catalogs.Infrastructure.Database;
using OldStore.Catalogs.Infrastructure.Repositories;

namespace OldStore.Catalogs.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAutoMapper(typeof(AppMappingProfile));

            builder.Services.AddDbContext<CatalogsContext>(options =>
                    options.UseNpgsql("Host=localhost:5432;Database=catalogs;Username=postgres;Password=123456"));

            // Add services to the container.

            builder.Services.AddTransient<IBlocksRepository, BlocksRepository>();
            builder.Services.AddTransient<ICatalogsRepository, CatalogsRepository>();
            builder.Services.AddTransient<OldStore.Catalogs.Infrastructure.Services.CatalogsService>();


            builder.Services.AddGrpc();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapGrpcService<CatalogsService>();

            app.MapControllers();

            app.Run();
        }
    }
}
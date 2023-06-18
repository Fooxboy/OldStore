using OldStore.Catalogs.API.Grpc;
using OldStore.Catalogs.API.Helpers;

namespace OldStore.Catalogs.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddGrpc();
            builder.Services.AddAutoMapper(typeof(AppMappingProfile));

            // Add services to the container.

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
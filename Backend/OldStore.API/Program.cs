using OldStore.API.Helpers;
using OldStore.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpcClient<GrpcCatalogs.Catalogs.CatalogsClient>((s, o) =>
{
    o.Address = new Uri(builder.Configuration.GetValue<string>("MicroservicesUrls:catalogs"));
});

// Add services to the container.

builder.Services.AddTransient<ICatalogsService, CatalogsService>();
builder.Services.AddAutoMapper(typeof(GatewayAutoMapperProfile));

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

app.MapControllers();

app.Run();

using Microsoft.EntityFrameworkCore;
using OldStore.Files.API.Database;
using OldStore.Files.API.Repositories;
using OldStore.Files.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FilesContext>(options =>
    options.UseNpgsql(builder.Configuration.GetValue<string>("Database")));


builder.Services.AddTransient<IFileRepository, FilesRepository>();
builder.Services.AddTransient<IFileService, FileService>();

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
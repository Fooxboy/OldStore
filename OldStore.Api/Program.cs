using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OldStore.Backend.Databases;
using OldStore.Backend.Managers;
using OldStore.Backend.Models.Entities;
using OldStore.Backend.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigureServices(builder.Services);

var app = builder.Build();

app.Urls.Add("http://0.0.0.0:5000");
app.Urls.Add("https://0.0.0.0:5001");


app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(builder =>
   builder
   //.AllowAnyOrigin()
   .WithOrigins("http://0.0.0.0:5000")
   .WithOrigins("http://0.0.0.0:5001")
   .WithOrigins("http://0.0.0.0:3000")
   .WithOrigins("http://0.0.0.0")
   .AllowAnyMethod()
   .AllowAnyHeader()
   .AllowCredentials()
   );

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   
}

app.UseAuthentication();

app.UseRouting();

app.UseExceptionHandler(new ExceptionHandlerOptions
{
    ExceptionHandler = (c) =>
    {

        app.Logger.LogError($"Request excepetion.");

        return Task.CompletedTask;
    }
});


app.UseAuthorization();

app.MapControllers();


app.Run();



void ConfigureServices(IServiceCollection services)
{

    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("JHKFfsdf7dsf9nsdkf9340nsfdk84"));

    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "My API",
            Version = "v1"
        });
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Query,
            Description = "Please insert JWT with Bearer into field",
            Name = "access_token",
            Type = SecuritySchemeType.ApiKey
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
                new string[] { }
            }
        });
    });

    var db = builder.Configuration.GetValue<string>("Database");

    services.AddDbContext<StoreDatabaseContext>(options => options.UseNpgsql(db));


    services
       .AddIdentity<User, UserRole>(c =>
       {
           c.Password.RequiredLength = 3;
           c.Password.RequireDigit = false;
           c.Password.RequireNonAlphanumeric = false;
           c.Password.RequireLowercase = false;
           c.Password.RequireUppercase = false;
           c.User.RequireUniqueEmail = false;
           c.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
           c.Lockout.AllowedForNewUsers = true;
           c.Lockout.MaxFailedAccessAttempts = 3;
       })
       .AddEntityFrameworkStores<StoreDatabaseContext>()
       .AddDefaultTokenProviders();

    services.AddAuthentication(o =>
    {
        o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        o.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
        o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(c =>
    {
        c.SaveToken = true;
        c.RequireHttpsMetadata = false;
        c.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidIssuer = "oldstore",
            ValidateAudience = true,
            ValidAudience = "backend",
            RequireSignedTokens = true,
            SaveSigninToken = true,
            IssuerSigningKey = securityKey
        };


        // save the original OnMessageReceived event
        var originalOnMessageReceived = c.Events?.OnMessageReceived;


        c.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;

                return Task.CompletedTask;
            },

            OnForbidden = context =>
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;

                return Task.CompletedTask;
            },

            OnMessageReceived = async context =>
            {
                if (originalOnMessageReceived != null)
                {
                    await originalOnMessageReceived(context).ConfigureAwait(false);
                }

                if (string.IsNullOrEmpty(context.Token))
                {
                    // attempt to read the access token from the query string
                    var accessToken = context.Request.Query["access_token"];

                    context.Token = accessToken;
                }
            },

            OnTokenValidated = async (context) =>
            {
                var manager = context.HttpContext.RequestServices.GetRequiredService<AccountsManager>();

                var id = context.Principal.Claims.First(i => i.Type == "user_id").Value;

                var user = await manager.GetUserAsync(int.Parse(id)).ConfigureAwait(false);


                if (user == null)
                {
                    context.Fail("Wrong token.");
                }
                else if (user.LockoutEnd != null && user.LockoutEnd.Value > DateTime.UtcNow)
                {
                    context.Fail("Account locked");
                }
            }
        };
    });




    services.AddAuthorization();
    services.AddControllers();
    services.AddCors();


    //managers
    services.AddTransient<AccountsManager>();
    services.AddTransient<GamesManager>();


    //services

    services.AddSingleton<IdGeneratorService>();
    services.AddTransient<GamesService>();
    services.AddTransient<CatalogsService>();
}

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebApi.Infra;
using WebApi.Model;
using WebApi.Repositories.Interfaces;
using WebApi.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApi;
using Microsoft.Extensions.Logging;
using WebApi.ViewObjects;

var builder = WebApplication.CreateBuilder(args);

// Configurando a conexão com o banco de dados
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configurando o Identity
builder.Services.AddIdentity<Usuario, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Adicionando as controllers
builder.Services.AddControllers();

// Configurando o Swagger para permitir autenticação com JWT
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Softlab - Seleção 2024.1",
        Description = "API para a seleção Softlab."
    });

    // Adiciona suporte para JWT
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Insira o token JWT neste formato: Bearer {seu token}",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

// Injeção de dependência para repositório
builder.Services.AddScoped<IAutenticacaoRepositorio, AutenticacaoRepositorio>();

// Configurando autenticação com JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Logging.AddFile("logs/app-{Date}.txt");

// Construindo o app
var app = builder.Build();

// Configurando o Swagger para o ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI SoftLab v1");
    });
}

// Middleware padrão da aplicação
app.UseHttpsRedirection();
app.UseMiddleware<LoggingMiddleware>();

app.MapGet("/", () =>
{
    var candidato = new CandidatoVo
    {
        Nome = "Matheus Freire de Oliveira",
        UrlLinkedin = "https://www.linkedin.com/in/matheus-freire-a322b5215/",
        UrlGitHub = "https://github.com/ChuckTheus"
    };

    return Results.Ok(candidato);
});

// Autenticação e autorização
app.UseAuthentication();
app.UseAuthorization();

// Mapeando as controllers
app.MapControllers();

// Executando a migração do banco de dados e populando com dados iniciais
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        context.Database.Migrate();
        SeedData.InitializeAsync(services).Wait();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Um erro ocorreu durante a inicialização dos dados.");
    }
}

// Executando a aplicação
app.Run();

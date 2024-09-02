using Unirota.Example.Api.Data;
using Unirota.Example.Api.Produtos;
using Unirota.Example.Api.Usuarios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//configura o DbContext
builder.Services.AddScoped<ApplicationDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Configuração rota de Usuario
app.AdicionarRotasDeUsuario();
app.AdicionarRotasDeProduto();

app.Run();

namespace Unirota.Example.Api.Cep.Dtos;

public record CriarEnderecoRequest(string Cep);
using Microsoft.EntityFrameworkCore;
using Unirota.Example.Api.Usuarios;

namespace Unirota.Example.Api.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<endereco> enderecos {get;set;}
    //TODO: Criar mais um DbSet de uma entidade qualquer, e seu CRUD simples
    //lembre de executar o dotnet ef migrations add "nomeDaMigration"
    //lembre de executar o dotnet ef database update para que a migration seja executada

    //Define como o DbContext irá se comportar; aqui iremos definir a conexão com o banco.
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=unirota.sqlite");

        base.OnConfiguring(optionsBuilder);
    }
}

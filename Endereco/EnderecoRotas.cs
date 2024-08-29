using Microsoft.EntityFrameworkCore;
using Unirota.Example.Api.Data;
using Unirota.Example.Api.Endereco.Dtos;

namespace Unirota.Example.Api.Endereco;

public static class EnderecoRotas
{
    public static void AdicionarRotasDeEndereco(this WebApplication app)
    {
        var rotasEndereco = app.MapGroup("api/endereco");


        //criar usuario
        rotasEndereco.MapPost("", async (CriarEnderecoRequest request, ApplicationDbContext context) =>
        {
            var enderecoExiste = await context.Endereco.AnyAsync(Endereco => endereco.Nome.Equals(request.Cep));

            if (enderecoExiste) return Results.Conflict("Já existe endereco cadastrado com este nome");

            var novoEndereco = new Endereco(request.Cep);

            await context.Endereco.AddAsync(novoEndereco);
            await context.SaveChangesAsync();

            return Results.Ok(novoEndereco);
        });

        //retornar todos usuarios
        //TODO: retornar somente usuarios ativos
        rotasEndereco.MapGet("", async (ApplicationDbContext context) =>
        {
            var endereco = await context.Endereco.ToListAsync();

            return Results.Ok(endereco);
        });
          rotasEndereco.MapGet("", async (ApplicationDbContext context) =>
        {
            var endereco = await context.Endereco.ToListAsync();

            return Results.Ok(Endereco);
        });
// Rota para retornar todos usuários ativos
        rotasEndereco.MapGet("ativos", async (ApplicationDbContext context) =>
       {
    var enderecoAtivos = await context.Endereco
        .Where(endereco => endereco.Ativo)
        .ToListAsync();

         return Results.Ok(enderecoAtivos);
     });

        //TODO: Corrigir detalhe que esta faltando (tem na doc)
        rotasEndereco.MapPut("{id:int}", async (int id, AlterarEnderecoRequest request, ApplicationDbContext context) =>
        {
            var endereco = await context.Endereco.SingleOrDefaultAsync(endereco => endereco.Id.Equals(id));

            if (endereco == null) return Results.NotFound();

            endereco.AtualizarCep(request.Cep);

            return Results.Ok(cep);
        });

        rotasEndereco.MapDelete("{id:int}", async (int id, ApplicationDbContext context) =>
        {
            var endereco= await context.Endereco.SingleOrDefaultAsync(endereco => endereco.Id.Equals(id));

            if (endereco) == null) return Results.NotFound();

            endereco.Desativar();

            await context.SaveChangesAsync();/// para salvar alterações no banco 

            return Results.Ok();
        });

        rotasUsuarios.MapGet("{id:int}", async (int id, ApplicationDbContext context)=>
        { 
            var endereco= await context.Endereco.SingleOrDefaultAsync(endereco => endereco.Id.Equals(id));

            if (endereco) == null) return Results.NotFound();
            
            return Results.Ok(endereco);

        });
        //TODO: Implementar GetById de usuário
    }
}

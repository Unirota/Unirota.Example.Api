using Microsoft.EntityFrameworkCore;
using Unirota.Example.Api.Data;
using Unirota.Example.Api.Usuarios.Dtos;

namespace Unirota.Example.Api.Usuarios;

public static class UsuarioRotas
{
    public static void AdicionarRotasDeUsuario(this WebApplication app)
    {
        var rotasUsuarios = app.MapGroup("api/usuarios");


        //criar usuario
        rotasUsuarios.MapPost("", async (CriarUsuarioRequest request, ApplicationDbContext context) =>
        {
            var usuarioExiste = await context.Usuarios.AnyAsync(usuario => usuario.Nome.Equals(request.Nome));

            if (usuarioExiste) return Results.Conflict("Já existe usuário cadastrado com este nome");

            var novoUsuario = new Usuario(request.Nome);

            await context.Usuarios.AddAsync(novoUsuario);
            await context.SaveChangesAsync();

            return Results.Ok(novoUsuario);
        });

        //retornar todos usuarios
        //TODO: retornar somente usuarios ativos
        rotasUsuarios.MapGet("", async (ApplicationDbContext context) =>
        {
            var usuarios = await context.Usuarios.ToListAsync();

            return Results.Ok(usuarios);
        });

        //Atualizar usuario
        //TODO: Corrigir detalhe que esta faltando (tem na doc)
        //dica: não esta salvando alteração no banco
        rotasUsuarios.MapPut("{id:int}", async (int id, AlterarUsuarioRequest request, ApplicationDbContext context) =>
        {
            var usuario = await context.Usuarios.SingleOrDefaultAsync(usuario => usuario.Id.Equals(id));

            if (usuario == null) return Results.NotFound();

            usuario.AtualizarNome(request.Nome);

            return Results.Ok(usuario);
        });

        rotasUsuarios.MapDelete("{id:int}", async (int id, ApplicationDbContext context) =>
        {
            var usuario = await context.Usuarios.SingleOrDefaultAsync(usuario => usuario.Id.Equals(id));

            if (usuario == null) return Results.NotFound();

            usuario.Desativar();

            await context.SaveChangesAsync();

            return Results.Ok();
        });

        //TODO: Implementar GetById de usuário
    }
}

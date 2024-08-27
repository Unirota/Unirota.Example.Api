using Microsoft.EntityFrameworkCore;
using Unirota.Example.Api.Data;
using Unirota.Example.Api.Usuarios.Dtos;

namespace Unirota.Example.Api.Usuarios;

public static class UsuarioRotas
{
    public static void AdicionarRotasDeUsuario(this WebApplication app)
    {
        var rotasUsuarios = app.MapGroup("api/usuarios");



        rotasUsuarios.MapPost("", async (CriarUsuarioRequest request, ApplicationDbContext context) =>
        {
            var usuarioExiste = await context.Usuarios.AnyAsync(usuario => usuario.Nome.Equals(request.Nome));

            if (usuarioExiste) return Results.Conflict("Já existe usuário cadastrado com este nome");

            var novoUsuario = new Usuario(request.Nome);

            await context.Usuarios.AddAsync(novoUsuario);
            await context.SaveChangesAsync();

            return Results.Ok(novoUsuario);
        });

        rotasUsuarios.MapGet("", async (ApplicationDbContext context) =>
        {
            var usuarios = await context.Usuarios.ToListAsync();

            return Results.Ok(usuarios);
        });


        rotasUsuarios.MapGet("/ativos", async (ApplicationDbContext context) =>
        {
            var usuariosAtivos = await context.Usuarios.Where(usuario => usuario.Ativo).ToListAsync();

            return Results.Ok(usuariosAtivos);
        });


        //Atualizar usuario
        rotasUsuarios.MapPut("{id:int}", async 
        (int id, AlterarUsuarioRequest request, ApplicationDbContext context) =>
        {
            var usuario = await context.Usuarios.SingleOrDefaultAsync
            (usuario => usuario.Id.Equals(id));

            if (usuario == null) return Results.NotFound();

            usuario.AtualizarNome(request.Nome);

            await context.SaveChangesAsync();

            return Results.Ok(usuario);
        });


        rotasUsuarios.MapDelete("{id:int}", async (int id, ApplicationDbContext context) =>
        {
            var usuario = await context.Usuarios.SingleOrDefaultAsync(usuario => usuario.Id.Equals(id));

            if (usuario == null) return Results.NotFound();

            usuario.Desativar();

            context.Remove(usuario);

            return Results.Ok();
        });


        rotasUsuarios.MapGet("/{id:int}", async (int id, ApplicationDbContext context) =>
        {
            var usuarios = await context.Usuarios.SingleOrDefaultAsync(usuario => usuario.Id.Equals(id));

            if (usuarios == null) return Results.NotFound("Usuário não encontrado");

            return Results.Ok(usuarios);
        });
    }
}


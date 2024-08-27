using Microsoft.EntityFrameworkCore;
using Unirota.Example.Api.Data;
using Unirota.Example.Api.Produtos.Dtos;

namespace Unirota.Example.Api.Produtos;

public static class ProdutoRotas
{
    public static void AdicionarRotasDeProduto(this WebApplication app)
    {
        var rotasProdutos = app.MapGroup("api/produtos");

        rotasProdutos.MapPost("", async (CriarProdutoRequest request, ApplicationDbContext context) =>
        {
            var produtoExiste = await context.Produtos.AnyAsync(produto => produto.Nome.Equals(request.Nome));

            if (produtoExiste) return Results.Conflict("Já existe produto cadastrado com este nome");

            var novoProduto = new Produto(request.Nome);

            await context.Produtos.AddAsync(novoProduto);
            await context.SaveChangesAsync();

            return Results.Ok(novoProduto);
        });

        rotasProdutos.MapGet("", async (ApplicationDbContext context) =>
        {
            var produtos = await context.Produtos.ToListAsync();

            return Results.Ok(produtos);
        });

        rotasProdutos.MapPut("{id:int}", async 
        (int id, AlterarProdutoRequest request, ApplicationDbContext context) =>
        {
            var produto = await context.Produtos
            .SingleOrDefaultAsync(produto => produto.Id.Equals(id));

            if (produto == null) return Results.NotFound();

            produto.AtualizarNome(request.Nome);

            await context.SaveChangesAsync();

            return Results.Ok(produto);
        });

        rotasProdutos.MapDelete("{id:int}", async (int id, ApplicationDbContext context) =>
        {
            var produto = await context.Produtos
            .SingleOrDefaultAsync(produto => produto.Id.Equals(id));

            if (produto == null) return Results.NotFound();

            context.Remove(produto);

            await context.SaveChangesAsync();

            return Results.Ok();
        });

        rotasProdutos.MapGet("/{id:int}", async (int id, ApplicationDbContext context) =>
        {
            var produtos = await context.Produtos.SingleOrDefaultAsync(produto => produto.Id.Equals(id));

            if (produtos == null) return Results.NotFound("Produto não encontrado");

            return Results.Ok(produtos);
        });
    }
}
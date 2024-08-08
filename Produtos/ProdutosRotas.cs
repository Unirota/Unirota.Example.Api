using Microsoft.EntityFrameworkCore;
using Unirota.Example.Api.Data;
using Unirota.Example.Api.Produtos.Dtos;

namespace Unirota.Example.Api.Produtos;
public static class ProdutoRotas
{
    public static void AdicionarRotasDeProdutos(this WebApplication app)
    {
        var rotasProdutos = app.MapGroup("api/produtos");


        // Criar Produtos
        rotasProdutos.MapPost("", async (CriarProdutoRequest request, ApplicationDbContext context) => 
        {
            var produtoExistente = await context.Produtos.AnyAsync(Produto => Produto.Nome.Equals(request.Nome));
            if (produtoExistente)
                return Results.Conflict("Já existe produto cadastrado com este nome");
            
            var novoProduto = new Produto(request.Nome, request.Preco);

            await context.Produtos.AddAsync(novoProduto);
            await context.SaveChangesAsync();

            return Results.Ok(novoProduto);
        });

        // Retornar todos os Produtos
        rotasProdutos.MapGet("", async (ApplicationDbContext context) => 
        {
            var produtos = await context.Produtos.ToListAsync();

            return Results.Ok(produtos);
        });

        // Atualizar Produtos
        rotasProdutos.MapPut("{id: int}", async (int id, AlterarProdutoRequest request, ApplicationDbContext context) => 
        {
            var produto = await context.Produtos.SingleOrDefaultAsync(produto => produto.Id.Equals(id));

            if (produto == null) 
                return Results.NotFound();

            produto.AtualizarNome(request.Nome);
            produto.AtualizarPreco(request.Preco);

            context.Produtos.Update(produto);
            await context.SaveChangesAsync();

            return Results.Ok(produto);
        });

        rotasProdutos.MapDelete("{id:int}", async (int id, ApplicationDbContext context) =>
        {
            var produto = await context.Produtos.SingleOrDefaultAsync(produto => produto.Id.Equals(id));

            if (produto == null) 
                return Results.NotFound();

            context.Produtos.Remove(produto);
            await context.SaveChangesAsync();

            return Results.Ok();
        });

        // GetById de produto
        rotasProdutos.MapGet("{id: int}", async (int id, ApplicationDbContext context) => {
            var produto = await context.Produtos.FindAsync(id);

            if (produto == null) 
                return Results.NotFound();

            return Results.Ok(produto);
        });
    }
    
}


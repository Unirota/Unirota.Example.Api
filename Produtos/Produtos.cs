using Unirota.Example.Api.Produtos;
namespace Unirota.Example.Api.Produtos;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; private set; } // setter privado, para que ninguém fora da classe consiga alterá-lo
    public decimal Preco { get; private set; }

    public Produto(string nome, decimal preco)
    {
        Nome = nome;
        Preco = preco;
    }

    public void AtualizarNome(string nome)
    {
        Nome = nome;
    }

    public void AtualizarPreco(decimal preco)
    {
        Preco = preco;
    }
}

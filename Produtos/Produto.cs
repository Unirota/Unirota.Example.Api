namespace Unirota.Example.Api.Produtos;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; private set; }
    public int Quantidade { get; private set; }

    public Produto(string nome, int quantidade)
    {
        Nome = nome;
        Quantidade = quantidade;
    }

    public void AtualizarNome(string nome)
    {
        Nome = nome;
    }

    public void Desativar()
    {
        Quantidade = 0;
    }
}
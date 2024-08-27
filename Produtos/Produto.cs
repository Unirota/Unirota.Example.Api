namespace Unirota.Example.Api.Produtos;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; private set; }
    public int Quantidade { get; private set; }

    public Produto(string nome)
    {
        Nome = nome;
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
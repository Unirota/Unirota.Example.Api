namespace Unirota.Example.Api.Usuarios;

public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; private set; } // setter privado, para que ninguém fora da classe consiga alterá-lo
    public bool Ativo { get; private set; }

    public Usuario(string nome)
    {
        Nome = nome;
        Ativo = true;
    }

    public void AtualizarNome(string nome)
    {
        Nome = nome;
    }

    public void Desativar()
    {
        Ativo = false;
    }
}
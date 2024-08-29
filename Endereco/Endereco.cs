namespace Unirota.Example.Api.Usuarios;

public class Endereco
{
    public int Id { get; set; }
    public int Cep { get; private set; } 
    public string Rua { get ; private set;}
    public int Numero {get; private set; }
    public bool Ativo { get; private set; }


   public Endereco(int cep)
        {
            Cep = cep;
            Ativo = true;
        }

        public void AtualizarCep(int cep)
        {
            Cep = cep;
        }
}

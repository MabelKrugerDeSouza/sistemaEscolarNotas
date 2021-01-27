
namespace sistemaEscolarNotas.Application.Model
{
    public abstract class AlunoModelBase
    {
        public int Id { get; set; }
        public string NomeAluno { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public bool Deletado { get; set; }
    }
}

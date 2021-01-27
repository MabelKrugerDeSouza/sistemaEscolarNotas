using sistemaEscolarNotas.Domain.Entities;

namespace sistemaEscolarNotas.Domain
{
    public class AlunoEntity : BaseEntity
    {
        public string NomeAluno { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }

        public AlunoEntity()
        {
        }

        //public void Update
    }
}

using sistemaEscolarNotas.Domain;

namespace sistemaEscolarNotas.Application.Model
{
    public class AlunoResponseModel : AlunoModelBase
    {
        public AlunoResponseModel(AlunoEntity aluno)
        {
            NomeAluno = aluno.NomeAluno;
            Email = aluno.Email;
            CPF = aluno.CPF;
            Telefone = aluno.Telefone;
            Id = aluno.Id;
        }
    }
}

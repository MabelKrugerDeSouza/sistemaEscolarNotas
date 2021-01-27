using FluentValidation;
using sistemaEscolarNotas.Domain.Entities;
using sistemaEscolarNotas.Domain.Validation;

namespace sistemaEscolarNotas.Domain
{
    public class AlunoEntity : BaseEntity
    {
        public string NomeAluno { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }

        private AlunoEntity()
        {
        }

        public AlunoEntity(string nome, string email, string cpf, string telefone)
        {
            NomeAluno = nome;
            Email = email;
            CPF = cpf;
            Telefone = telefone;

            Validate();
        }

        public void Update(string nome, string email, string cpf, string telefone)
        {
            NomeAluno = nome;
            Email = email;
            CPF = cpf;
            Telefone = telefone;

            Validate();
        }

        public void Delete()
        {
            Deletado = true;
        }

        public void Validate()
        {
            var alunoValidator = new AlunoValidator();
            alunoValidator.ValidateAndThrow(this);
        }
    }
}

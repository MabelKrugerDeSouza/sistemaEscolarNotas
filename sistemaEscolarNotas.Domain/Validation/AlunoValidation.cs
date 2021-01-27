using FluentValidation;
using System;
using System.Text.RegularExpressions;

namespace sistemaEscolarNotas.Domain.Validation
{
    public class AlunoValidator : AbstractValidator<AlunoEntity>
    {
        public AlunoValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(a => a.NomeAluno)
                .NotNull().WithMessage("Nome de aluno está nulo.")
                .MinimumLength(3).WithMessage("Nome do aluno precisa no minimo 3 caracteres.")
                .MaximumLength(50).WithMessage("Nome do aluno não pode conter mais de 50 caracteres.");

            RuleFor(a => a.Email)
                .NotNull().WithMessage("Email não pode ser nulo.")
                .EmailAddress().WithMessage("Email incorreto. EX:exemplo@gmail.com.")
                .MaximumLength(60).WithMessage("Email não pode conter mais de 60 caracteres.");

            RuleFor(a => a.Telefone)
                .NotNull().WithMessage("Numero de telefone está nulo.")
                .MinimumLength(10).WithMessage("Telefone deve conter exatamente 10 caracteres.")
                .MaximumLength(11).WithMessage("Telefone deve conter exatamente 11 caracteres.");

            RuleFor(f => f.CPF)
               .NotNull().WithMessage("CPF não pode ser nulo.")
               .NotEmpty().WithMessage("CPF não pode estar vazio.")
               .Must(ValidateCpf).WithMessage("CPF incorreto.");
        }

        private bool ValidateCpf(string cpf)
        {
            if (cpf == null)
                throw new ValidationException("CPF é necessario.");

            string digito1, digito2, cpfSemDigito;

            cpf = Regex.Replace(cpf, "[^0-9]", string.Empty);

            if (cpf.Length != 11)
                return false;

            cpfSemDigito = cpf.Substring(0, 9);

            digito1 = Modulo11(cpfSemDigito, 0);
            cpfSemDigito = cpfSemDigito + digito1;
            digito2 = digito1 + Modulo11(cpfSemDigito, 1);

            return cpf.EndsWith(digito2);
        }

        private string Modulo11(string cpf, int posicao)
        {
            int soma, resto;
            soma = 0;
            string multiplicador = "111098765432";

            for (int i = 0; i < cpf.Length; i++)
                soma += int.Parse(cpf[i].ToString()) * Convert.ToInt32(multiplicador.Substring(i + 1 - posicao, 1));

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            return resto.ToString();
        }
    }
}
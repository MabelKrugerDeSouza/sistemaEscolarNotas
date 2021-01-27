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
               .Must(ValidateCPF).WithMessage("CPF incorreto.");
        }

        private bool ValidateCPF(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
    }
}
using FluentValidation;
using sistemaEscolarNotas.Domain.Entities;

namespace sistemaEscolarNotas.Domain.Validation
{
    public class ProvaValidator : AbstractValidator<ProvaEntity>
    {
        public ProvaValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(p => p.DescricaoMultiEscolha)
                .NotNull().WithMessage("Descrição da múltipla escolha está vazia.")
                .MinimumLength(3).WithMessage("Descrição da múltipla escolha não pode conter menos que 3 caracteres.")
                .MaximumLength(120).WithMessage("Descrição da múltipla escolha não ultrapassar de 120 caracteres.");

            RuleFor(p => p.DescricaoQuestao)
                .NotNull().WithMessage("Descrição da questão escolha está vazia.")
                .MinimumLength(10).WithMessage("Descrição da questão não pode conter menos que 10 caracteres.")
                .MaximumLength(400).WithMessage("Descrição da questão escolha não ultrapassar de 400 caracteres.");
        }
    }
}

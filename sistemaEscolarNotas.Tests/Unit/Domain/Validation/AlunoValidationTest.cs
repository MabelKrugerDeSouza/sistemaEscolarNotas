using FluentAssertions;
using FluentValidation;
using NSubstitute;
using sistemaEscolarNotas.Application;
using sistemaEscolarNotas.Application.Model;
using sistemaEscolarNotas.Application.Service;
using sistemaEscolarNotas.Domain.Interface;
using System;
using Xunit;

namespace sistemaEscolarNotas.Tests.Unit.Domain.Validation
{
    public class AlunoValidationTest
    {
        private readonly IAlunoService _alunoService;
        private readonly IAlunoRepository _alunoRepository;

        public AlunoValidationTest()
        {
            _alunoRepository = Substitute.For<IAlunoRepository>();
            _alunoService = new AlunoService(_alunoRepository);
        }

        [Theory]
        [InlineData(51)]
        [InlineData(2)]
        [InlineData(null)]
        public void Validar_NomeAluno_Caracteres(int? qtdCaracteres)
        {
            string nomeAluno = "";
            if (qtdCaracteres != null)
            {
                nomeAluno = new string('a', Convert.ToInt32(qtdCaracteres));
            }

            var aluno = new AlunoRequestModel()
            {
                NomeAluno = nomeAluno,
                Id = 0,
                CPF = "099.536.159-26",
                Email = "mario@gmail.com",
                Telefone = "47991085345"
            };

            var ex = Assert.ThrowsAsync<ValidationException>(async () => await _alunoService.Create(aluno));
            if (qtdCaracteres == null)
            {
                ex.Result.Message.Should().Contain("Nome de aluno está nulo.");
            }
            else if (qtdCaracteres == 51)
            {
                ex.Result.Message.Should().Contain("Nome do aluno deve conter no máximo 50 caracteres.");
            }
            else if (qtdCaracteres == 2)
            {
                ex.Result.Message.Should().Contain("Nome do aluno precisa no minimo 3 caracteres.");
            }
        }

        [Theory]
        [InlineData("00000/0001-17")]
        [InlineData("x")]
        public void Validar_CPF_Caracteres(string cpfTeste)
        {
            var cpf = "";
            if (cpfTeste != "x")
            {
                cpf = cpfTeste;
            }

            var aluno = new AlunoRequestModel()
            {
                NomeAluno = "Mario",
                Id = 0,
                CPF = cpf,
                Email = "mario@gmail.com",
                Telefone = "47991085345"
            };

            var ex = Assert.ThrowsAsync<ValidationException>(async () => await _alunoService.Create(aluno));
            if (cpf == "x")
            {
                ex.Result.Message.Should().Contain("CPF não pode estar vazio.");
            }
            else if (cpf == "00000/0001-17")
            {
                ex.Result.Message.Should().Contain("CPF incorreto.");
            }
        }

        [Theory]
        [InlineData(9)]
        [InlineData(12)]
        [InlineData(null)]
        public void Validar_Telefone_Caracteres(int? qtdCaracteres)
        {
            string telefone = "";
            if (qtdCaracteres != null)
            {
                telefone = new string('t', Convert.ToInt32(qtdCaracteres));
            }

            var aluno = new AlunoRequestModel()
            {
                NomeAluno = "Mario",
                Id = 0,
                CPF = "099.536.159-26",
                Email = "mario@gmail.com",
                Telefone = telefone
            };

            var ex = Assert.ThrowsAsync<ValidationException>(async () => await _alunoService.Create(aluno));
            if (qtdCaracteres == null)
            {
                ex.Result.Message.Should().Contain("Numero de telefone está nulo.");
            }
            else if (qtdCaracteres == 9)
            {
                ex.Result.Message.Should().Contain("Telefone deve conter exatamente 10 caracteres.");
            }
            else if (qtdCaracteres == 12)
            {
                ex.Result.Message.Should().Contain("Telefone deve conter exatamente 11 caracteres.");
            }
        }

        [Theory]
        [InlineData("mabelksouza.com")]
        [InlineData("x")]
        public void Validar_Email_Caracteres(string emailTeste)
        {
            string email = "";
            if (emailTeste != "x")
            {
                email = emailTeste;
            }

            var aluno = new AlunoRequestModel()
            {
                NomeAluno = "Mario",
                Id = 0,
                CPF = "099.536.159-26",
                Email = email,
                Telefone = "47991085945"
            };

            var ex = Assert.ThrowsAsync<ValidationException>(async () => await _alunoService.Create(aluno));
            if (emailTeste == "x")
            {
                ex.Result.Message.Should().Contain("Email não pode ser nulo.");
            }
            else if (emailTeste == "mabelksouza.com")
            {
                ex.Result.Message.Should().Contain("Email incorreto. EX:exemplo@gmail.com.");
            }
        }
    }
}

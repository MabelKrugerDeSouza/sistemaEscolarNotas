using FluentAssertions;
using NSubstitute;
using sistemaEscolarNotas.Application;
using sistemaEscolarNotas.Application.Model;
using sistemaEscolarNotas.Application.Service;
using sistemaEscolarNotas.Domain;
using sistemaEscolarNotas.Domain.Interface;
using sistemaEscolarNotas.Tests.Builders;
using System;
using System.Threading.Tasks;
using Xunit;

namespace sistemaEscolarNotas.Tests.Unit.Application
{
    public class AlunoServiceTest
    {

        private readonly IAlunoService _alunoService;
        private readonly IAlunoRepository _alunoRepository;

        public AlunoServiceTest()
        {
            _alunoRepository = Substitute.For<IAlunoRepository>();
            _alunoService = new AlunoService(_alunoRepository);
        }

        [Fact]
        public async Task Salvar_Create()
        {
            var alunoRequest = new AlunoRequestModel()
            {
                NomeAluno = "Mario",
                Email = "mario@gmail.com",
                CPF = "099.536.159-26",
                Telefone = "47991085945",
                Id = 1
            };

            await _alunoService.Create(alunoRequest);
            await _alunoRepository.Received(1).Create(Arg.Any<AlunoEntity>());
        } 

        [Fact]
        public async Task Estourar_Excecao_VerificarSeJaExisteAluno_Create()
        {
            var alunoRequest = new AlunoRequestModel()
            {
                NomeAluno = "Mario",
                Email = "mario@gmail.com",
                CPF = "099.536.159-26",
                Telefone = "47991085945",
                Id = 1
            };

            _alunoRepository.VerificarSeJaExisteAluno(alunoRequest.CPF).Returns(true);
            var ex = await Record.ExceptionAsync(() => _alunoService.Create(alunoRequest));
            ex.Should().BeOfType<ArgumentException>();
            ex.Message.Should().Be("Aluno já existe.");
        }

        [Fact]
        public async Task Pegar_GetById()
        {
            var idAluno = 4;
            var aluno = new AlunoBuilderTest()
               .ComId(idAluno)
               .ComNomeAluno("Arthur")
               .ComEmail("arthur@gmail.com")
               .ComCpf("099.536.159-26")
               .ComTelefone("47991085945")
               .Construir();

            _alunoRepository.GetById(idAluno).Returns(aluno);
            var alunoRetornado = await _alunoService.GetById(idAluno);
            alunoRetornado.Should().NotBeNull();
        }

        [Fact]
        public async Task Estourar_Excecao_GetById()
        {
            var idAluno = 1;
            var alunoRequest = new AlunoRequestModel()
            {
                NomeAluno = "Mario",
                Email = "mario@gmail.com",
                CPF = "099.536.159-26",
                Telefone = "47991085945",
                Id = idAluno
            };

            var ex = await Record.ExceptionAsync(() => _alunoService.GetById(idAluno));
            ex.Should().BeOfType<ArgumentException>();
            ex.Message.Should().Be("Id de aluno inexistente.");
        }

        [Fact]
        public async Task Categoria_Deletar()
        {
            var idAluno = 1;
            var aluno = new AlunoBuilderTest()
               .ComId(idAluno)
               .ComNomeAluno("Arthur")
               .ComEmail("arthur@gmail.com")
               .ComCpf("099.536.159-26")
               .ComTelefone("47991085945")
               .Construir();

            _alunoRepository.GetById(idAluno).Returns(aluno);
            await _alunoService.Delete(idAluno);
            await _alunoRepository.Received(1).Delete(Arg.Any<AlunoEntity>());
        }

        [Fact]
        public async Task Estourar_Excecao_Deletar()
        {
            var idAluno = 1;
            var alunoRequest = new AlunoRequestModel()
            {
                NomeAluno = "Mario",
                Email = "mario@gmail.com",
                CPF = "099.536.159-26",
                Telefone = "47991085945",
                Id = idAluno
            };

            var ex = await Record.ExceptionAsync(() => _alunoService.Delete(idAluno));
            ex.Should().BeOfType<ArgumentException>();
            ex.Message.Should().Be("Id inexistente.");
        }

        [Fact]
        public async Task Atualizar_Update()
        {
            var idAluno = 1;
            var alunoRequest = new AlunoRequestModel()
            {
                NomeAluno = "Mario",
                Email = "mario@gmail.com",
                CPF = "099.536.159-26",
                Telefone = "47991085945",
                Id = idAluno
            };

            var aluno = new AlunoBuilderTest()
               .ComId(idAluno)
               .ComNomeAluno("Arthur")
               .ComEmail("arthur@gmail.com")
               .ComCpf("099.536.159-26")
               .ComTelefone("47991085945")
               .Construir();

            _alunoRepository.GetById(idAluno).Returns(aluno);
            _alunoRepository.VerificarSeEmailJaExiste(aluno.Email, aluno.Id).Returns(false);
            var alunoRetornado = await _alunoService.Update(idAluno, alunoRequest);

            await _alunoRepository.Received(1).Update(Arg.Is<AlunoEntity>(args =>
            args.NomeAluno == alunoRequest.NomeAluno
            && args.Email == alunoRequest.Email
            && args.Id == alunoRequest.Id
            && args.CPF == alunoRequest.CPF
            && args.Telefone == alunoRequest.Telefone
            ));
        }

        [Fact]
        public async Task Estourar_Excesao_VerificarSeEmailJaExiste_Update()
        {
            var idAluno = 1;
            var alunoRequest = new AlunoRequestModel()
            {
                NomeAluno = "Mario",
                Email = "mario@gmail.com",
                CPF = "099.536.159-26",
                Telefone = "47991085945",
                Id = idAluno
            };

            var aluno = new AlunoBuilderTest()
               .ComId(idAluno)
               .ComNomeAluno("Arthur")
               .ComEmail("mario@gmail.com")
               .ComCpf("099.536.159-26")
               .ComTelefone("47991085945")
               .Construir();

            _alunoRepository.GetById(idAluno).Returns(aluno);
            _alunoRepository.VerificarSeEmailJaExiste(aluno.Email, aluno.Id).Returns(true);

            var ex = await Record.ExceptionAsync(() => _alunoService.Update(idAluno, alunoRequest));
            ex.Should().BeOfType<ArgumentException>();
            ex.Message.Should().Be("Email já existente.");
        }

        [Fact]
        public async Task Estourar_Excecao_IdNulo_Update()
        {
            var idAluno = 1;
            var alunoRequest = new AlunoRequestModel()
            {
                NomeAluno = "Mario",
                Email = "mario@gmail.com",
                CPF = "099.536.159-26",
                Telefone = "47991085945",
                Id = idAluno
            };

            var aluno = new AlunoBuilderTest()
               .ComId(idAluno)
               .ComNomeAluno("Arthur")
               .ComEmail("arthur@gmail.com")
               .ComCpf("099.536.159-26")
               .ComTelefone("47991085945")
               .Construir();

            var ex = await Record.ExceptionAsync(() => _alunoService.Update(idAluno, alunoRequest));
            ex.Should().BeOfType<ArgumentException>();
            ex.Message.Should().Be("Id do aluno inválido.");
        }
    }
}

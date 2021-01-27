using sistemaEscolarNotas.Tests.Builders;
using FluentAssertions;
using Xunit;

namespace sistemaEscolarNotas.Tests
{
    public class AlunoTest
    {
        [Fact]
        public void Pegar_dados_aluno()
        {   
            var aluno = new AlunoBuilderTest()
                .ComId(1)
                .ComNomeAluno("Arthur")
                .ComEmail("arthur@gmail.com")
                .ComCpf("099.536.159-26")
                .ComTelefone("47991085945")
                .Construir();

            aluno.Id.Should().Be(1);
            aluno.NomeAluno.Should().Be("Arthur");
            aluno.Email.Should().Be("arthur@gmail.com");
            aluno.CPF.Should().Be("099.536.159-26");
            aluno.Telefone.Should().Be("47991085945");
        }

        [Fact]
        public void Deletar_Aluno()
        {
            var aluno = new AlunoBuilderTest()
                .ComId(1)
                .ComNomeAluno("Arthur")
                .ComEmail("arthur@gmail.com")
                .ComCpf("099.536.159-26")
                .ComTelefone("47991085945")
                .Construir();

            aluno.Delete();
            aluno.Deletado.Should().BeTrue();
        }

        [Fact]
        public void Atualizar_Fornecedor()
        {
            var aluno = new AlunoBuilderTest()
               .ComId(1)
               .ComNomeAluno("Arthur")
               .ComEmail("arthur@gmail.com")
               .ComCpf("099.536.159-26")
               .ComTelefone("47991085945")
               .Construir();

            aluno.Update("Mario", "mario@gmail.com", "091.377.049-31", "4733990785");

            aluno.NomeAluno.Should().Be("Mario");
            aluno.Email.Should().Be("mario@gmail.com");
            aluno.CPF.Should().Be("091.377.049-31");
            aluno.Telefone.Should().Be("4733990785");
        }
    }
}

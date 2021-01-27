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
    }
}

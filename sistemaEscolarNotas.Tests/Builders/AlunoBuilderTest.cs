using sistemaEscolarNotas.Domain;

namespace sistemaEscolarNotas.Tests.Builders
{
    public class AlunoBuilderTest
    {
        private int _id;
        private string _nomeAluno;
        private string _email;
        private string _cpf;
        private string _telefone;
        private bool _deletado;

        public AlunoEntity Construir()
        {
            return new AlunoEntity(_nomeAluno, _email, _cpf, _telefone)
            {
                Id = _id
            };
        }

        public AlunoBuilderTest ComNomeAluno(string nomeAluno)
        {
            _nomeAluno = nomeAluno;
            return this;
        }

        public AlunoBuilderTest ComEmail(string email)
        {
            _email = email;
            return this;
        }

        public AlunoBuilderTest ComCpf(string cpf)
        {
            _cpf = cpf;
            return this;
        }

        public AlunoBuilderTest ComTelefone(string telefone)
        {
            _telefone = telefone;
            return this;
        }

        public AlunoBuilderTest ComId(int id)
        {
            _id = id;
            return this;
        }

        public AlunoBuilderTest Deletar()
        {
            _deletado = true;
            return this;
        }
    }
}

        
    


using System.Threading.Tasks;

namespace sistemaEscolarNotas.Domain.Interface
{
    public interface IAlunoRepository : IGenericRepository<AlunoEntity>
    {
        Task<bool> VerificarSeEmailJaExiste(string email, int id);
        Task<bool> VerificarSeJaExisteAluno(string cpf);
    }
}

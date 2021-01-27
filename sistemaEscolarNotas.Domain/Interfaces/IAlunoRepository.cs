using System.Threading.Tasks;

namespace sistemaEscolarNotas.Domain.Interface
{
    public interface IAlunoRepository : IGenericRepository<AlunoEntity>
    {
        Task<bool> VerificarSeEmailJaExiste(string email);
        Task<bool> ExisteAlunoComEsseCPF(string cpf, int id);
    }
}

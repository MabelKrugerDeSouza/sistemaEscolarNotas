using Microsoft.EntityFrameworkCore;
using sistemaEscolarNotas.Domain;
using sistemaEscolarNotas.Domain.GenericRepository;
using sistemaEscolarNotas.Domain.Interface;
using sistemaEscolarNotas.Infra.Context;
using System.Threading.Tasks;

namespace sistemaEscolarNotas.Infra.Repository.Aluno
{
    public class AlunoRepository : GenericRepository<AlunoEntity>, IAlunoRepository
    {
        private readonly MainContext _context;

        public AlunoRepository(MainContext context) : base(context)
        {
        }

        public async Task<bool> VerificarSeEmailJaExiste(string email, int id)
        {
            return await _dbSet.AnyAsync(x => x.Email == email && x.Id != id && !x.Deletado);
        }

        public async Task<bool> VerificarSeJaExisteAluno(string cpf)
        {
            return await _dbSet.AnyAsync(x => x.CPF == cpf && x.Deletado != true);
        }
    }
}

using sistemaEscolarNotas.Application.Model;
using sistemaEscolarNotas.Domain;
using System.Threading.Tasks;

namespace sistemaEscolarNotas.Application.Service
{
    public interface IAlunoService
    {
        Task<int> Create(AlunoRequestModel request);
        Task<AlunoEntity> Update(int id, AlunoRequestModel request);
        Task<AlunoEntity> Delete(int id);
        Task<AlunoResponseModel> GetById(int id);
    }
}

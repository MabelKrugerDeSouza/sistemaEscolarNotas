using sistemaEscolarNotas.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sistemaEscolarNotas.Domain.Interface
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetById(int id);
        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        Task<List<TEntity>> GetAll();
    }
}

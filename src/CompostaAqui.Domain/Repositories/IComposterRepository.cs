using CompostaAqui.Domain.Entities;

namespace CompostaAqui.Domain.Repositories
{
    public interface IComposterRepository
    {
        Task<IEnumerable<ComposterEntity>> GetAllAsync();
        Task<ComposterEntity> GetByGuidAsync(Guid uuid);
        Task<Guid> CreateAsync(ComposterEntity entity);
        Task<bool> UpdateAsync(ComposterEntity entity);
        Task<bool> DeleteAsync(Guid uuid);
    }
}

using CompostaAqui.Application.Models.Composter;

namespace CompostaAqui.Application.Interfaces
{
    public interface IComposterService
    {
        Task<IEnumerable<ComposterModel>> GetAllAsync();
        Task<ComposterModel> GetByGuidAsync(Guid uuid);
        Task<ComposterModel> CreateAsync(ComposterPostModel model);
        Task<ComposterModel> UpdateAsync(Guid uuid, ComposterPutModel model);
        Task<bool> DeleteAsync(Guid uuid);
    }
}

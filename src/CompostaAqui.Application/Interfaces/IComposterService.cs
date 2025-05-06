using CompostaAqui.Application.Models.Composter;
using CompostaAqui.Application.Models.Result;

namespace CompostaAqui.Application.Interfaces
{
    public interface IComposterService
    {
        Task<Result<List<ComposterModel>>> GetAllAsync();
        Task<Result<ComposterModel>> GetByGuidAsync(Guid uuid);
        Task<Result<ComposterModel>> CreateAsync(ComposterPostModel model);
        Task<Result<ComposterModel>> UpdateAsync(Guid uuid, ComposterPutModel model);
        Task<Result> DeleteAsync(Guid uuid);
    }
}

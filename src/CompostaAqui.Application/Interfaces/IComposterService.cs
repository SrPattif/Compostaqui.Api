using CompostaAqui.Application.Models;

namespace CompostaAqui.Application.Interfaces
{
    public interface IComposterService
    {
        Task<IEnumerable<ComposterModel>> GetAllAsync();
    }
}

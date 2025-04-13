using CompostaAqui.Application.Interfaces;
using CompostaAqui.Application.Mappers;
using CompostaAqui.Application.Models;
using CompostaAqui.Domain.UnitOfWorks;

namespace CompostaAqui.Application.Services
{
    public class ComposterService : IComposterService
    {
        private readonly IUnitOfWorkCompostaqui _unitOfWork;

        public ComposterService(IUnitOfWorkCompostaqui unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ComposterModel>> GetAllAsync()
        {
            var entities = await _unitOfWork.Composter.GetAllAsync();

            return entities.ToModel();
        }
    }
}

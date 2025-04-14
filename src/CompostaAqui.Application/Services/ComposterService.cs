using CompostaAqui.Application.Interfaces;
using CompostaAqui.Application.Mappers;
using CompostaAqui.Application.Models.Composter;
using CompostaAqui.Domain.Entities;
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

        public async Task<ComposterModel> GetByGuidAsync(Guid uuid)
        {
            var entities = await _unitOfWork.Composter.GetByGuidAsync(uuid);

            return entities.ToModel();
        }

        public async Task<ComposterModel> CreateAsync(ComposterPostModel model)
        {
            // validator

            var uuid = await _unitOfWork.Composter.CreateAsync(new ComposterEntity
            {
                City = model.City,
                Country = model.Country,
                DisplayName = model.DisplayName,
                Email = model.Email,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                Neighborhood = model.Neighborhood,
                PhoneNumber = model.PhoneNumber,
                State = model.State,
                StreetName = model.StreetName,
                StreetNumber = model.StreetNumber,
                ZipCode = model.ZipCode
            });

            return await GetByGuidAsync(uuid);
        }

        public async Task<ComposterModel> UpdateAsync(Guid uuid, ComposterPutModel model)
        {
            // validator

            await _unitOfWork.Composter.UpdateAsync(new ComposterEntity
            {
                Uuid = uuid,
                City = model.City,
                Country = model.Country,
                DisplayName = model.DisplayName,
                Email = model.Email,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                Neighborhood = model.Neighborhood,
                PhoneNumber = model.PhoneNumber,
                State = model.State,
                StreetName = model.StreetName,
                StreetNumber = model.StreetNumber,
                ZipCode = model.ZipCode
            });

            return await GetByGuidAsync(uuid);
        }

        public async Task<bool> DeleteAsync(Guid uuid)
        {
            // validator

            var result = await _unitOfWork.Composter.DeleteAsync(uuid);
            return result;
        }
    }
}

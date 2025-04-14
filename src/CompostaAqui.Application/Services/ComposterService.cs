using CompostaAqui.Application.Helpers;
using CompostaAqui.Application.Interfaces;
using CompostaAqui.Application.Mappers;
using CompostaAqui.Application.Models.Composter;
using CompostaAqui.Application.Models.Result;
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

        public async Task<Result<List<ComposterModel>>> GetAllAsync()
        {
            try
            {
                var entities = await _unitOfWork.Composter.GetAllAsync();
                return entities.ToModel().ToList();
            }
            catch (Exception)
            {
                return ErrorMessages.UnknownError;
            }
        }

        public async Task<Result<ComposterModel>> GetByGuidAsync(Guid uuid)
        {
            try
            {
                var entities = await _unitOfWork.Composter.GetByGuidAsync(uuid);
                return entities.ToModel();
            }
            catch(Exception) {
                return ErrorMessages.UnknownError;
            }
        }

        public async Task<Result<ComposterModel>> CreateAsync(ComposterPostModel model)
        {
            try
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
            catch (Exception)
            {
                return ErrorMessages.UnknownError;
            }
        }

        public async Task<Result<ComposterModel>> UpdateAsync(Guid uuid, ComposterPutModel model)
        {
            try
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
            catch (Exception)
            {
                return ErrorMessages.UnknownError;
            }
        }

        public async Task<Result> DeleteAsync(Guid uuid)
        {
            try
            {
                var success = await _unitOfWork.Composter.DeleteAsync(uuid);
                if (!success) return ErrorMessages.DeleteError;

                return Result.Succeeded();
            }
            catch (Exception)
            {
                return ErrorMessages.UnknownError;
            }
        }
    }
}

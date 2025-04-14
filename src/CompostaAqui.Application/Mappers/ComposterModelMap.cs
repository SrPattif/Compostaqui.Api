using CompostaAqui.Application.Models.Composter;
using CompostaAqui.Domain.Entities;

namespace CompostaAqui.Application.Mappers
{
    public static class ComposterModelMap
    {
        public static ComposterModel ToModel(this ComposterEntity entity)
        {
            return new ComposterModel()
            {
                Uuid = entity.Uuid,
                DisplayName = entity.DisplayName,
                StreetName = entity.StreetName,
                StreetNumber = entity.StreetNumber,
                State = entity.State,
                City = entity.City,
                Country = entity.Country,
                Email = entity.Email,
                Latitude = entity.Latitude,
                Longitude = entity.Longitude,   
                Neighborhood = entity.Neighborhood,
                PhoneNumber = entity.PhoneNumber,
                ZipCode = entity.ZipCode
            };
        }

        public static IEnumerable<ComposterModel> ToModel(this IEnumerable<ComposterEntity> entities) {
            return entities.Select(ToModel);
        }
    }
}

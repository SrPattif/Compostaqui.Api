using CompostaAqui.Domain.Entities;
using CompostaAqui.Domain.Repositories;
using CompostaAqui.Infrastructure.UnitOfWorks;
using Dapper;

namespace CompostaAqui.Infrastructure.Repositories
{
    public class ComposterRepository : IComposterRepository
    {
        public const string TABLE_NAME = "Composter";
        private readonly UnitOfWorkCompostaqui _unitOfWork;

        public ComposterRepository(UnitOfWorkCompostaqui unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ComposterEntity>> GetAllAsync()
        {
            const string sql = @$"SELECT Id,
                                        Uuid,
                                        DisplayName,
                                        StreetName,
                                        StreetNumber,
                                        Neighborhood,
                                        City,
                                        State,
                                        ZipCode,
                                        Country,
                                        PhoneNumber,
                                        Email,
                                        Latitude,
                                        Longitude,
                                        CreatedAt,
                                        UpdatedAt
                                   FROM [{TABLE_NAME}]
                                  WHERE Deleted = 0;";

            return await _unitOfWork.Connection.QueryAsync<ComposterEntity>(sql, transaction: _unitOfWork.Transaction);
        }

        public async Task<ComposterEntity> GetByGuidAsync(Guid uuid)
        {
            const string sql = @$"SELECT Id,
                                        Uuid,
                                        DisplayName,
                                        StreetName,
                                        StreetNumber,
                                        Neighborhood,
                                        City,
                                        State,
                                        ZipCode,
                                        Country,
                                        PhoneNumber,
                                        Email,
                                        Latitude,
                                        Longitude,
                                        CreatedAt,
                                        UpdatedAt
                                   FROM [{TABLE_NAME}]
                                  WHERE Uuid = @uuid
                                    AND Deleted = 0;";

            return await _unitOfWork.Connection.QueryFirstOrDefaultAsync<ComposterEntity>(sql, new { uuid }, transaction: _unitOfWork.Transaction);
        }

        public async Task<Guid> CreateAsync(ComposterEntity entity)
        {
            entity.Uuid = Guid.NewGuid();

            const string sql = $@"INSERT INTO [{TABLE_NAME}] (
                                     Uuid,
	                                 DisplayName,
                                     StreetName,
                                     StreetNumber,
                                     Neighborhood,
                                     City,
                                     State,
                                     ZipCode,
                                     Country,
                                     PhoneNumber,
                                     Email,
                                     Latitude,
                                     Longitude
                                 )
                                OUTPUT 
                                Inserted.Uuid
                                VALUES(  
                                    @Uuid,
                                    @DisplayName,
                                    @StreetName,
                                    @StreetNumber,
                                    @Neighborhood,
                                    @City,
                                    @State,
                                    @ZipCode,
                                    @Country,
                                    @PhoneNumber,
                                    @Email,
                                    @Latitude,
                                    @Longitude
		                        )";

            var guid = await _unitOfWork.Connection.ExecuteScalarAsync<Guid>(sql, entity, _unitOfWork.Transaction);

            return guid;
        }

        public async Task<bool> UpdateAsync(ComposterEntity entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;

            var sql = @$"UPDATE [{TABLE_NAME}]
                           SET DisplayName = @DisplayName,
                               StreetName = @StreetName,
                               StreetNumber = @StreetNumber,
                               Neighborhood = @Neighborhood,
                               City = @City,
                               State = @State,
                               ZipCode = @ZipCode,
                               Country = @Country,
                               PhoneNumber = @PhoneNumber,
                               Email = @Email,
                               Latitude = @Latitude,
                               Longitude = @Longitude,
                               UpdatedAt = @UpdatedAt
                         WHERE Uuid = @Uuid
                           AND Deleted = 0";

            var rows = await _unitOfWork.Connection.ExecuteAsync(sql, entity, transaction: _unitOfWork.Transaction);

            return rows > 0;
        }

        public async Task<bool> DeleteAsync(Guid uuid)
        {
            var updatedAt = DateTime.UtcNow;

            var sql = @$"UPDATE [{TABLE_NAME}]
                           SET Deleted = 1,
                               UpdatedAt = @updatedAt
                         WHERE Uuid = @uuid
                           AND Deleted = 0";

            var rows = await _unitOfWork.Connection.ExecuteAsync(sql, new { updatedAt, uuid }, transaction: _unitOfWork.Transaction);

            return rows > 0;
        }
    }
}

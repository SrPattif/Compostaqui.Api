using CompostaAqui.Domain.UnitOfWorks;
using System.Data;

namespace CompostaAqui.Infrastructure.UnitOfWorks
{
    public abstract class UnitOfWork<DbConnection> : IUnitOfWork where DbConnection : IDbConnection, new()
    {
        protected string ConnectionString { get; set; }
        private IDbConnection _connection;
        public IDbConnection Connection => _connection ?? BuildConnection();
        public IDbTransaction Transaction { get; private set; }

        private IDbConnection BuildConnection()
        {
            _connection = new DbConnection
            {
                ConnectionString = ConnectionString
            };
            _connection.Open();
            return _connection;
        }

        public void BeginTransaction()
        {
            Transaction = Connection.BeginTransaction();
        }

        public void Commit()
        {
            Transaction?.Commit();
        }

        public void Dispose()
        {
            _connection?.Dispose();
            Transaction?.Dispose();
        }

        public void Rollback()
        {
            Transaction?.Rollback();
        }
    }
}

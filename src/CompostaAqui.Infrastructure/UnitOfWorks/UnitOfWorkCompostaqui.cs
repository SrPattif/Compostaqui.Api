﻿using CompostaAqui.Domain.Repositories;
using CompostaAqui.Domain.UnitOfWorks;
using CompostaAqui.Infrastructure.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace CompostaAqui.Infrastructure.UnitOfWorks
{
    public class UnitOfWorkCompostaqui : UnitOfWork<SqlConnection>, IUnitOfWorkCompostaqui
    {
        public IComposterRepository Composter => new ComposterRepository(this);

        public UnitOfWorkCompostaqui(IConfiguration configuration)
        {
            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
            if (string.IsNullOrEmpty(connectionString)) connectionString = configuration.GetConnectionString("CompostaquiDb");
            ConnectionString = connectionString;
        }

        public bool InTransaction() => Transaction != null;
    }
}

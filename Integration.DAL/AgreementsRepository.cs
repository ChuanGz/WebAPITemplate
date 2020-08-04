using Dapper;
using Integration.DAL.Contract;
using Integration.DAL.Models;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Integration.DAL
{
    public class AgreementsRepository : IAgreementsRepository, IHealthCheck
    {

        private readonly IOptionsMonitor<RepositoryOption> _options;

        public AgreementsRepository(IOptionsMonitor<RepositoryOption> options)
        {
            _options = options;
        }

        public async Task<AgreementEntity> CreateAgreementAsync(AgreementEntity newAgreement)
        {
            using (var db = new SqlConnection(_options.CurrentValue.SqlServerDbConnectionString))
            {
                await db.ExecuteAsync(_options.CurrentValue.SqlQueryStoreProcedure, newAgreement, commandType: CommandType.StoredProcedure);
                return newAgreement;
            }
        }

        public async Task<AgreementEntity> GetAgreementAsync(Guid id)
        {
            using (var db = new SqlConnection(_options.CurrentValue.SqlServerDbConnectionString))
            {
                return await db.QueryFirstOrDefaultAsync<AgreementEntity>(_options.CurrentValue.SqlQueryStoreProcedure, new { id = id.ToString() }, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<bool> UpdateAgreementAsync(AgreementEntity agr)
        {
            agr.UpdatedDate = DateTime.Now;
            using (var db = new SqlConnection(_options.CurrentValue.SqlServerDbConnectionString))
            {
                await db.ExecuteAsync(_options.CurrentValue.SqlQueryStoreProcedure, agr, commandType: CommandType.StoredProcedure);
                return true;
            }
        }

        public async Task<bool> DeleteAgreementAsync(Guid id)
        {
            using (var db = new SqlConnection(_options.CurrentValue.SqlServerDbConnectionString))
            {
                await db.ExecuteAsync(_options.CurrentValue.SqlQueryStoreProcedure, new { id = id.ToString() }, commandType: CommandType.StoredProcedure);
                return true;
            }
        }

        public async Task<IEnumerable<AgreementEntity>> GetAgreementsListAsync(int pageNumber, int pageSize)
        {
            using (var db = new SqlConnection(_options.CurrentValue.SqlServerDbConnectionString))
            {
                var offset = pageNumber <= 1 ? 0 : (pageNumber - 1) * pageSize;
                return await db.QueryAsync<AgreementEntity>(_options.CurrentValue.SqlQueryStoreProcedure, new { pageSize, offset }, commandType: CommandType.StoredProcedure);
            }
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            using (var db = new SqlConnection(_options.CurrentValue.SqlServerDbConnectionString))
            {
                try
                {
                    db.Open();
                    db.Close();
                    return Task.FromResult(HealthCheckResult.Healthy());
                }
                catch
                {
                    return Task.FromResult(HealthCheckResult.Unhealthy());
                }
            }
        }
    }
}

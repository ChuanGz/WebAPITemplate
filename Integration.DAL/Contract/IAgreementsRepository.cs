using Integration.DAL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Integration.DAL.Contract
{
    public interface IAgreementsRepository
    {
        Task<AgreementEntity> CreateAgreementAsync(AgreementEntity agr);
        Task<AgreementEntity> GetAgreementAsync(Guid id);
        Task<bool> UpdateAgreementAsync(AgreementEntity agr);
        Task<bool> DeleteAgreementAsync(Guid id);

        Task<IEnumerable<AgreementEntity>> GetAgreementsListAsync(int pageNumber, int pageSize);
    }
}

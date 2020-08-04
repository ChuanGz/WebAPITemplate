using Integration.BLL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Integration.BLL.Contracts
{
    public interface IAgreementsService
    {
        /// <summary>
        /// Create a new agreement
        /// </summary>
        /// <param name="agreement"></param>
        /// <returns></returns>
        Task<Agreement> CreateAgreementAsync(Agreement agreement);

        /// <summary>
        /// Get agreement by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Agreement> GetAgreementAsync(Guid id);

        /// <summary>
        /// Update agreement parameters
        /// </summary>
        /// <param name="agreement"></param>
        /// <returns></returns>
        Task<bool> UpdateAgreementAsync(Agreement agreement);

        /// <summary>
        /// Delete agreement by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAgreementAsync(Guid id); 

        /// <summary>
        /// Get agreements list 
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<IEnumerable<Agreement>> GetAgreementsListAsync(int pageNumber, int pageSize);
    }
}

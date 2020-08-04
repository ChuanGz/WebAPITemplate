using AutoMapper;
using Integration.BLL.Contracts;
using Integration.BLL.Models;
using Integration.DAL.Contract;
using Integration.DAL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Integration.BLL
{
    public class AgreementsService : IAgreementsService
    {
        private readonly IMapper _mapper;

        public IAgreementsRepository _agreementsRepo { get; }

        public AgreementsService(IMapper mapper, IAgreementsRepository agreementsRepo)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _agreementsRepo = agreementsRepo ?? throw new ArgumentNullException(nameof(agreementsRepo));
        }

        public async Task<Agreement> CreateAgreementAsync(Agreement agr)
        {
            var newCar = await _agreementsRepo.CreateAgreementAsync(_mapper.Map<AgreementEntity>(agr));
            return _mapper.Map<Agreement>(newCar);
        }

        public async Task<bool> DeleteAgreementAsync(Guid id)
        {
            var result = await _agreementsRepo.DeleteAgreementAsync(id);
            return result;
        }

        public async Task<Agreement> GetAgreementAsync(Guid id)
        {
            var agr = await _agreementsRepo.GetAgreementAsync(id);
            return _mapper.Map<Agreement>(agr);
        }

        public async Task<IEnumerable<Agreement>> GetAgreementsListAsync(int pageNumber, int pageSize)
        {
            var agrs = await _agreementsRepo.GetAgreementsListAsync(pageNumber, pageSize);
            return _mapper.Map<IEnumerable<Agreement>>(agrs);
        }

        public async Task<bool> UpdateAgreementAsync(Agreement agr)
        {
            var result = await _agreementsRepo.UpdateAgreementAsync(_mapper.Map<AgreementEntity>(agr));
            return result;
        }
    }
}

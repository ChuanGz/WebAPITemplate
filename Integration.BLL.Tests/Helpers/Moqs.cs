using AutoFixture;
using Moq;
using Integration.BLL.Contracts;
using Integration.BLL.Models;
using System;
using Integration.DAL.Models;
using Integration.DAL.Contract;

namespace Integration.BLL.Tests.Helpers
{
    public static class Moqs
    {
        public static Mock<IAgreementsService> AgreementsServiceMoq()
        {
            var fixture = new Fixture();

            var moq = new Mock<IAgreementsService>(MockBehavior.Strict);
            moq.Setup(s => s.CreateAgreementAsync(It.IsAny<Agreement>()))
              .ReturnsAsync(fixture.Build<Agreement>().Create());
            moq.Setup(s => s.GetAgreementAsync(It.IsAny<Guid>()))
             .ReturnsAsync(fixture.Build<Agreement>().Create());
            moq.Setup(s => s.UpdateAgreementAsync(It.IsAny<Agreement>()))
              .ReturnsAsync(true);
            moq.Setup(s => s.DeleteAgreementAsync(It.IsAny<Guid>()))
            .ReturnsAsync(true);
            moq.Setup(s => s.GetAgreementsListAsync(It.IsAny<int>(), It.IsAny<int>()))
             .ReturnsAsync(fixture.Build<Agreement>().CreateMany(20));

            return moq;
        }

        public static Mock<IAgreementsRepository> AgreementsReposirotyMoq(AgreementEntity carEntity)
        {
            var fixture = new Fixture();

            var moq = new Mock<IAgreementsRepository>(MockBehavior.Strict);
            moq.Setup(s => s.CreateAgreementAsync(It.IsAny<AgreementEntity>()))
              .ReturnsAsync(carEntity);
            moq.Setup(s => s.GetAgreementAsync(It.IsAny<Guid>()))
             .ReturnsAsync(carEntity);
            moq.Setup(s => s.UpdateAgreementAsync(It.IsAny<AgreementEntity>()))
              .ReturnsAsync(true);
            moq.Setup(s => s.DeleteAgreementAsync(It.IsAny<Guid>()))
            .ReturnsAsync(true);
            moq.Setup(s => s.GetAgreementsListAsync(It.IsAny<int>(), It.IsAny<int>()))
             .ReturnsAsync(fixture.Build<AgreementEntity>().CreateMany(20));

            return moq;
        }
    }
}

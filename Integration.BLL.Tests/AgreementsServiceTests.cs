using AutoFixture;
using Integration.BLL.Tests.Helpers;
using Xunit;
using Integration.DAL.Models;
using System;
using Newtonsoft.Json;
using Integration.BLL.Models;

namespace Integration.BLL.Tests
{
    public class AgreementsServiceTests
    {
        [Theory]
        [InlineData("Mercedes", AgreementType.FOB)]
        [InlineData("BMW", AgreementType.OTHERS)]
        public void CreateAgreement_Test(string modelName, AgreementType agreementType)
        {
            //Arrange
            var fixture = new Fixture();

            var agreement = Fixtures.AgreementFixture(modelName, agreementType);
            var mapper = Mapper.GetAutoMapper();
            var agreementsRepoMoq = Moqs.AgreementsReposirotyMoq(mapper.Map<AgreementEntity>(agreement));
            var agreementSvc = new AgreementsService(mapper, agreementsRepoMoq.Object);

            //Act
            var newAgreement = agreementSvc.CreateAgreementAsync(agreement).Result;

            //Assert
            var actual = JsonConvert.SerializeObject(agreement);
            var expected = JsonConvert.SerializeObject(newAgreement);
            Assert.Equal(expected.Trim(), actual.Trim());
        }

        [Fact]
        public void GetAgreement_Test()
        {
            //Arrange
            var fixture = new Fixture();

            var agreement = Fixtures.AgreementFixture();
            var mapper = Mapper.GetAutoMapper();
            var agreementsRepoMoq = Moqs.AgreementsReposirotyMoq(mapper.Map<AgreementEntity>(agreement));
            var agreementSvc = new AgreementsService(mapper, agreementsRepoMoq.Object);

            //Act
            var result = agreementSvc.GetAgreementAsync(fixture.Create<Guid>()).Result;

            //Assert
            var actual = JsonConvert.SerializeObject(agreement);
            var expected = JsonConvert.SerializeObject(result);
            Assert.Equal(expected.Trim(), actual.Trim());
        }
    }
}

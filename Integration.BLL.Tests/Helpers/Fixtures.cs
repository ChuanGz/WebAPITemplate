using AutoFixture;
using Integration.BLL.Models;

namespace Integration.BLL.Tests.Helpers
{
    public static class Fixtures
    {
        public static Agreement AgreementFixture(string AGRNO = null, AgreementType AGRCLASS = 0)
        {
            var fixture = new Fixture();

            var agr = fixture.Build<Agreement>();

            if (!string.IsNullOrEmpty(AGRNO))
            {
                agr.With(s => s.AGRNO, AGRNO);
            }

            if (AGRCLASS>0)
            {
                agr.With(s => s.AGRCLASS, AGRCLASS);
            }

            return agr.Create();
        }
    }
}

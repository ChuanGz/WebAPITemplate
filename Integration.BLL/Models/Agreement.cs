using System;

namespace Integration.BLL.Models
{
    public class Agreement
    {
        public Guid Id { get; set; }
        public string AGRNO { get; set; }
        public string CUSTOMERCODE { get; set; }
        public string CUSTOMERNAME { get; set; }
        public AgreementType AGRCLASS { get; set; }
        public DateTime SIGNDATE { get; set; }
        public DateTime? STARTDATE { get; set; }
        public DateTime? ENDDATE { get; set; }
    }
}

using System;

namespace Integration.DAL.Models
{
    public class AgreementEntity : SyncEntity
    {
        public string Id { get; set; }
        public string AGRNO { get; set; }
        public string CUSTOMERCODE { get; set; }
        public string CUSTOMERNAME { get; set; }
        public string AGRCLASS { get; set; }
        public DateTime SIGNDATE { get; set; }
        public DateTime? STARTDATE { get; set; }
        public DateTime? ENDDATE { get; set; }
    }
}

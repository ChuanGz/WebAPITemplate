using System;

namespace Integration.DAL.Models
{
    public class SyncEntity : BaseEntity
    {
        public string IOFlag { get; set; }
        public int SyncOrder { get; set; }
        public string HashCode { get; set; }
        public string SyncBy { get; set; }
        public string SyncHttpMethod { get; set; }
        public string SyncHttpResource { get; set; }
        public string SyncStatus { get; set; }
        public string SyncUserName { get; set; }
        public DateTime LastSyncDate { get; set; }
        public string SyncErrorCode { get; set; }
        public string SyncErrorMessage { get; set; }
        public int SyncHeaderID { get; set; }
        public int SyncSapDocNum { get; set; }
        public double SyncTotalElapsedTime { get; set; }
    }
}

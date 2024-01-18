using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJ.Models
{
    public class MyRelationModel
    {
        public string Title { get; set; }
        public string Id { get; set; }
        public string TransactionId { get; set; }
        public string ChitCodeId { get; set; }
        public string TransactionDate { get; set; }
        public string JoinDate { get; set; }
        public string TransactionTime { get; set; }
        public string CustomerId { get; set; }
        public string ChitCode { get; set; }
        public string CustomerName { get; set; }
        public string ChitSchemeId { get; set; }
        public string ChitSchemeName { get; set; }
        public string NoOfMonths { get; set; }
        public string MonthlyDue { get; set; }
        public string MonthlyDueWeight { get; set; }
        public string BonusMonth { get; set; }
        public string SchemeBased { get; set; }
        public string IsArchive { get; set; }
        public string TotalPaidAmount { get; set; }
        public string PendingDues { get; set; }
        public string SetActive { get; set; }
        public string MaturityDate { get; set; }
    }
}

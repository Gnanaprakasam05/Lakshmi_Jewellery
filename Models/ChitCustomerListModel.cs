using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJ.Models
{
  
    public class ChitCustomerListModel
    {
        [JsonProperty("index")]
        public List<Index1> Index { get; set; }

        [JsonProperty("totalRows")]
        public string TotalRows { get; set; }

        [JsonProperty("message")]
        public string Message{ get; set; }
    }
    public class Index1
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("transaction_id")]
        public string TransactionId{ get; set; }

        [JsonProperty("chit_code_id")]
        public string ChitCodeId{ get; set; }

        [JsonProperty("transaction_date")]
        public string TransactionDate{ get; set; }

        [JsonProperty("join_date")]
        public string JoinDate{ get; set; }

        [JsonProperty("transaction_time")]
        public string TransactionTime{ get; set; }

        [JsonProperty("customer_id")]
        public string CustomerId{ get; set; }

        [JsonProperty("chit_code")]
        public string ChitCode{ get; set; }

        [JsonProperty("customer_name")]
        public string CustomerName{ get; set; }

        [JsonProperty("chit_scheme_id")]
        public string ChitSchemeId{ get; set; }

        [JsonProperty("chit_scheme_name")]
        public string ChitSchemeName{ get; set; }

        [JsonProperty("no_of_months")]
        public string NoOfMonths{ get; set; }

        [JsonProperty("monthly_due")]
        public string MonthlyDue{ get; set; }

        [JsonProperty("monthly_due_weight")]
        public string MonthlyDueWeight{ get; set; }

        [JsonProperty("bonus_month")]
        public string BonusMonth{ get; set; }

        [JsonProperty("scheme_based")]
        public string SchemeBased{ get; set; }

        [JsonProperty("is_archive")]
        public string IsArchive{ get; set; }

        [JsonProperty("total_paid_amount")]
        public string TotalPaidAmount{ get; set; }

        [JsonProperty("pending_dues")]
        public string PendingDues{ get; set; }

        [JsonProperty("setActive")]
        public string SetActive{ get; set; }

        [JsonProperty("maturity_date")]
        public string MaturityDate{ get; set; }  
        
        [JsonProperty("chit_due_date")]
        public string ChitDueDate{ get; set; }   
        
        [JsonProperty("disable_pay_now")]
        public string DisablePayNow{ get; set; }
    }
}

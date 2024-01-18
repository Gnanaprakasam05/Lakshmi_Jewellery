using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJ.Models
{
  

    public class CollectionPayNowModel
    {
        [JsonProperty("index")]
        public List<Index1> Index;

        [JsonProperty("totalRows")]
        public string TotalRows;

        [JsonProperty("message")]
        public string Message;
    }
    public class Index2
    {
        [JsonProperty("id")]
        public string Id;

        [JsonProperty("transaction_id")]
        public string TransactionId;

        [JsonProperty("chit_code_id")]
        public string ChitCodeId;

        [JsonProperty("transaction_date")]
        public string TransactionDate;

        [JsonProperty("join_date")]
        public string JoinDate;

        [JsonProperty("transaction_time")]
        public string TransactionTime;

        [JsonProperty("customer_id")]
        public string CustomerId;

        [JsonProperty("chit_code")]
        public string ChitCode;

        [JsonProperty("customer_name")]
        public string CustomerName;

        [JsonProperty("chit_scheme_id")]
        public string ChitSchemeId;

        [JsonProperty("chit_scheme_name")]
        public string ChitSchemeName;

        [JsonProperty("no_of_months")]
        public string NoOfMonths;

        [JsonProperty("monthly_due")]
        public string MonthlyDue;

        [JsonProperty("monthly_due_weight")]
        public string MonthlyDueWeight;

        [JsonProperty("bonus_month")]
        public string BonusMonth;

        [JsonProperty("scheme_based")]
        public string SchemeBased;

        [JsonProperty("is_archive")]
        public string IsArchive;

        [JsonProperty("total_paid_amount")]
        public string TotalPaidAmount;

        [JsonProperty("pending_dues")]
        public string PendingDues;

        [JsonProperty("setActive")]
        public string SetActive;

        [JsonProperty("maturity_date")]
        public string MaturityDate;
    }
}

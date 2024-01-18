using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJ.Models
{


    public class StorePaymentDetailsModel
    {
        [JsonProperty("rs")]
        public Rs Rs;

        [JsonProperty("message")]
        public string Message;

        [JsonProperty("is_error")]
        public string IsError;
    }

    public class Rs
    {
        [JsonProperty("created_user_id")]
        public string CreatedUserId;

        [JsonProperty("transaction_date")]
        public string TransactionDate;

        [JsonProperty("transaction_time")]
        public string TransactionTime;

        [JsonProperty("customer_id")]
        public string CustomerId;

        [JsonProperty("chit_code_id")]
        public string ChitCodeId;

        [JsonProperty("rate")]
        public string Rate;

        [JsonProperty("payment_type_id")]
        public string PaymentTypeId;

        [JsonProperty("branch_id")]
        public string BranchId;

        [JsonProperty("updated_at")]
        public string UpdatedAt;

        [JsonProperty("created_at")]
        public string CreatedAt;

        [JsonProperty("id")]
        public string Id;

        [JsonProperty("total_over_weight")]
        public string TotalOverWeight;

        [JsonProperty("total_due_weight")]
        public string TotalDueWeight;

        [JsonProperty("total_due_amount")]
        public string TotalDueAmount;

        [JsonProperty("total_paid_weight")]
        public string TotalPaidWeight;

        [JsonProperty("total_paid_amount")]
        public string TotalPaidAmount;

        [JsonProperty("round_off")]
        public string RoundOff;

        [JsonProperty("total_nett_amount")]
        public string TotalNettAmount;
    }
}

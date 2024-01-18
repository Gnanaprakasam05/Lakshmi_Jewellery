using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJ.Models
{
 
    public class ChitCustomerCollectionDueListModel
    {
        [JsonProperty("data")]
        public List<Datum> Data { get; set; }
    }
    public class Datum
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("customer_id")]
        public string CustomerId { get; set; }

        [JsonProperty("customer_name")]
        public string CustomerName { get; set; }

        [JsonProperty("chit_code_id")]
        public string ChitCodeId { get; set; }

        [JsonProperty("chit_code_name")]
        public string ChitCodeName { get; set; }

        [JsonProperty("chit_scheme_id")]
        public string ChitSchemeId { get; set; }

        [JsonProperty("chit_scheme_name")]
        public string ChitSchemeName { get; set; }

        [JsonProperty("scheme_based")]
        public string SchemeBased { get; set; }

        [JsonProperty("collection_id")]
        public string CollectionId { get; set; }

        [JsonProperty("due_date")]
        public string DueDate { get; set; }

        [JsonProperty("due_no")]
        public string DueNo { get; set; }

        [JsonProperty("due_weight")]
        public string DueWeight { get; set; }

        [JsonProperty("due_amount")]
        public string DueAmount { get; set; }

        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }

        [JsonProperty("collection_date")]
        public string CollectionDate { get; set; }

        [JsonProperty("paid_weight")]
        public string PaidWeight { get; set; }

        [JsonProperty("paid_amount")]
        public string PaidAmount { get; set; }

        [JsonProperty("weight")]
        public string Weight { get; set; }

        [JsonProperty("total_weight")]
        public string TotalWeight { get; set; }

        [JsonProperty("total_weight_all")]
        public string TotalWeightAll { get; set; }
    }

}

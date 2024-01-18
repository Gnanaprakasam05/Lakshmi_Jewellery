using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJ.Models
{

    public class ViewPassbookModel
    {
        [JsonProperty("id")]
        public string Id;

        [JsonProperty("transaction_id")]
        public string TransactionId;

        [JsonProperty("detail_id")]
        public string DetailId;

        [JsonProperty("receipt_no")]
        public string ReceiptNo;

        [JsonProperty("collection_date")]
        public string CollectionDate;

        [JsonProperty("receipt_date")]
        public string ReceiptDate;

        [JsonProperty("customer_id")]
        public string CustomerId;

        [JsonProperty("customer_name")]
        public string CustomerName;

        [JsonProperty("chit_scheme_id")]
        public string ChitSchemeId;

        [JsonProperty("chit_code_id")]
        public string ChitCodeId;

        [JsonProperty("chit_code_name")]
        public string ChitCodeName;

        [JsonProperty("ins_no")]
        public string InsNo;

        [JsonProperty("chit_scheme_name")]
        public string ChitSchemeName;

        [JsonProperty("due_weight")]
        public string DueWeight;

        [JsonProperty("due_amount")]
        public string DueAmount;

        [JsonProperty("weight")]
        public string Weight;

        [JsonProperty("total_weight")]
        public string TotalWeight;

        [JsonProperty("rate")]
        public string Rate;

        [JsonProperty("scheme_based")]
        public string SchemeBased;

        [JsonProperty("payment_type")]
        public string PaymentType;
    }

    public class ViewPassBookDataModel
    {
        public string Id { get; set; }
        public string TitleAmount_Weight { get; set; }
        public string Title_Weight { get; set; }
        public string Title_Colon { get; set; }
        public string TransactionId { get; set; }
        public string DetailId { get; set; }
        public string ReceiptNo { get; set; }
        public string CollectionDate { get; set; }
        public string ReceiptDate { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string ChitSchemeId { get; set; }
        public string ChitCodeId { get; set; }
        public string ChitCodeName { get; set; }
        public string InsNo { get; set; }
        public string ChitSchemeName { get; set; }
        public string DueWeight { get; set; }
        public string DueAmount { get; set; }
        public string Weight { get; set; }
        public string TotalWeight { get; set; }
        public string Rate { get; set; }
        public string SchemeBased { get; set; }
        public string PaymentType { get; set; }
        public string Name { get; set; }
        public string SchemeName { get; set; }
        public string Code { get; set; }
        public string JoiningData { get; set; }
        public string MaturityData { get; set; }

    }
}

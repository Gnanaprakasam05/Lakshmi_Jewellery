using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJ.Models
{
    
    public class RazorpayModel
    {

        [JsonProperty("id")]
        public string Id;

        [JsonProperty("entity")]
        public string Entity;

        [JsonProperty("amount")]
        public string Amount;

        [JsonProperty("amount_paid")]
        public string AmountPaid;

        [JsonProperty("amount_due")]
        public string AmountDue;

        [JsonProperty("currency")]
        public string Currency;

        [JsonProperty("receipt")]
        public string Receipt;

        [JsonProperty("offer_id")]
        public string OfferId;

        [JsonProperty("status")]
        public string Status;

        [JsonProperty("attempts")]
        public string Attempts;

        [JsonProperty("notes")]
        public List<object> Notes;

        [JsonProperty("created_at")]
        public string CreatedAt;


    }
}

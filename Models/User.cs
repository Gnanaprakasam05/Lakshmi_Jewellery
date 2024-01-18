using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJ
    .Models
{
    public class User
    {    
           [JsonProperty("message")]
            public string Message { get; set; }

            [JsonProperty("user_data")]
            public UserData UserData { get; set; }  

        [JsonProperty("token")]
            public string Token{ get; set; }
    }
    public class UserData
        {
            [JsonProperty("id")]
            public string Id{ get; set; }

            [JsonProperty("short_name")]
            public string ShortName{ get; set; }

            [JsonProperty("name")]
            public string Name{ get; set; }

            [JsonProperty("code")]
            public string Code{ get; set; }

            [JsonProperty("gstin_no")]
            public string GstinNo{ get; set; }

            [JsonProperty("pan_no")]
            public string PanNo{ get; set; }

            [JsonProperty("address1")]
            public string Address1{ get; set; }

            [JsonProperty("address2")]
            public string Address2{ get; set; }

            [JsonProperty("address3")]
            public string Address3{ get; set; }

            [JsonProperty("place_id")]
            public string PlaceId{ get; set; }

            [JsonProperty("place")]
            public string Place{ get; set; }

            [JsonProperty("phone_no")]
            public string PhoneNo{ get; set; }

            [JsonProperty("mobile_no")]
            public string MobileNo{ get; set; }

            [JsonProperty("ledger_id")]
            public string LedgerId{ get; set; }

            [JsonProperty("email_id")]
            public string EmailId{ get; set; }

            [JsonProperty("website")]
            public string Website{ get; set; }

            [JsonProperty("allow_credit_bill")]
            public string AllowCreditBill{ get; set; }

            [JsonProperty("flag")]
            public string Flag{ get; set; }

            [JsonProperty("ledger_name")]
            public string LedgerName{ get; set; }

            [JsonProperty("dob")]
            public string Dob{ get; set; }

            [JsonProperty("wedding_anniversary_date")]
            public string WeddingAnniversaryDate{ get; set; }

            [JsonProperty("is_archive")]
            public string IsArchive{ get; set; }

            [JsonProperty("setActive")]
            public string SetActive{ get; set; }
        }

    public class ChechBackModel
    {

        public int checkbackId { get; set; }
    }

    
    
}

using Newtonsoft.Json;

namespace streamers.api.Models
{
    public class InsurerData
    {
        [JsonProperty(PropertyName = "id")]
        public long Id { get; set; }

        [JsonProperty(PropertyName = "policy_id")]
        public string PolicyId { get; set; }

        [JsonProperty(PropertyName = "state_code")]
        public string StateCode { get; set; }

        [JsonProperty(PropertyName = "county")]
        public string County { get; set; }

        [JsonProperty(PropertyName = "eq_site_limit")]
        public string EqSiteLimit { get; set; }

        [JsonProperty(PropertyName = "hu_site_limit")]
        public string HuSiteLimit { get; set; }

        [JsonProperty(PropertyName = "fl_site_limit")]
        public string FlSiteLimit { get; set; }

        [JsonProperty(PropertyName = "fr_site_limit")]
        public string FrSiteLimit { get; set; }

        [JsonProperty(PropertyName = "tiv_2011")]
        public string TivOne { get; set; }

        [JsonProperty(PropertyName = "tiv_2012")]
        public string TivTwo { get; set; }

        [JsonProperty(PropertyName = "eq_site_deductible")]
        public string EqSiteDeductible { get; set; }

        [JsonProperty(PropertyName = "hu_site_deductible")]
        public string HuSiteDeductible { get; set; }

        [JsonProperty(PropertyName = "fl_site_deductible")]
        public string FlSiteDeductible { get; set; }

        [JsonProperty(PropertyName = "fr_site_deductible")]
        public string FrSiteDeductible { get; set; }

        [JsonProperty(PropertyName = "point_latitude")]
        public string PointLatitude { get; set; }

        [JsonProperty(PropertyName = "point_longitude")]
        public string PointLongitude { get; set; }

        [JsonProperty(PropertyName = "line")]
        public string Line { get; set; }

        [JsonProperty(PropertyName = "construction")]
        public string Construction { get; set; }

        [JsonProperty(PropertyName = "point_granularity")]
        public string PointGranularity { get; set; }
    }
}

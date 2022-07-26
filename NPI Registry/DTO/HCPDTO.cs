using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPI_Registry.DTO
{
    internal class HCPDTO
    {
        [JsonProperty("results")]
        public List<HCPDetail> HCPDetails { get; set; }
    }
    class HCPDetail
    {
        [JsonProperty("number")]
        public long NPI { get; set; }
        [JsonProperty("basic")]
        public UserDetail UserDetails { get; set; }
        [JsonProperty("addresses")]
        public List<Address> Addresses { get; set; }
        [JsonProperty("taxonomies")]
        public List<Taxonomy> Taxonomies { get; set; }
    }
    class UserDetail
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; } = string.Empty;
        [JsonProperty("last_name")]
        public string LastName { get; set; } = string.Empty;
        [JsonProperty("middle_name")]
        public string MiddleName { get; set; } = string.Empty;
        [JsonProperty("credential")]
        public string Credential { get; set; } = string.Empty;
        [JsonProperty("gender")]
        public string Gender { get; set; } = string.Empty;
        [JsonProperty("certification_date")]
        public DateTime CertificationDate { get; set; }
    }
    class Address
    {
        [JsonProperty("country_code")]
        public string CountryCode { get; set; } = string.Empty;
        [JsonProperty("country_name")]
        public string CountryName { get; set; } = string.Empty;
        [JsonProperty("address_1")]
        public string HouseAddress { get; set; } = string.Empty;
        [JsonProperty("address_2")]
        public string StreetAddress { get; set; } = string.Empty;
        [JsonProperty("city")]
        public string City { get; set; } = string.Empty;
        [JsonProperty("state")]
        public string State { get; set; } = string.Empty;
        [JsonProperty("postal_code")]
        public string PostalCode { get; set; } = string.Empty;
    }
    class Taxonomy
    {
        [JsonProperty("desc")]
        public string Description { get; set; } = string.Empty;
        [JsonProperty("primary")]
        public bool Primary { get; set; } = false;
        [JsonProperty("state")]
        public string State { get; set; } = string.Empty;
        [JsonProperty("license")]
        public string License { get; set; } = string.Empty;
    }
}

using NPI_Registry.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPI_Registry.NPIRegistry
{
    internal class NPIDetails
    {
        private const string host = $"https://npiregistry.cms.hhs.gov/api/";

        public static async Task<HCPDTO> GetHCPDetails(int npi)
        {
            string urlParams = $@"?number={npi.ToString()}&version=2.1";
            return await Web.API.RunAsync<HCPDTO>(host, urlParams);
        }
    }
}

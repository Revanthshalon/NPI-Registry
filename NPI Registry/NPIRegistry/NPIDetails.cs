using NPI_Registry.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPI_Registry.NPIRegistry
{
    internal class NPIDetails
    {
        private const string host = $"https://npiregistry.cms.hhs.gov/api/";

        public static async Task<HCPDTO> GetHCPDetails(int npi)
        {
            string urlParams = $@"?number={npi.ToString()}&version=2.1";
            return await Tools.API.RunAsync<HCPDTO>(host, urlParams);
        }

        public static ICollection<NPIDTO> GetHCPList(string filepath)
        {
            ICollection<NPIDTO> list = (ICollection<NPIDTO>)Tools.CSV.ReadCsv(filepath);
            return list;
        }
        public static async Task<ICollection<HCPDTO>> GetHCPDetailsList(IEnumerable<NPIDTO> NPIList)
        {
            List<HCPDTO> HCPDetails = new List<HCPDTO>();
            foreach (var response in NPIList)
            {
                string urlParams = $@"?number={response.NPIId}&version=2.1";
                var hcpDetails = await Tools.API.RunAsync<HCPDTO>(host, urlParams);
                hcpDetails.UserWaveID = response.UserWaveId;
                HCPDetails.Add(hcpDetails);
            }
            return HCPDetails;
        }
        
    }
}

using NPI_Registry.DTO;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NPI_Registry.Tools
{
    internal class CSV
    {
        public static IEnumerable<NPIDTO> ReadCsv(string path)
        {
            string[] lines = File.ReadAllLines(path);
            IEnumerable<NPIDTO> result = lines.Select(line =>
            {
                string[] data = line.Split(",");
                return new NPIDTO()
                {
                    UserWaveId = int.Parse(data[0]),
                    NPIId = int.Parse(data[1])
                };
            });
            return result;
        }
    }
}

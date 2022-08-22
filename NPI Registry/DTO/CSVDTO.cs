using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPI_Registry.DTO
{
    internal class CSVDTO
    {
        public long UserWaveId { get; set; }
        public long NPI { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CertificateLastUpdatedDate { get; set; }
        public string Taxonomy { get; set; }
        public string Status { get; set; }

    }
}

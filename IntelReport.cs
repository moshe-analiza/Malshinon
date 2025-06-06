using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Malshinon
{
    internal class IntelReport
    {
        public int reporeterId { get; set; }
        public int targetId { get; set; }
        public DateTime reportDate { get; set; }
        public string reportText { get; set; }
        public override string ToString()
        {
            return $"reporeterId: {reporeterId}\n" +
                $"targetId: {targetId}\n" +
                $"reportDate: {reportDate}\n" +
                $"reportText: {reportText}\n";
        }
    }
}

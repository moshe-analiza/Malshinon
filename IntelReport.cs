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
        int reporeterId { get; set; }
        int targetId { get; set; }
        DateTime reportDate { get; set; }
        string reportText { get; set; }
        public override string ToString()
        {
            return $"reporeterId: {reporeterId}" +
                $"targetId: {targetId}" +
                $"reportDate: {reportDate}" +
                $"reportText: {reportText}";
        }
    }
}

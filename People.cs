using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mysqlx.Expect.Open.Types.Condition.Types;

namespace Malshinon
{
    internal class People
    {
        public int id { get; set; }
        public string name { get; set; }
        public int secretCode { get; set; }
        public string type { get; set; }
        public int numReports { get; set; }
        public int numMentions { get; set; }

        public override string ToString()
        {
            return $"id: {id}\n" +
                $"name: {name}\n" +
                $"secretCode: {secretCode}\n" +
                $"type: {type}\n" +
                $"numReports: {numReports}\n" +
                $"numMentions: {numMentions}\n";
        }
    }
}

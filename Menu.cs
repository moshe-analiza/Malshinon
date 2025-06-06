using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Google.Protobuf.Compiler;

namespace Malshinon
{
    internal class Menu
    {
        static UseSQL DB = UseSQL.Instance();
        public void Start()
        {
            DB.DatabaseName = "Malshinon";
            DB.UserName = "root";
            DB.Server = "127.0.0.1";
            string choice;
            while (true)
            {
                Console.WriteLine(
                "Enter Your choice: \n" +
                "options: \n" +
                "1 - see all people table\n" +
                "2 - see all intels table\n" +
                "5 - Exit\n"
                );
                choice = Console.ReadLine();
                switch (choice) 
                {
                    case "1":
                        List<Dictionary<string, object>> peoplesRaw = DB.RunQuery("SELECT * FROM peoples");
                        List<People> peoples = new List<People>();
                        foreach (var item in peoplesRaw)
                        {
                            People person = new People
                            {
                                id = item.ContainsKey("id") ? Convert.ToInt32(item["id"]) : 0,
                                numReports = item.ContainsKey("numReports") ? Convert.ToInt32(item["numReports"]) : 0,
                                secretCode = item.ContainsKey("secretCode") ? Convert.ToInt32(item["secretCode"]) : 0,
                                numMentions = item.ContainsKey("numMentions") ? Convert.ToInt32(item["numMentions"]) : 0,
                                name = item.ContainsKey("name") ? item["name"]?.ToString() : null,
                                type = item.ContainsKey("type") ? item["type"]?.ToString() : null,
                            };
                            peoples.Add(person);
                        }
                        foreach (var item in peoples)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case "2":
                        List<Dictionary<string, object>> intelsRaw = DB.RunQuery("SELECT * FROM intelreports");
                        List<IntelReport> intels = new List<IntelReport>();
                        foreach (var item in intelsRaw)
                        {
                            IntelReport intel = new IntelReport
                            {
                                reporeterId = item.ContainsKey("reporeterId") ? Convert.ToInt32(item["reporeterId"]) : 0,
                                targetId = item.ContainsKey("targetId") ? Convert.ToInt32(item["targetId"]) : 0,
                                reportDate = item.ContainsKey("reportDate") && item["reportDate"] != null
                                ? Convert.ToDateTime(item["reportDate"])
                                : default(DateTime),
                                reportText = item.ContainsKey("reportText") ? item["reportText"]?.ToString() : null,
                            };
                            intels.Add(intel);
                        }
                        foreach (var item in intels)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Please type valid choice!");
                        break;
                }
            }
        }
    }
}

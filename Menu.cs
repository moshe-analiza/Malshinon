using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

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
                        List<Dictionary<string, object>> peoples = DB.RunQuery("SELECT * FROM peoples");
                        foreach (var item in peoples)
                        {
                            foreach (var kvp in item)
                            {
                                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                            }
                            Console.WriteLine();
                        }
                        break;
                    case "2":
                        List<Dictionary<string, object>> intels = DB.RunQuery("SELECT * FROM intelreports");
                        foreach (var item in intels)
                        {
                            foreach (var kvp in item)
                            {
                                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                            }
                            Console.WriteLine();
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

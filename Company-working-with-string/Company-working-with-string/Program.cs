using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] input = { "RP Solutions, Australia, Cloud Telephony, Level 7", "Marketrac Inc, Baharain, Machine Learning, Level 9", "RP Solutions, Australia, Machine Learning, Level 10", "NewScore, Baharain, Auth API, Level 5", "Sun Fintech, Sweden, Auth API, Level 6", "RG.com, Australia, Email API, Level 10 ", "RP Solutions, Sweden, Auth API, Level 6", "RP Solutions, Australia, Storage, Level 3", "Marketrac Inc, Baharain, Storage, Level 3", "FPRP Solutions, Baharain, Storage, Level 2", "NewScore, Baharain, Storage, Level 4" };
            List<String> comanyFlg = processData(input);
            foreach (string p in comanyFlg)
                Console.WriteLine(p);
        }
        public static List<string> processData(String[] input)
        {
            Dictionary<string, bool> comanyFlg = new Dictionary<string, bool>();
            Dictionary<string, string> apiLevel = new Dictionary<string, string>();
            foreach (string line in input)
            {
                string[] elements = line.Split(',');
                string company = elements[0].Trim();
                string api = elements[2].Trim();
                string level = elements[3].Trim();
                if (apiLevel.ContainsKey(api))
                {
                    int first = int.Parse(apiLevel[api].Split()[1]);
                    int second = int.Parse(level.Split()[1]);
                    if (first < second)
                        apiLevel[api] = level;
                }
                else
                    apiLevel.Add(api, level);

                if (!comanyFlg.ContainsKey(company))
                    comanyFlg.Add(company, false);
            }

            foreach (string line in input)
            {
                string[] elements = line.Split(',');
                string company = elements[0].Trim();
                string api = elements[2].Trim();
                string level = elements[3].Trim();
                if (level != apiLevel[api])
                    comanyFlg[company] = true;
            }
            return comanyFlg.Where(item => item.Value == false).Select(x => x.Key).ToList();
        }
    }
}

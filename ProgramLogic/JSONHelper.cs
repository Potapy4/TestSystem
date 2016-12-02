using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProgramLogic
{
    public class JSONHelper
    {
        private readonly string path;
        public List<Test> Tests { get; private set; }

        public JSONHelper()
        {
            path = "Tests.json";
            Tests = new List<Test>();
            ReadTests();
        }

        public void WriteTest(Test test)
        {
            Tests.Add(test);
            try
            {
                using (StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8))
                {
                    string output = JsonConvert.SerializeObject(Tests, Formatting.Indented);
                    sw.WriteLine(output);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ReadTests()
        {
            string json = null;
            using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
            {
                json = sr.ReadToEnd();
            }

            if (!string.IsNullOrEmpty(json))
            {
                Tests.AddRange(JsonConvert.DeserializeObject<List<Test>>(json));
            }
        }

        public int GetMaxID()
        {
            if (Tests.Count > 0)
            {
                int id = Tests.Max(x => x.TestID);
                return ++id;
            }
            else
            {
                return 0;
            }
        }
    }
}

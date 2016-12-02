using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProgramLogic
{
    static class RandomExtensions
    {
        public static void Shuffle<T>(this Random rng, T[] array)
        {
            int n = array.Length;
            while (n > 1)
            {
                int k = rng.Next(n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }
    }

    public class JSONHelper
    {
        private readonly string path;
        private static Random rand;
        public List<Test> Tests { get; private set; }

        public JSONHelper()
        {
            path = "Tests.json";
            Tests = new List<Test>();
            rand = new Random();

            ReadTests();
        }

        public void WriteTest(Test test)
        {
            Tests.Add(test);
            Tests.ForEach(x => RandomizeAnswers(x)); // Randomize answers before save
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

        public void RandomizeAnswers(Test test)
        {
            test.Questions.ForEach(x =>
            {
                string answerId = x.AnswerChoices[x.AnswerId];
                rand.Shuffle(x.AnswerChoices);
                x.AnswerId = Array.IndexOf(x.AnswerChoices, answerId);
            });
        }
    }
}

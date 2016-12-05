using Newtonsoft.Json;
using System.Collections.Generic;

namespace ProgramLogic
{
    public class Test
    {
        public int TestID { get; set; }
        public string TestName { get; set; }
        public List<Question> Questions = new List<Question>();

        //public Test(string TestName, int TestID)
        //{           
        //    this.TestName = TestName;
        //    this.TestID = TestID;
        //}        
    }
}
using System.Collections.Generic;

namespace ProgramLogic
{
    public class Test
    {
        public static int TestID { get; private set; }
        public List<Question> Questions = new List<Question>();
        public string TestName { get; private set; }

        public Test(string TestName)
        {
            ++TestID;
            this.TestName = TestName;
        }
        public void InitializeTestID(int id)
        {
            TestID = id;
        }
    }
}
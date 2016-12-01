namespace ProgramLogic
{
    public class Question
    {
        private const int maxChoices = 4;
        public string Text { get; set; }
        public string[] AnswerChoices = new string[maxChoices];
        public int AnswerId { get; set; }
    }
}
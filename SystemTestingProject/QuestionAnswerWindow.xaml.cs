using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SystemTestingProject
{
    /// <summary>
    /// Interaction logic for QuestionAnswerWindow.xaml
    /// </summary>
    public partial class QuestionAnswerWindow : Window
    {
        int position;
        string login;
        ProgramLogic.Test test = new ProgramLogic.Test();
        List<string> rightAnswers = new List<string>();
        List<string> userAnswers = new List<string>();
        List<int> answer = new List<int>();
        public QuestionAnswerWindow(ProgramLogic.Test test, string login)
        {
            InitializeComponent();
            this.login = login;
            foreach (var item in test.Questions)
            {
                rightAnswers.Add(item.AnswerChoices[item.AnswerId]);
                userAnswers.Add("");
                answer.Add(0);
            }
            this.test = test;
            textBox.Text = test.Questions[position].Text;
            radioButton1.Content = test.Questions[position].AnswerChoices[0];
            radioButton2.Content = test.Questions[position].AnswerChoices[1];
            radioButton3.Content = test.Questions[position].AnswerChoices[2];
            radioButton4.Content = test.Questions[position].AnswerChoices[3];
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (position - 1 >= 0)
            {
                position--;
                button1.Content = "Next";
                textBox.Text = test.Questions[position].Text;
                radioButton1.Content = test.Questions[position].AnswerChoices[0];
                radioButton2.Content = test.Questions[position].AnswerChoices[1];
                radioButton3.Content = test.Questions[position].AnswerChoices[2];
                radioButton4.Content = test.Questions[position].AnswerChoices[3];
                radioButton1.IsChecked = radioButton2.IsChecked = radioButton3.IsChecked = radioButton4.IsChecked = false;
                if (answer[position] != 0)
                {
                    switch (answer[position])
                    {
                        case 1: radioButton1.IsChecked = true; break;
                        case 2: radioButton2.IsChecked = true; break;
                        case 3: radioButton3.IsChecked = true; break;
                        case 4: radioButton4.IsChecked = true; break;
                    }
                }
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (position + 2 == test.Questions.Count)
                button1.Content = "End Test";
            if (position + 1 < test.Questions.Count)
            {
                position++;
                textBox.Text = test.Questions[position].Text;
                radioButton1.Content = test.Questions[position].AnswerChoices[0];
                radioButton2.Content = test.Questions[position].AnswerChoices[1];
                radioButton3.Content = test.Questions[position].AnswerChoices[2];
                radioButton4.Content = test.Questions[position].AnswerChoices[3];
                radioButton1.IsChecked = radioButton2.IsChecked = radioButton3.IsChecked = radioButton4.IsChecked = false;
                if (answer[position] != 0)
                {
                    switch (answer[position])
                    {
                        case 1: radioButton1.IsChecked = true; break;
                        case 2: radioButton2.IsChecked = true; break;
                        case 3: radioButton3.IsChecked = true; break;
                        case 4: radioButton4.IsChecked = true; break;
                    }
                }
            }
            else
            {
                int result = 0;
                for (int i = 0; i < test.Questions.Count; i++)
                {
                    if (rightAnswers[i] == userAnswers[i])
                        result += 1;
                }
                ResultExamp.SetExampResult(test.TestName, login, result);
                MessageBox.Show("Your result is " + result);
                this.Close();
            }
        }

        private void radioButton1_Checked(object sender, RoutedEventArgs e)
        {
            userAnswers[position] = radioButton1.Content.ToString();
            answer[position] = 1;
        }

        private void radioButton2_Checked(object sender, RoutedEventArgs e)
        {
            userAnswers[position] = radioButton2.Content.ToString();
            answer[position] = 2;
        }

        private void radioButton3_Checked(object sender, RoutedEventArgs e)
        {
            userAnswers[position] = radioButton3.Content.ToString();
            answer[position] = 3;
        }

        private void radioButton4_Checked(object sender, RoutedEventArgs e)
        {
            userAnswers[position] = radioButton4.Content.ToString();
            answer[position] = 4;
        }
    }
}

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
    /// Interaction logic for AddTestWindow.xaml
    /// </summary>
    public partial class AddTestWindow : Window
    {
        ProgramLogic.Test test = new ProgramLogic.Test();
        ProgramLogic.JSONHelper json = new ProgramLogic.JSONHelper();
        public AddTestWindow()
        {
            InitializeComponent();
            var gridView = new GridView();
            this.listView.View = gridView;
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Question",
                DisplayMemberBinding = new Binding("Question"),
                Width = 210
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Answer",
                DisplayMemberBinding = new Binding("Answer"),
                Width = 210
            });
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            test.Questions.Add(new ProgramLogic.Question { Text = textBox5.Text, AnswerId = 0,
                AnswerChoices =new string[] {textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text } });
            listView.Items.Add(new { Question = textBox5.Text, Answer = textBox1.Text });
            textBox5.Text = textBox4.Text = textBox3.Text = textBox2.Text = textBox1.Text = string.Empty;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            test.TestName = textBox.Text;
            textBox.Text = string.Empty;
            json.WriteTest(test);
            MessageBox.Show("Added");
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

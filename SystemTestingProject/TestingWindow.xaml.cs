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
    /// Interaction logic for TestingWindow.xaml
    /// </summary>
    ///
    public partial class TestingWindow : Window
    {
        string login;
        public TestingWindow(string admin, string login)
        {
            InitializeComponent();
            this.login = login;
            var gridView = new GridView();
            this.listView.View = gridView;
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Name",
                DisplayMemberBinding = new Binding("Name"),
                Width = 100
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Result",
                DisplayMemberBinding = new Binding("Result"),
                Width = 100
            });


            if (admin=="Admin")
            {
                button.IsEnabled = true;
                button1.IsEnabled = true;
            }
            UpdateListView();
        }
        
        ///Метод для оновлення Ліста зі всіма тестами
        public void UpdateListView()
        {
            listView.Items.Clear();
            ProgramLogic.JSONHelper json = new ProgramLogic.JSONHelper();
            foreach (var item in json.Tests)
            {
                listView.Items.Add(new {Name = item.TestName, Result = ResultExamp.GetResult(item.TestName, login) });
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            new AddAdminWindow().ShowDialog();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            new AddTestWindow().ShowDialog();
        }

        ///Кнопка для старту вибраного тесту 
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedIndex != -1)
            {
                ProgramLogic.JSONHelper json = new ProgramLogic.JSONHelper();
                new QuestionAnswerWindow(json.Tests[listView.SelectedIndex], login).ShowDialog();
                UpdateListView();
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

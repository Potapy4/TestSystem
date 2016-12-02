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
    public partial class TestingWindow : Window
    {
        public TestingWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            new AddAdminWindow().Show();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            new AddTestWindow().Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            new QuestionAnswerWindow().Show();
        }
    }
}

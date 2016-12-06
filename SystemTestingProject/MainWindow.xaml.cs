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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SystemTestingProject
{ 
    /*!
	\author Скеба Роман, Потапенко Микита, Шалагінов Андрій
	\version 1.0
	\date 06.12.2016
    */
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        ///Кнопка призначена для реєстрації
        private void button_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow reg=new RegistrationWindow();
            reg.ShowDialog();
            textBox.Text = reg.UserNameTextBox.Text;
            passwordBox.Password = reg.PasswordTextBox.Password;
        }

        ///Кнопка призначена для входу
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            bool corect = false;
            string admin = null;
            Connect db = new Connect();
            foreach (var item in db.Users.ToArray())
            {
                if(item.Username==textBox.Text)
                {
                    if(item.Password==passwordBox.Password)
                    {
                        corect = true;
                        if (item.isAdmin == true)
                            admin = "Admin";
                        break;
                    }
                }
            }
            if (corect == true)
            {
                new TestingWindow(admin, textBox.Text).Show();
                this.Close();
            }
            else
                MessageBox.Show("Not Corect Data");
        }
    }
}

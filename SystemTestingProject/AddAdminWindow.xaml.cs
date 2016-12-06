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
    /// Interaction logic for AddAdminWindow.xaml
    /// </summary>
    public partial class AddAdminWindow : Window
    {
        Connect db = new Connect();
        User []users;
        public AddAdminWindow()
        {
            InitializeComponent();
            users = db.Users.ToArray();
            UpdateComboBox();
        }

        /// Метод для обновлення юзерів
        public void UpdateComboBox()
        {
            comboBox.Items.Clear();
            foreach (var item in db.Users)
            {
                if (item.isAdmin != true)
                    comboBox.Items.Add(item.Username);
            }
        }
        
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// Кнопка для призначення вибраного юзера адіністратором
        private void button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in users)
            {
                if (comboBox.SelectedItem.ToString() == item.Username)
                {
                    db.Users.Remove(item);
                    db.SaveChanges();
                    db.Users.Add(new User
                    {
                        isAdmin = true,
                        Firstname = item.Firstname,
                        Lastname = item.Lastname,
                        Username = item.Username,
                        Date = item.Date,
                        City = item.City,
                        Sex = item.Sex,
                        Email = item.Email,
                        Password = item.Password,
                        UserId = item.UserId
                    });
                    db.SaveChanges();
                    MessageBox.Show("Added");
                }
            }
            UpdateComboBox();
        }
    }
}

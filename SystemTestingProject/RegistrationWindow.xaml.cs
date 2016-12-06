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
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        ///Метод для для добавлення юзера в базу даних
        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string male = "";
                if (MaleRadioButton.IsSealed == true)
                    male = "Male";
                else
                    male = "Female";
                Connect db = new Connect();
                db.Users.Add(new User() { Username = UserNameTextBox.Text, Sex = male, City = CityTextBox.Text, Date = BirthDayDatePicker.SelectedDate.Value, Firstname = FirstNameTextBox.Text, Lastname = LastNameTextBox.Text, Password = PasswordTextBox.Password, Email = EmailTextBox.Text, PhoneNumber = "", isAdmin = false });

                db.SaveChanges();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

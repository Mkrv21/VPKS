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
using Microsoft.EntityFrameworkCore;


namespace PencilApp
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();

        }

        private void authorizationWindowButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }

        private void registrationButton_Click(object sender, RoutedEventArgs e)
        {
            string Login = textBoxLogin.Text.Trim();
            string Password = passBox.Password.Trim();
            string Password2 = passBox2.Password.Trim();
            string Phone = textBoxPhone.Text.Trim().ToLower();

            if (Login.Length < 5)
            {
                textBoxLogin.ToolTip = "Поле введено не корректно!";
                textBoxLogin.Background = Brushes.DarkRed;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;

                if (Password.Length < 5)
                {
                    passBox.ToolTip = "Поле введено не корректно!";
                    passBox.Background = Brushes.DarkRed;
                }
                else
                {
                    passBox.ToolTip = "";
                    passBox.Background = Brushes.Transparent;

                    if (Password2 != Password)
                    {
                        passBox2.ToolTip = "Поле введено не корректно!";
                        passBox2.Background = Brushes.DarkRed;
                    }
                    else
                    {
                        passBox2.ToolTip = "";
                        passBox2.Background = Brushes.Transparent;

                        if (Phone.Length == 11)
                        {
                            textBoxPhone.ToolTip = "Поле введено не корректно!";
                            textBoxPhone.Background = Brushes.DarkRed;
                        }
                        else
                        {
                            textBoxPhone.ToolTip = "";
                            textBoxPhone.Background = Brushes.Transparent;

                            using (PencilDBContext db = new PencilDBContext())
                            {
                                var user = db.Users.FirstOrDefault(x => x.Login == textBoxLogin.Text || x.Pass == passBox.Password);
                                if (user != null)
                                {
                                    MessageBox.Show("Такой пользователь уже существует!");
                                }
                                User useradd = new User
                                {

                                    Login = textBoxLogin.Text,
                                    Phone = textBoxPhone.Text,
                                    Pass = passBox.Password,
                                    Role = "user"
                                };
                                db.Users.Add(useradd);
                                db.SaveChanges();
                                MessageBox.Show("Рестрация прошла успешно!");
                                MainWindow mainWindow = new MainWindow();
                                mainWindow.Show();
                                Hide();
                            }

                        }
                    }
                }
            }
        }
    }
}


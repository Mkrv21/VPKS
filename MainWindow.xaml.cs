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

namespace PencilApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int DUser;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void registrationWindowButton_Click(object sender, RoutedEventArgs e)
        { 
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            this.Hide();
        }

        private void authorizationButton_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string password = passBox.Password.Trim();
            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Поле введено не корректно!";
                textBoxLogin.Background = Brushes.DarkRed;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;

                if (password.Length < 5)
                {
                    passBox.ToolTip = "Поле введено не корректно!";
                    passBox.Background = Brushes.DarkRed;
                }
                else
                {
                    passBox.ToolTip = "";
                    passBox.Background = Brushes.Transparent;

                    using (PencilDBContext context = new PencilDBContext())
                    {
                        foreach (User authUser in context.Users)
                        {
                            if (textBoxLogin.Text == authUser.Login && passBox.Password == authUser.Pass && authUser.Role == "admin")
                            {
                                if (authUser.Role == "admin")
                                {
                                    DUser = (int)authUser.IdUsers;
                                    CatalogAdminWindow admin = new CatalogAdminWindow();
                                    admin.Show();
                                    Hide();
                                    return;
                                }
                            }

                            else if (textBoxLogin.Text == authUser.Login && passBox.Password == authUser.Pass && authUser.Role == "user")
                            {
                                if (authUser.Role == "user")
                                {
                                    DUser = (int)authUser.IdUsers;
                                    CatalogUserWindow userForm = new CatalogUserWindow();
                                    userForm.Show();
                                    Hide();
                                    return;

                                }
                            }


                        }

                    }
                    MessageBox.Show("Invalid login or password!");

                }

            }
        }

        private void textBoxLogin_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

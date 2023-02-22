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

namespace PencilApp
{
    /// <summary>
    /// Логика взаимодействия для PersonalAccountWindow.xaml
    /// </summary>
    public partial class PersonalAccountWindow : Window
    {
        public PersonalAccountWindow()
        {
            InitializeComponent();
            using (PencilDBContext context = new PencilDBContext())
            {
                foreach (User authUser in context.Users)
                {
                    if (authUser.IdUsers == MainWindow.DUser)
                    {
                        LoginLabel.Content = authUser.Login.ToString();
                        PhoneLabel.Content = authUser.Phone.ToString();
                    }
                }
            }
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {


            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            using (PencilDBContext context = new PencilDBContext())
            {
                foreach (User authUser in context.Users)
                {
                    if (authUser.IdUsers == MainWindow.DUser && authUser.Role == "admin")
                    {
                        if (authUser.Role == "admin")
                        {
                            CatalogAdminWindow admin = new CatalogAdminWindow();
                            admin.Show();
                            Hide();
                            return;
                        }
                    }

                    else if (authUser.IdUsers == MainWindow.DUser && authUser.Role == "user")
                    {
                        if (authUser.Role == "user")
                        {

                            CatalogUserWindow userForm = new CatalogUserWindow();
                            userForm.Show();
                            Hide();
                            return;

                        }
                    }


                }
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            EditButton.Visibility = Visibility.Hidden;
            LoginLabel.Visibility = Visibility.Hidden;
            PhoneLabel.Visibility = Visibility.Hidden;
            LoginTextBox.Visibility = Visibility.Visible;
            PhoneTextBox.Visibility = Visibility.Visible;
            SaveChangeButton.Visibility = Visibility.Visible;
            using (PencilDBContext context = new PencilDBContext())
            {
                foreach (User authUser in context.Users)
                {
                    if (authUser.IdUsers == MainWindow.DUser)
                    {
                        LoginTextBox.Text = authUser.Login.ToString();
                        PhoneTextBox.Text = authUser.Phone.ToString();
                    }
                }
            }
        }

        private void SaveChangeButton_Click(object sender, RoutedEventArgs e)
        {
            using (PencilDBContext db = new PencilDBContext())
            {
                var user = db.Users.FirstOrDefault(x => x.Login == LoginTextBox.Text);
                if (user != null)
                {
                    MessageBox.Show("Данный логин уже существует!");
                }
                foreach (User authUser in db.Users)
                {
                    if (authUser.IdUsers == MainWindow.DUser)
                    {
                        authUser.Login = LoginTextBox.Text;
                        authUser.Phone = PhoneTextBox.Text;
                        //db.Users.Update(authUser);
                        db.SaveChanges();
                        MessageBox.Show("Изменения сохранены!");
                        this.Close();
                        PersonalAccountWindow personalAccountWindow = new PersonalAccountWindow();
                        personalAccountWindow.Show();

                    }

                }

            }
        }
    }

}
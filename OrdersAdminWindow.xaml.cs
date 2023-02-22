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
    /// Логика взаимодействия для OrdersAdminWindow.xaml
    /// </summary>
    public partial class OrdersAdminWindow : Window
    {
        public OrdersAdminWindow()
        {
            InitializeComponent();
            PencilDBContext db = new PencilDBContext();
            
            List<Order> orders = db.Orders.ToList();
            DGridOrders.ItemsSource = PencilDBContext.GetContext().Orders.ToList();
            
           

        }

        private void PersonalAcwindowButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            PersonalAccountWindow personalAccountWindow = new PersonalAccountWindow();
            personalAccountWindow.Show();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void ProductsWindowButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            CatalogAdminWindow catalogAdminWindow = new CatalogAdminWindow();
            catalogAdminWindow.Show();
        }
    }
}

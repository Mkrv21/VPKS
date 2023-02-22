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
    /// Логика взаимодействия для CatalogAdminWindow.xaml
    /// </summary>
    public partial class CatalogAdminWindow : Window
    {
        public CatalogAdminWindow()
        {
            InitializeComponent();
            PencilDBContext db = new PencilDBContext();
            List<Product> products = db.Products.ToList();
            DGridProducts.ItemsSource = PencilDBContext.GetContext().Products.ToList();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var productsForRemoving = DGridProducts.SelectedItems.Cast<Product>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {productsForRemoving.Count()}элемента(ов)?", "Внимание",
             MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                try
                {
                    PencilDBContext.GetContext().Products.RemoveRange(productsForRemoving);
                    PencilDBContext.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    DGridProducts.ItemsSource = PencilDBContext.GetContext().Products.ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
        }

        private void PersonalAcwindowButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            PersonalAccountWindow personalAccountWindow = new PersonalAccountWindow();
            personalAccountWindow.Show();

        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {   
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        { AddPrductWindow addPrductWindow = new AddPrductWindow();
            addPrductWindow.Show();
            this.Hide();

        }

        private void OrdersWindowButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            OrdersAdminWindow ordersAdminWindow = new OrdersAdminWindow();
            ordersAdminWindow.Show();

        }
    }
}

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
    /// Логика взаимодействия для CatalogUserWindow.xaml
    /// </summary>
    public partial class CatalogUserWindow : Window
    {
        public CatalogUserWindow()
        {
            InitializeComponent();
            PencilDBContext db = new PencilDBContext();
            List<Product> products = db.Products.ToList();
            DGridProducts.ItemsSource = PencilDBContext.GetContext().Products.ToList();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        { 
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

        }

        private void PersonalAcwindowButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            PersonalAccountWindow personalAccountWindow = new PersonalAccountWindow();
            personalAccountWindow.Show();
        }

        private void BagButton_Click(object sender, RoutedEventArgs e)
        {
            var ProductsInbag = DGridProducts.SelectedItems.Cast<Product>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {ProductsInbag.Count()}элемента(ов)?", "Внимание",
             MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes);
            BagWindow bagWindow = new BagWindow();
            bagWindow.Show();
            this.Hide();
        }
    }
}

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
    /// Логика взаимодействия для AddPrductWindow.xaml
    /// </summary>
    public partial class AddPrductWindow : Window
    {
        public AddPrductWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string Name = textBoxName.Text.Trim();
            int Quantity = Convert.ToInt32( textBoxQuantity.Text.Trim());
            int Cost = Convert.ToInt32(textBoxCost.Text.Trim());
            string Description = textBoxName.Text.Trim();

                            using (PencilDBContext db = new PencilDBContext())
                            {
                                var product = db.Products.FirstOrDefault(x => x.Name == textBoxName.Text || x.Quantity == Convert.ToInt32(textBoxQuantity.Text) || x.Cost == Convert.ToInt32(textBoxCost.Text) );
                                if (product != null)
                                {
                                    MessageBox.Show("Такой товар уже существует!");
                                }
                                Product productadd = new Product
                                {

                                    Name = textBoxName.Text,
                                    Quantity = Convert.ToInt32(textBoxQuantity.Text),
                                    Cost = Convert.ToInt32(textBoxCost.Text),
                                    Description = textBoxDescription.Text,
                                };
                                db.Products.Add(productadd);
                                db.SaveChanges();
                                MessageBox.Show("Товар успешно добавлен!");
                                CatalogAdminWindow catalogAdminWindow = new CatalogAdminWindow();
                                catalogAdminWindow.Show();
                                Hide();
                            }

                        }
                }
            }
        
    
   


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

namespace DictionaryFabricApplication
{
    public partial class AddCardTypeKnittedView : UserControl, ICardType
    {
        private byte[] _imageData = null!;

        public AddCardTypeKnittedView()
        {
            InitializeComponent();
            using (FabricDbContext db = new())
            {
                WeaveCombobox.ItemsSource = db.KnittedWeaves.ToList();
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextbox.Text) == false && WeaveCombobox.SelectedIndex != -1 && string.IsNullOrWhiteSpace(CompositionTextbox.Text) == false)
            {
                using (FabricDbContext db = new())
                {
                    db.TypeKnitteds.Add(new TypeKnitted()
                    {
                        Name = NameTextbox.Text,
                        Image = _imageData,
                        WeaveId = ((KnittedWeave)WeaveCombobox.SelectedItem).Id,
                        Composition = CompositionTextbox.Text
                    });
                    db.SaveChanges();
                    TableView.AddCardsWindow.Close();
                }
            }
            else
            {
                MessageBox.Show("Необходимо заполнить все поля", "Внимание!");
            }
        }

        private void GridPhoto_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PlaceForPhoto.Source = ImageWorker.LoadImage(out _imageData);
        }
    }
}

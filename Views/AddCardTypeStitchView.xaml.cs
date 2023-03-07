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
    /// <summary>
    /// Логика взаимодействия для AddCardTypeStitchView.xaml
    /// </summary>
    public partial class AddCardTypeStitchView : UserControl, ICardType
    {
        private byte[] _imageData = null!;

        public AddCardTypeStitchView()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextbox.Text) == false)
            {
                using (FabricDbContext db = new())
                {
                    db.TypeStitches.Add(new TypeStitch()
                    {
                        Name = NameTextbox.Text,
                        Image = _imageData
                    });
                    db.SaveChanges();
                }
                TableView.AddCardsWindow.Close();
            }
            else
            {
                MessageBox.Show("Необходимо ввести наименование", "Внимание!");
            }
        }

        private void GridPhoto_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PlaceForPhoto.Source = ImageWorker.LoadImage(out _imageData);
        }
    }
}

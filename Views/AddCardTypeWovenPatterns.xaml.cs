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
    /// Логика взаимодействия для AddCardTypeWovenPatterns.xaml
    /// </summary>
    public partial class AddCardTypeWovenPatterns : UserControl, ICardType
    {
        private byte[] _imageData = null!;

        public AddCardTypeWovenPatterns()
        {
            InitializeComponent();
            using (FabricDbContext db = new())
            {
                PatternsCombobox.ItemsSource = db.Patterns.ToList();
            }

        }

        private void GridPhoto_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PlaceForPhoto.Source = ImageWorker.LoadImage(out _imageData);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextbox.Text) == false 
                && string.IsNullOrWhiteSpace(ColorTextbox.Text) == false 
                && string.IsNullOrWhiteSpace(NumberDesignTextbox.Text) == false 
                && string.IsNullOrWhiteSpace(CompositionTextbox.Text) == false 
                && string.IsNullOrWhiteSpace(RapportTextbox.Text) == false
                && PatternsCombobox.SelectedIndex != -1)
            {
                using (FabricDbContext db = new())
                {
                    db.TypesWovenPatterns.Add(new TypesWovenPattern()
                    {
                        Name = NameTextbox.Text,
                        Color = ColorTextbox.Text,
                        NumberDesign = NumberDesignTextbox.Text,
                        Composition = CompositionTextbox.Text,
                        Rapport = RapportTextbox.Text,
                        Image = _imageData,
                        IdPattern = ((Pattern)PatternsCombobox.SelectedItem).Id
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
    }
}

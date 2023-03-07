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
    public partial class AddCardDictionaryFabricView : UserControl, ICardType
    {
        public AddCardDictionaryFabricView()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextbox.Text) == false && string.IsNullOrWhiteSpace(DescriptionTextbox.Text) == false)
            {
                using (FabricDbContext db = new())
                {
                    db.DictionaryFabrics.Add(new DictionaryFabric()
                    {
                        Name = NameTextbox.Text,
                        Description = DescriptionTextbox.Text
                    });
                    db.SaveChanges();
                }
                TableView.AddCardsWindow.Close();
            }
        }
    }
}

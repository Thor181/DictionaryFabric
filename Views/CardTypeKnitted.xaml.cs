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
    public partial class CardTypeKnitted : UserControl, ICardType
    {
        static private List<Button> buttons = new List<Button>();
        static ITable SelectedCard = null!;

        public CardTypeKnitted(ITable sourceObject)
        {
            InitializeComponent();
            buttons.Add(CardButton);
            CardGrid.DataContext = sourceObject;
        }

        private void CardButton_Click(object source, RoutedEventArgs e)
        {
            if (SelectedCard != null)
            {
                foreach (var item in buttons)
                {
                    item.Background = new SolidColorBrush(Colors.Transparent);
                    item.Opacity = 0;
                }
            }

            SelectedCard = (ITable)CardGrid.DataContext;
            CardButton.Background = new SolidColorBrush(Colors.LightGray);
            CardButton.Opacity = 0.3d;
        }
        public static ITable GetSelectedCard()
        {
            return SelectedCard;
        }

        private void CardButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.RightButton == MouseButtonState.Pressed)
            {
                if (((TableView.InnerTypeKnitted)CardGrid.DataContext).Image != null)
                {
                    PictureWindow window = new PictureWindow((ITable)CardGrid.DataContext);
                    window.Show();
                }

            }
        }
    }
}

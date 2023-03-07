using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
    public partial class CardWevingWeave : UserControl, ICardType
    {
        static private ITable SelectedCard { get; set; } = null!;
        static private List<Button> ButtonsList = new List<Button>();

        public CardWevingWeave(ITable sourceObject)
        {
            InitializeComponent();
            CardGrid.DataContext = sourceObject;
            ButtonsList.Add(CardButton);
        }

        private void CardButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedCard != null)
            {
                foreach (var item in ButtonsList)
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
                if (((WevingWeave)CardGrid.DataContext).Image != null)
                {
                    PictureWindow window = new PictureWindow((ITable)CardGrid.DataContext);
                    window.Show();
                }

            }
        }
    }
}

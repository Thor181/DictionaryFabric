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
    /// Логика взаимодействия для SetCardsStackPanel.xaml
    /// </summary>
    public partial class SetCardsStackPanel : UserControl
    {
        public SetCardsStackPanel(CardWevingWeave cardOne = null!, CardWevingWeave cardTwo = null!, CardWevingWeave cardThree = null!)
        {
            InitializeComponent();
            CanvasStackPanel.Children.Add(cardOne);
            CanvasStackPanel.Children.Add(cardTwo);
            CanvasStackPanel.Children.Add(cardThree);
        }       
    
    }

}

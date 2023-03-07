using System;
using System.Collections.Generic;
using System.Drawing;
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

namespace DictionaryFabricApplication
{
    /// <summary>
    /// Логика взаимодействия для PictureWindow.xaml
    /// </summary>
    public partial class PictureWindow : Window
    {
        public PictureWindow(ITable table)
        {
            InitializeComponent();
            ImageBackground.DataContext = table;
        }
    }
}

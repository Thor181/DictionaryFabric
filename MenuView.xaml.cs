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
    /// Логика взаимодействия для MenuView.xaml
    /// </summary>
    public partial class MenuView : UserControl
    {
        MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

        public MenuView()
        {
            InitializeComponent();
        }

        private void WevingWeaveButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MainCanvas.Children.Clear();
            mainWindow.MainCanvas.Children.Add(new TableView(new WevingWeave()));
        }

        private void TypesFabricButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MainCanvas.Children.Clear();
            mainWindow.MainCanvas.Children.Add(new TableView(new TypesFabric()));
        }

        private void KnittedWeaveButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MainCanvas.Children.Clear();
            mainWindow.MainCanvas.Children.Add(new TableView(new KnittedWeave()));
        }

        private void TypeKnittedButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MainCanvas.Children.Clear();
            mainWindow.MainCanvas.Children.Add(new TableView(new TypeKnitted()));
        }

        private void TypesStitchButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MainCanvas.Children.Clear();
            mainWindow.MainCanvas.Children.Add(new TableView(new TypeStitch()));
        }

        private void TypesWovenPatternsButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MainCanvas.Children.Clear();
            //mainWindow.MainCanvas.Children.Add(new TableView(new TypesWovenPattern()));
            mainWindow.MainCanvas.Children.Add(new TypesWovenPatternsMenuView());
        }

        private void DictionaryFabricButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MainCanvas.Children.Clear();
            mainWindow.MainCanvas.Children.Add(new TableView(new DictionaryFabric()));
        }

        private void ThreadsButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MainCanvas.Children.Clear();
            mainWindow.MainCanvas.Children.Add(new TableView(new Thread()));
        }
    }
}

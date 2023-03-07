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
    public partial class TypesWovenPatternsMenuView : UserControl
    {
        MainWindow mainWindow = (MainWindow)App.Current.MainWindow;

        public TypesWovenPatternsMenuView()
        {
            InitializeComponent();
            
        }

        private void GeometryButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MainCanvas.Children.Clear();
            mainWindow.MainCanvas.Children.Add(new TableView(new TypesWovenPattern(), "Геометрия"));
        }

        private void AbstractionButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MainCanvas.Children.Clear();
            mainWindow.MainCanvas.Children.Add(new TableView(new TypesWovenPattern(), "Абстракция"));
        }

        private void LinesButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MainCanvas.Children.Clear();
            mainWindow.MainCanvas.Children.Add(new TableView(new TypesWovenPattern(), "Полосы"));
        }

        private void FlowersButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MainCanvas.Children.Clear();
            mainWindow.MainCanvas.Children.Add(new TableView(new TypesWovenPattern(), "Цветы"));
        }

        private void AnimalsButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MainCanvas.Children.Clear();
            mainWindow.MainCanvas.Children.Add(new TableView(new TypesWovenPattern(), "Животные"));
        }

        private void TexturesButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MainCanvas.Children.Clear();
            mainWindow.MainCanvas.Children.Add(new TableView(new TypesWovenPattern(), "Текстуры материалов"));
        }

        private void NatureButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MainCanvas.Children.Clear();
            mainWindow.MainCanvas.Children.Add(new TableView(new TypesWovenPattern(), "Природа"));
        }

        private void TropicalArtButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MainCanvas.Children.Clear();
            mainWindow.MainCanvas.Children.Add(new TableView(new TypesWovenPattern(), "Тропические рисунки"));
        }

        private void AnimalAndBirdsButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MainCanvas.Children.Clear();
            mainWindow.MainCanvas.Children.Add(new TableView(new TypesWovenPattern(), "Животные/птицы"));
        }

        private void EticalArtsButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MainCanvas.Children.Clear();
            mainWindow.MainCanvas.Children.Add(new TableView(new TypesWovenPattern(), "Этический рисунок"));
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MainCanvas.Children.Clear();
            mainWindow.MainCanvas.Children.Add(new MenuView());
        }
    }
}

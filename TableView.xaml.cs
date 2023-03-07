using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Microsoft.EntityFrameworkCore;


namespace DictionaryFabricApplication
{
    public partial class TableView : UserControl
    {
        private List<ITable> ItemsFromTable { get; set; } = null!;

        ITable WorkTable { get; set; } = null!;

        MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;

        public static Window AddCardsWindow = null!;

        private bool _isTypeWovenPatternsTable = false;
        
        public TableView(ITable table)
        {
            InitializeComponent();
            WorkTable = table;
            TableNameTextblock.Text = GetTableName(table);
            LoadCardsToMainWrapPanel();
        }
        public TableView(ITable table, string patternName)
        {
            InitializeComponent();
            WorkTable = table;
            TableNameTextblock.Text = GetTableName(table);
            using (FabricDbContext db = new())
            {
                LoadCardsToMainWrapPanelTypesWoven(db.TypesWovenPatterns.Include(x => x.IdPatternNavigation).Where(x => x.IdPatternNavigation!.Name == patternName).ToList());
            }
        }


        private void LoadCardsToMainWrapPanelTypesWoven(List<TypesWovenPattern> sourceTypesWoven)
        {
            _isTypeWovenPatternsTable = true;
            foreach (TypesWovenPattern item in sourceTypesWoven)
            {
                MainWrapPanel.Children.Add(new CardTypesWovenPatternsView(item));
            }
        }

        

        private string GetTableName(ITable table)
        {
            return table switch
            {
                WevingWeave => "Ткацкие переплетения",
                TypesFabric => "Виды тканей",
                KnittedWeave => "Трикотажные переплетения",
                TypeKnitted => "Типы трикотажа",
                TypeStitch => "Типы вышивки (стежков)",
                TypesWovenPattern => "Виды тканых рисунков",
                DictionaryFabric => "Справочник тканей",
                Thread => "Виды нитей",
                _ => "Undefined"
            };
        }

        private void LoadCardsToMainWrapPanel(bool searchMode = false, string searchText = null!)
        {
            MainWrapPanel.Children.Clear();
            if (searchMode == true)
            {
                ItemsFromTable = LoadDataToItemsList(WorkTable, true, searchText);
            }
            else
            {
                ItemsFromTable = LoadDataToItemsList(WorkTable);
            }
            foreach (ITable item in ItemsFromTable)
            {
                switch (item)
                {
                    case WevingWeave:
                        MainWrapPanel.Children.Add(new CardWevingWeave(item));
                        break;
                    case TypesFabric:
                    case InnerTypeFabric:
                        MainWrapPanel.Children.Add(new CardTypesFabric(item));
                        break;
                    case KnittedWeave:
                        MainWrapPanel.Children.Add(new CardKnittedWeave(item));
                        break;
                    case TypeKnitted:
                    case InnerTypeKnitted:
                        MainWrapPanel.Children.Add(new CardTypeKnitted(item));
                        break;
                    case TypeStitch:
                        MainWrapPanel.Children.Add(new CardTypeStitch(item));
                        break;
                    case TypesWovenPattern:
                        MainWrapPanel.Children.Add(new CardTypesWovenPatternsView(item));
                        break;
                    case DictionaryFabric:
                        MainWrapPanel.Children.Add(new CardDictionaryFabric(item));
                        break;
                    case Thread:
                        MainWrapPanel.Children.Add(new CardThreads(item));
                        break;
                    default:
                        break;
                }
            }
        }

        private List<ITable> LoadDataToItemsList(ITable workTable, bool editMode = false, string searchText = null!)
        {
            if (editMode == false)
            {
                using (FabricDbContext db = new FabricDbContext())
                {
                    return workTable switch
                    {
                        WevingWeave => new List<ITable>(db.WevingWeaves),
                        TypesFabric => new List<ITable>(db.TypesFabrics.Join(db.WevingWeaves, x => x.WeaveId, y => y.Id, (x, y) => new InnerTypeFabric() { Id = x.Id, Name = x.Name, Image = x.Image, WeaveName = y.Name, Composition = x.Composition, Density = x.Density })),
                        KnittedWeave => new List<ITable>(db.KnittedWeaves),
                        TypeKnitted => new List<ITable>(db.TypeKnitteds.Join(db.KnittedWeaves, x => x.WeaveId, y => y.Id, (x, y) => new InnerTypeKnitted { Id = x.Id, Name = x.Name, Image = x.Image, WeaveName = y.Name, Composition = x.Composition })),
                        TypeStitch => new List<ITable>(db.TypeStitches),
                        TypesWovenPattern => new List<ITable>(db.TypesWovenPatterns),
                        DictionaryFabric => new List<ITable>(db.DictionaryFabrics),
                        Thread => new List<ITable>(db.Threads),
                        _ => throw new NullReferenceException("Undefined entity")
                    };
                }
            }
            else
            {
                using (FabricDbContext db = new FabricDbContext())
                {
                    return workTable switch
                    {
                        WevingWeave => new List<ITable>(db.WevingWeaves.Where(x => x.Name.Contains(searchText))),
                        TypesFabric => new List<ITable>(db.TypesFabrics.Join(db.WevingWeaves, x => x.WeaveId, y => y.Id, (x, y) => new InnerTypeFabric() { Id = x.Id, Name = x.Name, Image = x.Image, WeaveName = y.Name, Composition = x.Composition, Density = x.Density }).Where(x=>x.Name.Contains(searchText) || x.WeaveName!.Contains(searchText) || x.Composition!.Contains(searchText) || x.Density.ToString()!.Contains(searchText))),
                        KnittedWeave => new List<ITable>(db.KnittedWeaves.Where(x => x.Name!.Contains(searchText))),
                        TypeKnitted => new List<ITable>(db.TypeKnitteds.Join(db.KnittedWeaves, x => x.WeaveId, y => y.Id, (x, y) => new InnerTypeKnitted { Id = x.Id, Name = x.Name, Image = x.Image, WeaveName = y.Name, Composition = x.Composition }).Where(x => x.Name!.Contains(searchText) || x.WeaveName!.Contains(searchText) || x.Composition!.Contains(searchText))),
                        TypeStitch => new List<ITable>(db.TypeStitches.Where(x => x.Name!.Contains(searchText))),
                        TypesWovenPattern => new List<ITable>(db.TypesWovenPatterns.Where(x => x.Name!.Contains(searchText) || x.Color!.Contains(searchText) || x.NumberDesign!.Contains(searchText) || x.Composition!.Contains(searchText) || x.Rapport!.Contains(searchText))),
                        DictionaryFabric => new List<ITable>(db.DictionaryFabrics.Where(x => x.Name!.Contains(searchText))),
                        Thread => new List<ITable>(db.Threads.Where(x => x.Name!.Contains(searchText) || x.Composition!.Contains(searchText))),
                        _ => throw new NullReferenceException("Undefined entity")
                    };
                }
            }   
        }

        public class InnerTypeFabric : ITable
        {
            public long Id { get; set; }
            public string Name { get; set; } = null!;
            public string? WeaveName { get; set; }
            public string? Composition { get; set; }
            public double? Density { get; set; }
            public byte[]? Image { get; set; }
        }
        public class InnerTypeKnitted : ITable
        {
            public long Id { get; set; }
            public string? Name { get; set; }
            public string? WeaveName { get; set; }
            public string? Composition { get; set; }
            public byte[]? Image { get; set; }
        }

        private void AddNewCardButton_Click(object sender, RoutedEventArgs e)
        {
            switch (WorkTable)
            {
                case WevingWeave:
                    AddCardsWindow = new AddNewCardWindow(new AddCardWevingWeaveView());
                    break;
                case TypesFabric:
                    AddCardsWindow = new AddNewCardWindow(new AddCardTypesFabricView());
                    break;
                case KnittedWeave:
                    AddCardsWindow = new AddNewCardWindow(new AddCardKnittedWeaveView());
                    break;
                case TypeKnitted:
                    AddCardsWindow = new AddNewCardWindow(new AddCardTypeKnittedView());
                    break;
                case TypeStitch:
                    AddCardsWindow = new AddNewCardWindow(new AddCardTypeStitchView());
                    break;
                case TypesWovenPattern:
                    AddCardsWindow = new AddNewCardWindow(new AddCardTypeWovenPatterns());
                    break;
                case DictionaryFabric:
                    AddCardsWindow = new AddNewCardWindow(new AddCardDictionaryFabricView());
                    break;
                case Thread:
                    AddCardsWindow = new AddNewCardWindow(new AddCardThreadView());
                    break;
                default:
                    break;
            }
            AddCardsWindow.ShowDialog();
            LoadCardsToMainWrapPanel();
        }
        private void DeleteCardButton_Click(object sender, RoutedEventArgs e)
        {
            using (FabricDbContext db = new())
            {
                try
                {
                    switch (WorkTable)
                    {
                        case WevingWeave:
                            db.Remove(CardWevingWeave.GetSelectedCard());
                            break;
                        case TypesFabric:
                            TypesFabric removableItemTypeFabric = (TypesFabric)db.TypesFabrics.Where(x => x.Id == ((InnerTypeFabric)CardTypesFabric.GetSelectedCard()).Id).First();
                            db.Remove(removableItemTypeFabric);
                            break;
                        case KnittedWeave:
                            db.Remove(CardKnittedWeave.GetSelectedCard());
                            break;
                        case TypeKnitted:
                            TypeKnitted removableItemTypeKnitted = db.TypeKnitteds.Where(x => x.Id == ((InnerTypeKnitted)CardTypeKnitted.GetSelectedCard()).Id).First();
                            db.Remove(removableItemTypeKnitted);
                            break;
                        case TypeStitch:
                            db.Remove(CardTypeStitch.GetSelectedCard());
                            break;
                        case TypesWovenPattern:
                            db.Remove(CardTypesWovenPatternsView.GetSelectedCard());
                            break;
                        case DictionaryFabric:
                            db.Remove(CardDictionaryFabric.GetSelectedCard());
                            break;
                        case Thread:
                            db.Remove(CardThreads.GetSelectedCard());
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Необходимо выбрать карточку", "Внимание!");
                    return;
                }
                finally
                {
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Необходимо выбрать объект, который не связан с другими сущностями", "Внимание!");
                    }
                }
            }
            LoadCardsToMainWrapPanel();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MainCanvas.Children.Clear();
            if (_isTypeWovenPatternsTable == true)
            {
                mainWindow.MainCanvas.Children.Add(new TypesWovenPatternsMenuView());
            }
            else
            {
                mainWindow.MainCanvas.Children.Add(new MenuView());
            }
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        { 
            LoadCardsToMainWrapPanel(true, SearchTextbox.Text);
        }
    }
}

using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BeginWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isDarkTheme = false;

        public MainWindow()
        {
            InitializeComponent();

            WindowState = WindowState.Maximized; // Щоб на весь екран відкривалось

            MainGrid.SetResourceReference(Grid.BackgroundProperty, "MainGridBackgroundColor");
            SecondGrid.SetResourceReference(Grid.BackgroundProperty, "SecondGridBackgroundColor");

            // Кнопка зміни теми
            Button btnChangeTheme = new Button()
            {
                Content = "Змінити тему",
                Width = 150,
                Height = 50,
                FontSize = 16,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            btnChangeTheme.SetResourceReference(Button.BackgroundProperty, "MainGridBackgroundColor");
            btnChangeTheme.SetResourceReference(Button.ForegroundProperty, "TextColor");
            MainGrid.Children.Add(btnChangeTheme);

            // Текст поточної теми
            Label lblTheme = new Label()
            {
                Content = "Поточна тема: Світла",
                FontSize = 20,
                Margin = new Thickness(30),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top
            };
            lblTheme.SetResourceReference(Label.ForegroundProperty, "TextColor");
            MainGrid.Children.Add(lblTheme);

            // Список котів
            Label lblCats = new Label()
            {
                Content = string.Join("\n", new List<MyCats>
                {
                    new MyCats("Мурка", 2, "Чорний", "Дівчинка"),
                    new MyCats("Кузя", 1, "Чорний", "Хлопчик"),
                    new MyCats("Сніжок", 1, "Білий", "Хлопчик"),
                    new MyCats("Петро", 0, "Чорний", "Пацан"),
                    new MyCats("Лола", 0, "Чорний", "Дівчинка"),
                    new MyCats("Чері", 0, "Чорно-оранжевий", "Дівчинка"),
                    new MyCats("Сімба", 0, "Скумбрія", "Хлопчик"),
                    new MyCats("Сніжинка", 0, "Білий", "Дівчинка")
                }),
                FontSize = 20,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Bottom,
                Margin = new Thickness(20)
            };
            lblCats.SetResourceReference(Label.ForegroundProperty, "TextColor");
            MainGrid.Children.Add(lblCats);

            btnChangeTheme.Click += (s, e) =>
            {
                isDarkTheme = !isDarkTheme;
                string theme = isDarkTheme ? "DarkTheme.xaml" : "LightTheme.xaml";
                lblTheme.Content = isDarkTheme ? "Поточна тема: Темна" : "Поточна тема: Світла";
                try
                {
                    ResourceDictionary newTheme = new ResourceDictionary
                    {
                        Source = new Uri(theme, UriKind.Relative)
                    };

                    MainGrid.Resources.MergedDictionaries.Clear();
                    MainGrid.Resources.MergedDictionaries.Add(newTheme);

                    SecondGrid.Resources.MergedDictionaries.Clear();
                    SecondGrid.Resources.MergedDictionaries.Add(newTheme);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка: {ex.Message}");
                }
            };
        }
    }
}

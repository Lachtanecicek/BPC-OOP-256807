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

namespace patnactka;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private Board board;
    private Button[,] buttons = new Button[4, 4];

    public MainWindow()
    {
        InitializeComponent();
        InitGame();
    }

    private void InitGame()
    {
        board = new Board();
        GameGrid.Children.Clear();
        GameGrid.RowDefinitions.Clear();
        GameGrid.ColumnDefinitions.Clear();

        for (int i = 0; i < 4; i++)
        {
            GameGrid.RowDefinitions.Add(new RowDefinition());
            GameGrid.ColumnDefinitions.Add(new ColumnDefinition());
        }

        for (int row = 0; row < 4; row++)
        {
            for (int col = 0; col < 4; col++)
            {
                var tile = board.Tiles[row, col];
                var btn = new Button
                {
                    FontSize = 24,
                    Margin = new Thickness(2),
                    Background = Brushes.LightGray,
                    Content = tile.IsEmpty ? "" : tile.Value.ToString(),
                    Visibility = tile.IsEmpty ? Visibility.Hidden : Visibility.Visible
                };

                btn.Click += Tile_Click;
                Grid.SetRow(btn, row);
                Grid.SetColumn(btn, col);
                GameGrid.Children.Add(btn);
                buttons[row, col] = btn;
            }
        }
    }

    private void Tile_Click(object sender, RoutedEventArgs e)
    {
        var clickedButton = sender as Button;
        int row = Grid.GetRow(clickedButton);
        int col = Grid.GetColumn(clickedButton);
        var tile = board.Tiles[row, col];

        if (board.CanMove(tile))
        {
            board.Move(tile);
            UpdateUI();

            if (board.IsSolved())
                MessageBox.Show("Vyhrál jsi! 🎉", "Hotovo", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

    private void UpdateUI()
    {
        for (int row = 0; row < 4; row++)
        {
            for (int col = 0; col < 4; col++)
            {
                var tile = board.Tiles[row, col];
                var btn = buttons[row, col];

                btn.Content = tile.IsEmpty ? "" : tile.Value.ToString();
                btn.Visibility = tile.IsEmpty ? Visibility.Hidden : Visibility.Visible;
            }
        }
    }
}
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
using System.Windows.Threading;
using System.IO;
using Microsoft.VisualBasic;

namespace patnactka;

public partial class MainWindow : Window
{
    private Board board; //herní deska
    private Button[,] buttons = new Button[4, 4]; //herní pole (4x4 bloky)

    public MainWindow()
    {
        InitializeComponent();

        timer = new DispatcherTimer();
        timer.Interval = TimeSpan.FromMilliseconds(100);
        timer.Tick += Timer_Tick;

        InitGame();
    }


    private void InitGame() //zapnutí hry
    {
        board = new Board();
        board.Shuffle(); //rozmíchání
        moveCount = 0; //vynuluje počet tahů

        GameGrid.Children.Clear();
        GameGrid.RowDefinitions.Clear();
        GameGrid.ColumnDefinitions.Clear();

        //inicializace herního pole
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
        //satrt časovače
        startTime = DateTime.Now;
        timer.Start();
    }

    //při kliknutí na blok
    private void Tile_Click(object sender, RoutedEventArgs e)
    {
        if (isPaused)
            return;

        var clickedButton = sender as Button;
        int row = Grid.GetRow(clickedButton);
        int col = Grid.GetColumn(clickedButton);
        var tile = board.Tiles[row, col];

        if (board.CanMove(tile))
        {
            board.Move(tile);
            moveCount++; //přidá tah
            UpdateUI();

            if (board.IsSolved())
            {
                timer.Stop();
                SetButtonsEnabled(false);
                PauseButton.IsEnabled = false;

                var nickname = Microsoft.VisualBasic.Interaction.InputBox("Zadejte svoji přezdívku:", "Výhra!", "Hráč");

                if (string.IsNullOrWhiteSpace(nickname))
                    nickname = "Neznámý hráč";

                SaveScore(nickname, elapsedTime, moveCount);

                MessageBox.Show($"Vyhrál jsi za {elapsedTime:mm\\:ss\\.ff} s {moveCount} tahy!", "Hotovo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }

    //update rozhraní při inicializaci a při změnách (pohybování bloky)
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
    
    //časovače
    private DispatcherTimer timer;
    private DateTime startTime;
    private TimeSpan elapsedTime;

    //pause tlačítko (aktivováno/vypnuto)
    private bool isPaused = false;
    private void SetButtonsEnabled(bool isEnabled)
    {
        foreach (var btn in buttons)
        {
            if (btn != null)
                btn.IsEnabled = isEnabled;
        }
    }

    //počítadlo tahů
    private int moveCount = 0;

    //časovač
    private void Timer_Tick(object sender, EventArgs e)
    {
        elapsedTime = DateTime.Now - startTime;
        TimerText.Text = $"Čas: {elapsedTime:mm\\:ss\\.ff}";
    }

    //ukládání výsledků do souboru
    private void SaveScore(string nickname, TimeSpan time, int moves)
    {
        string score = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {nickname} | {time.Minutes:D2}:{time.Seconds:D2}.{time.Milliseconds / 10:D2} | Tahy: {moves}";
        File.AppendAllText("scores.txt", score + Environment.NewLine);
    }



    //všechna ostatní tlačítka (co se děje po jejich aktivaci)

    //pozastavit
    private void PauseButton_Click(object sender, RoutedEventArgs e)
    {
        if (isPaused)
        {
            timer.Start();
            PauseButton.Content = "Pauza";
            SetButtonsEnabled(true);
        }
        else
        {
            timer.Stop();
            PauseButton.Content = "Pokračovat";
            SetButtonsEnabled(false);
        }
        isPaused = !isPaused;
    }

    //nová hra
    private void NewGame_Click(object sender, RoutedEventArgs e)
    {
        isPaused = false;
        PauseButton.Content = "Pauza";
        PauseButton.IsEnabled = true;

        InitGame();
    }

    //výsledky
    private void ShowScores_Click(object sender, RoutedEventArgs e)
    {
        if (File.Exists("scores.txt"))
        {
            var lines = File.ReadAllLines("scores.txt");
            var scores = new List<(string Line, TimeSpan Time)>();

            foreach (var line in lines)
            {
                try
                {
                    var parts = line.Split('|');
                    if (parts.Length >= 3)
                    {
                        var timePart = parts[2].Trim();

                        if (TimeSpan.TryParseExact(timePart, "mm\\:ss\\.ff", null, out var parsedTime))
                        {
                            scores.Add((line, parsedTime));
                        }
                    }
                }
                catch
                {
                }
            }

            var sortedScores = scores.OrderBy(s => s.Time).Select(s => s.Line);

            var sortedText = string.Join(Environment.NewLine, sortedScores);

            MessageBox.Show(sortedText, "Výsledky (seřazeno podle času)", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        else
        {
            MessageBox.Show("Žádné výsledky zatím nejsou.", "Výsledky", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

    //konec (ukončení programu)
    private void Exit_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}
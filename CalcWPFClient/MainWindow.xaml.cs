using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows;
using CalcWebAPI;
using System.Windows.Controls;

namespace CalcWpfClient
{
    public partial class MainWindow : Window
    {
        private readonly HttpClient _client;

        public MainWindow()
        {
            InitializeComponent();

            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:7125/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var operand1 = decimal.Parse(Operand1TextBox.Text);
                var operand2 = decimal.Parse(Operand2TextBox.Text);
                var operation = ((ComboBoxItem)OperationComboBox.SelectedItem).Content.ToString();

                var calcDTO = new CalcDTO
                {
                    Operand1 = operand1,
                    Operand2 = operand2,
                    Operation = operation
                };

                var response = await _client.PostAsJsonAsync("api/calc", calcDTO);
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadAsStringAsync();
                ResultTextBlock.Text = $"Výsledek: {result}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Chyba: {ex.Message}");
            }
        }
    }
}

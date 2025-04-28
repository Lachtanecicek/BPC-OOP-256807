using CalcWebApp;
using CalcWebAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CalcWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private HttpClient _client;

        [BindProperty]
        public CalcModel CalcModel { get; set; }

        public List<SelectListItem> OperationList { get; } = new()
    {
        new SelectListItem { Value = "plus", Text = "+" },
        new SelectListItem { Value = "minus", Text = "-" },
        new SelectListItem { Value = "krat", Text = "*" },
        new SelectListItem { Value = "deleno", Text = "/" }
    };

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:7125/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostCalculate()
        {
            var calcDTO = new CalcDTO
            {
                Operand1 = CalcModel.Operand1,
                Operand2 = CalcModel.Operand2,
                Operation = CalcModel.Operation
            };

            var response = await _client.PostAsJsonAsync("api/calc", calcDTO);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            ViewData["ResultValue"] = result;

            return Page();
        }
    }
}

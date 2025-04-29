using Microsoft.AspNetCore.Mvc;
using CalcWebAPI;

namespace CalcWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalcController : ControllerBase
    {
        [HttpPost(Name = "Calculate")]
        public decimal Post([FromBody] CalcDTO calcDTO)
        {
            return calcDTO.Operation switch
            {
                "plus" => calcDTO.Operand1 + calcDTO.Operand2,
                "minus" => calcDTO.Operand1 - calcDTO.Operand2,
                "krat" => calcDTO.Operand1 * calcDTO.Operand2,
                "deleno" => calcDTO.Operand2 != 0 ? calcDTO.Operand1 / calcDTO.Operand2 : 0,
                _ => 0
            };
        }
    }
}

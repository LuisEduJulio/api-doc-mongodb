using api_doc_mongodb.domain.Dtos;
using api_doc_mongodb.domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_doc_mongodb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet("getcustomer")]
        public async Task<IActionResult> GetByObjectIdAsync([FromQuery] string ObjectId)
        {
            var ResultService = await _customerService.GetByObjectIdAsync(ObjectId);

            if (ResultService.Success)
                return Ok(ResultService);
            else
                return BadRequest(ResultService);
        }
        [HttpGet("customers")]
        public async Task<IActionResult> GetCustomersAsync()
        {
            var ResultService = await _customerService.CustomerAllAsync();

            if (ResultService.Success)
                return Ok(ResultService);
            else
                return BadRequest(ResultService);
        }
        [HttpPost("createcustomer")]
        public async Task<IActionResult> PostCreateCustomerAsync(CustomerCreateDto Customer)
        {
            var ResultService = await _customerService.PostCreateCustomerAsync(Customer);

            if (ResultService.Success)
                return Ok(ResultService);
            else
                return BadRequest(ResultService);
        }
        [HttpPut("updatecustomer")]
        public async Task<IActionResult> UpdateCustomerAsync([FromQuery] string ObjectId, [FromBody] CustomerUpdateDto CustomerUpdateDto)
        {
            var ResultService = await _customerService.UpdateCreateCustomerAsync(ObjectId, CustomerUpdateDto);

            if (ResultService.Success)
                return Ok(ResultService);
            else
                return BadRequest(ResultService);
        }
        [HttpDelete("deletecustomer")]
        public async Task<IActionResult> DeleteCustomerByObjectIdAsync([FromQuery] string ObjectId)
        {
            var ResultService = await _customerService.DeleteCustomerByObjectIdAsync(ObjectId);

            if (ResultService.Success)
                return Ok(ResultService);
            else
                return BadRequest(ResultService);
        }
    }
}

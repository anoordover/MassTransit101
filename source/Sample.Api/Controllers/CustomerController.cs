using System;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Sample.Contracts;

namespace Sample.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public CustomerController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }
        
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id, string customerNumber)
        {
            await _publishEndpoint.Publish<CustomerAccountClosed>(new
            {
                CustomerId = id,
                CustomerNumber = customerNumber
            });

            return Ok();
        }
    }
}
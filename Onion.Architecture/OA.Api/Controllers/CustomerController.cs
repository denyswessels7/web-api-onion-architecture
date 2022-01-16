using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.Core.Interfaces;
using OA.Data;
using System;
using System.Threading.Tasks;

namespace OA.Api.Controllers
{
    /// <summary>
    /// Contains a list of API calls related to the Customer entity
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerRepo)
        {
            _customerService = customerRepo;
        }

        /// <summary>
        /// Returns a list of all customers available
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var customers = await _customerService.GetAll();

            if (customers.NoItems())
            {
                return NotFound();
            }
            return Ok(customers);
        }

        /// <summary>
        /// Returns one customer with a specified matching id.Returns 404 if no match.
        /// </summary>
        /// <param name="id">Id of the customer in question</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetById/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _customerService.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        /// <summary>
        /// Adds a new customer to the system and returns the id of the newly created customer
        /// </summary>
        /// <param name="customer">Customer to be created.Required.Cannot be null</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody]Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("Customer cannot be null");
            }

            var id = await _customerService.Add(customer);
            return Created(string.Empty, id);
        }
    }
}

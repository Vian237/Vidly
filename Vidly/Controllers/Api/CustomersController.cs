using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vidly.Data;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CustomersController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Get: api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.ToList().Select(c => _mapper.Map<CustomerDto>(c));
        }

        //Get: api/customers/5
        [HttpGet("{id}")]
        public ActionResult<CustomerDto> GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();

            return Ok(_mapper.Map<CustomerDto>(customer));
        }

        //Post: api/customers
        [HttpPost]
        public ActionResult<CustomerDto> CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Map the DTO to the Customer entity
            var customer = _mapper.Map<Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            // Optionally, you can return the created customer with its ID
            customerDto.Id = customer.Id; // Set the ID from the created entity

            // Return the created customer with a 201 Created response
            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customerDto);
            //return customerDto;
        }

        //Put: api/customers/5
        [HttpPut("{id}")]
        public ActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (id != customerDto.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            // Map the updated properties from the DTO to the existing entity
            // This assumes that the DTO has the same properties as the Customer entity
            // If you have different property names, you can use AutoMapper to map them
            _mapper.Map(customerDto, customerInDb);

            _context.SaveChanges();

            return NoContent();
        }

        //Delete: api/customers/5
        [HttpDelete("{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                return NotFound();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            // Return a 204 No Content response to indicate successful deletion
            return NoContent();
        }
    }
}

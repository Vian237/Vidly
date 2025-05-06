using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Vidly.Data;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        //Pour utiliser View faudrait que la methode porte le nom de la page a afficher

        private readonly AppDbContext _context;

        public CustomersController()
        {
            _context = new AppDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }
        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
                {
                    new Customer { Id = 1, Name = "John Smith" },
                    new Customer { Id = 2, Name = "Mary Williams" }
                };
        }

        public IActionResult Index()
        {

            var customers = _context.Customers.ToList();
            return View(customers);
        }

        public IActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return View(customer);
        }

    }
}

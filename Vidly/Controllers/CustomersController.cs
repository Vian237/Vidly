using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        //Pour utiliser View faudrait que la methode porte le nom de la page a afficher

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

            var customers = GetCustomers();
            return View(customers);
        }

        public IActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return View(customer);
        }

    }
}

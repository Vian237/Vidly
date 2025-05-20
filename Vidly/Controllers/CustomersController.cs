using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Vidly.Models;
using Vidly.ViewModels;

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
            /*Eager Loading
             le principe de telecharger les tableaux relié
            lors du chargement de l'app*/
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public IActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return View(customer);
        }

        public IActionResult New()
        {
            var membershipTypes = _context.MembershipType.ToList();
            var viewModel = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            //var customer = new Customer();
            //if (!ModelState.IsValid)
            //{
            //    var viewModel = new NewCustomerViewModel
            //    {
            //        Customer = customer,
            //        MembershipTypes = _context.MembershipType.ToList()
            //    };
            //    return View("New", viewModel);
            //}
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

    }
}

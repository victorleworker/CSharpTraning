using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
   
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();

        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult New()
        {
            var membershipType = _context.MembershipType.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipType
            };
            return View(_View.CustomerForm.ToString(), viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipType.ToList()
                };
                return View(_View.CustomerForm.ToString(),viewModel);
            }

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);


                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                
                //TryUpdateModel(customerInDb, "", new string[] { "Name", "Email" });
            }
            _context.SaveChanges();
            return RedirectToAction(_ActionResults.Index.ToString(), _Controller.Customers.ToString());
        }


        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            var ViewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipType.ToList()
            };
            return View(_View.CustomerForm.ToString(), ViewModel);
        }


        // GET: Customers
        public ActionResult Index()
        {
            //var customers = GetCustomers();
            //  var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            //    return View(customers);
            return View();
        }


        public ActionResult Details(int id)
        {
            // var customer = GetCustomers().SingleOrDefault(c => c.Id == id); if (customer == null)
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id); if (customer == null)
                return HttpNotFound();
            return View(customer);
        }


        /*private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "John Smith" },
                new Customer { Id = 2, Name = "Mary Williams" }
            };
        }*/
    }
}
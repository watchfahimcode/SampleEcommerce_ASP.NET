using Ecommerce.Models.EntityModels;
using Ecommerce.Repository;
using Ecommerce.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Ecommerce.WebApp.Controllers
{
    public class CustomerController : Controller
    {

        CustomerRepository _customerRepository;

        public CustomerController()
        {
            _customerRepository= new CustomerRepository();
        }


        public IActionResult Index()
        {
            var customers = _customerRepository.GetAll();

            ICollection<CustomerListViewModel> customerModels = customers.Select(c=> new CustomerListViewModel()
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Phone = c.Phone,

            }).ToList();

            return View(customerModels);

        }

        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CustomerCreate model)
        {

            if (ModelState.IsValid)
            {
                var customer = new Customer()
                {
                    Name = model.Name,
                    Phone = model.Phone,
                    Email = model.Email,

                };

                bool isSuccess = _customerRepository.Add(customer);

                if (isSuccess)
                {
                    return View();
                }
            }

            return View();


        }

        public IActionResult Edit(int? id)
        {   
            if(id == null || id<=0)
            {
                
                ViewBag.Error = "Please Provide Proper ID";  //Viewbag = State Control
                return View();
            }

            var customer = _customerRepository.GetById((int)id);

            if(customer == null)
            {
                ViewBag.Error = "Sorry No Customer Found For this ID";  //Viewbag = State Control
                return View();
            }

            var model = new CustomerEditVm()
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone,
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(CustomerEditVm model)
        {
            if (ModelState.IsValid)
            {
                var customer = _customerRepository.GetById(model.Id);

                if (customer == null)
                {
                    ViewBag.Error = "Customer Not Found to Update";
                    return View(model);
                };

                customer.Name = model.Name;
                customer.Email = model.Email;
                customer.Phone = model.Phone;

                bool isSuccess = _customerRepository.Update(customer);
                if (isSuccess)
                {
                    return RedirectToAction("Index");
                };
            }

            return View(model);
        }
    }
}

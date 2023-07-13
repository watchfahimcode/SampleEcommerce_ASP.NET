using Ecommerce.Models.EntityModels;
using Ecommerce.Models.UtilityModels;
using Ecommerce.Repository;
using Ecommerce.WebApp.Models;
using Ecommerce.WebApp.Models.ProductList;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Net.WebSockets;

namespace Ecommerce.WebApp.Controllers
{
    public class ProductController : Controller
    {

        ProductRepository _productRepository;

        public ProductController()
        {
            _productRepository = new ProductRepository();
        }
        public IActionResult Index(ProductSearchCriteria productSearchCriteria)
        {
            var products = _productRepository.GetAll();

            ICollection<ProductListItem>productModels = products.Select(c=> new ProductListItem()
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                Price = c.Price,
                Category = c.Category,

            }).ToList();

            var productListModel = new ProductListViewModel();
            productListModel.ProductList = productModels;

            return View(productListModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductCreate model)
        {

            if (ModelState.IsValid)
            {
                var product = new Product()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    Category = model.Category,
                };

                bool isSuccess = _productRepository.Add(product);

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

            var product = _productRepository.GetById((int)id);

            if (product == null)
            {
                ViewBag.Error = "Sorry No Product Found For this ID";  //Viewbag = State Control
                return View();
            }

            var model = new ProductEditVM()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Category = product.Category,
            };
            return View(model);
        }

        [HttpPost]

        public IActionResult Edit(ProductEditVM model)
        {
            if (ModelState.IsValid)
            {
                var product = _productRepository.GetById(model.Id);

                if (product == null)
                {
                    ViewBag.Error = "Product Not Found to Update";
                    return View(model);
                };

                product.Name = model.Name;
                product.Description = model.Description;
                product.Price = model.Price;
                product.Category = model.Category;

                bool isSuccess = _productRepository.Update(product);
                if (isSuccess)
                {
                    return RedirectToAction("Index");
                };
            }

            return View(model);
        }
    }
}

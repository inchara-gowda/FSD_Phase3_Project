using DotNet_Phase3_Project.Models;
using DotNet_Phase3_Project.Services;
using DotNet_Phase3_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project3Phase3MVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Project3Phase3MVC.Controllers
{
    public class AdminController : Controller
    {

        //List<Product> _product;
        IRepo<Product> _ProductRepo;
        IRepo<Order> _OrderRepo;
        public AdminController(IRepo<Product> product, IRepo<Order> order)
        {

            //_product = new List<Product>();
            //_ProductRepo = new MockProductRepo();
            _ProductRepo = product;
            _OrderRepo = order;

        }
        // view homepage
        public ActionResult Index()
        {

            return View(_ProductRepo.GetAll());
        }

        // View add product page
        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }
        // add route
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _ProductRepo.Add(product);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Details(int id)
        {
            Product product = _ProductRepo.Get(id);
            Console.WriteLine(product);
            return View(product);
        }
        [HttpGet]
        public ActionResult Order(int? id)
        {
            if (id != null && id >= 0)
            {
                OrderViewModel model = new OrderViewModel()
                {
                    ProducttoOrder = _ProductRepo.Get((int)id),
                    OrderDetails = new Order()
                    {
                        ProductID = (int)id
                    }
                };
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Order(int id, Order OrderDetails)
        {

            if (ModelState.IsValid)
            {
                if (_ProductRepo.GetAll().Count(x => x.ProductID == id) >= 1)
                {
                    OrderDetails.ProductID = id;
                    _OrderRepo.Add(OrderDetails);
                    return RedirectToAction("Aproved");
                }
                else
                {
                    return View();
                }

            }
            else
            {
                return View(new OrderViewModel()
                {
                    OrderDetails = OrderDetails,
                    ProducttoOrder = _ProductRepo.Get(id)
                });
            }

        }

        public ActionResult Aproved()
        {
            ViewBag.Message = "Your Aproved page.";

            return View();
        }

        public ActionResult OrderList()
        {
            ViewBag.Message = "Your OrderList page.";

            return View(_OrderRepo.GetAll());
        }

        public ActionResult ProductList()
        {
            ViewBag.Message = "Your ProductList page.";

            return View(_ProductRepo.GetAll());
        }

        [HttpGet]
        public ActionResult SignIn()
        {
            ViewBag.Message = "";

            return View();
        }

        [HttpPost]
        public ActionResult SignIn(Login model)
        {
            if (ModelState.IsValid)
            {
                if (model.UserName == "Admin" && model.Password == "123")
                {

                    return RedirectToAction("Option", model);

                }

                else
                {
                    // ltrMessage.Text = "Please fill required values";
                    ViewBag.Message = "Invalid credentails";

                    return View("SignIn");
                }
            }
            else
            {
                return View();
            }


        }
        public ActionResult Option()
        {

            return View();
        }
        [HttpGet]
        public ActionResult DeleteProduct(int id)
        {
            Product product = _ProductRepo.Get(id);
     
            return View(product);
        }

        [HttpPost]
        public ActionResult DeleteProduct(Product product)
        {
            _ProductRepo.Delete(product);
            return RedirectToAction("ProductList");
        }

        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            Product product = _ProductRepo.Get(id);

            return View(product);
        }


        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}

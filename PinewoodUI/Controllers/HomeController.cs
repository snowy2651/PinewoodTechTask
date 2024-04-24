using Microsoft.AspNetCore.Mvc;
using PinewoodUI.Models;
using System.Diagnostics;


namespace PinewoodUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }



        public ActionResult GetCustomer()
        {

            IEnumerable<CustomerViewModel> customer = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5207/api/Customer");


              
                var responseTask = client.GetAsync("Customer");

                responseTask.Wait();


                var result = responseTask.Result;

  
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<CustomerViewModel>>();
                    readTask.Wait();

                    customer = readTask.Result;
                }
                else
                {
                   
                    customer = Enumerable.Empty<CustomerViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }

                 responseTask = client.GetAsync("Customer");
                return View(customer);
            }
        
        
    }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

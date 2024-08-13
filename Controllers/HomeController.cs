using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using web_ban_do_an.Data;
//using web_ban_do_an.Migrations;
using web_ban_do_an.Models;
using web_ban_do_an.Services;
using X.PagedList;
using X.PagedList.Extensions;


namespace web_ban_do_an.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        private readonly ILogger<HomeController> _logger;
        private readonly ProductService _productService;
        

        public HomeController(ILogger<HomeController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public async Task<IActionResult> Index(int? page)
        {
            int pageSize = 8; // S? l??ng s?n ph?m trên m?i trang
            int pageNumber = page ?? 1; // Trang hi?n t?i, m?c ??nh là 1
            var products = await _productService.GetAllProductsAsync();
            var pagedProducts = products.ToPagedList(pageNumber, pageSize);
            return View(pagedProducts);
        }

        public IActionResult SanPhamTheoLoai(int id)
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

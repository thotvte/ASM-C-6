using Microsoft.AspNetCore.Mvc;
using web_ban_do_an.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using web_ban_do_an.Models;

namespace web_ban_do_an.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
    public class HomeAdminController : Controller
    {
        private readonly DataContext _dbContext;

        public HomeAdminController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("DanhMucSanPham")]
        public IActionResult DanhMucSanPham()
        {
            var lstSanPham = _dbContext.Product.ToList();
            return View(lstSanPham);
        }
        [Route("ThemSanPhamMoi")]
        [HttpGet]
        public IActionResult ThemSanPhamMoi()
        {
            return View();
        }
        [Route("ThemSanPhamMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemSanPhamMoi(Products products)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Product.Add(products);
                _dbContext.SaveChanges();
                return RedirectToAction("DanhMucSanPham");
            }
            return View(products);

        }

        // -------------------------------

        [Route("SuaSanPham")]
        [HttpGet]
        public IActionResult SuaSanPham(int id)
        {
            var sanpham = _dbContext.Product.Find(id);
            return View(sanpham);
        }
        [Route("SuaSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaSanPhamMoi(Products products)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Entry(products).State = EntityState.Modified;
                _dbContext.Product.Add(products);
                _dbContext.SaveChanges();
                return RedirectToAction("DanhMucSanPham", "HomeAdmin");
            }
            return View(products);

        }
        [Route("XoaSanPham")]
        [HttpGet]
        public IActionResult XoaSanPham(int id)
        {
            var sanpham = _dbContext.Product.Find(id);
            if (sanpham == null)
            {
                return NotFound();
            }
            _dbContext.Remove(_dbContext.Product.Find(id));
            _dbContext.SaveChanges();
            TempData["Message"] = "Sản phẩm đả được xóa";
            return RedirectToAction("DanhMucSanPham", "HomeAdmin");

        }

        
    } 
}

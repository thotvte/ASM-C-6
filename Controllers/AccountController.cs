using Microsoft.AspNetCore.Mvc;
using web_ban_do_an.Data;
using web_ban_do_an.Models;

namespace web_ban_do_an.Controllers
{
    public class AccountController : Controller
    {
        private readonly DataContext _dbContext;

        public AccountController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Login(string UserName, string Password)
        {
            return View("~/Views/Shared/_LayoutLoginRegister.cshtml");
        }
        public IActionResult LoginPost(string UserName, string Password)
        {
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
            {
                ViewBag.ErrorMessage = "Username or Password cannot be empty.";
                return View("~/Views/Shared/_LayoutLoginRegister.cshtml");
            }

            var user = _dbContext.AccountCus
                .FirstOrDefault(u => u.UserName == UserName && u.Password == Password);

            if (user != null)
            {
                // Lưu tên người dùng vào session
                HttpContext.Session.SetString("UserName", user.UserName);

                // Chuyển hướng tới trang quản trị
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Tài khoản không hợp lệ
                ViewBag.ErrorMessage = "Invalid Username or Password.";
                return View("~/Views/Shared/_LayoutLoginRegister.cshtml");
            }
        }


        [HttpPost]
        public IActionResult RegisterPost(string UserName, string Password, string Email)
        {
            // Kiểm tra xem các trường có rỗng không
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Email))
            {
                ViewBag.ErrorMessage = "All fields are required.";
                return View("~/Views/Shared/_LayoutLoginRegister.cshtml");
            }

            // Kiểm tra xem Username hoặc Email đã tồn tại hay chưa
            var existingUser = _dbContext.AccountCus
                .FirstOrDefault(u => u.UserName == UserName || u.Email == Email);

            if (existingUser != null)
            {
                ViewBag.ErrorMessage = "Username or Email already exists.";
                return View("~/Views/Shared/_LayoutLoginRegister.cshtml");
            }

            // Tạo một tài khoản mới
            var newUser = new AccountCus
            {
                UserName = UserName,
                Password = Password, // Bạn nên sử dụng hàm băm mật khẩu để bảo mật
                Email = Email,
                createdAt = DateTime.Now
            };

            // Lưu tài khoản vào cơ sở dữ liệu
            _dbContext.AccountCus.Add(newUser);
            _dbContext.SaveChanges();

            // Chuyển hướng đến trang đăng nhập hoặc trang chính
            return RedirectToAction("Login", "Account");
        }
        public IActionResult Logout()
        {
            // Xóa tất cả các session
            HttpContext.Session.Clear();

            // Chuyển hướng về trang Login
            return RedirectToAction("Login", "Account");
        }

    }
}

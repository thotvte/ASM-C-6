using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using web_ban_do_an.Models;
using web_ban_do_an.Repositories;
namespace web_ban_do_an.ViewComponents
{
    public class CategoryViewComponent :ViewComponent
    {
        private readonly ICategoryRepository _category;
        public CategoryViewComponent(ICategoryRepository category)
        {
            _category = category;
        }
        public IViewComponentResult Invoke()
        {
            var category = _category.GetAll().OrderBy(x => x.Name);
            return View(category);
        }
    }
}

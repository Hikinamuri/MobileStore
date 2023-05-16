using Microsoft.AspNetCore.Mvc;
using WebApplication2rrr.Models;
using System.Linq;
using System.Security.Claims;

namespace WebApplication2rrr.Controllers
{
    public class AreaController : Controller
    {
        private readonly MobileContext _dbContext;

        public AreaController(MobileContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult PersonalArea()
        {
            var userId = User.FindFirstValue("UserId");
            /*if (string.IsNullOrEmpty(userId))
            {
                // Обработка ситуации, когда id не найден
                return BadRequest();
            }*/

            if (int.TryParse(userId, out int id))
            {
                var user = _dbContext.Users.FirstOrDefault(u => u.UserId == id);
                return View("~/Views/Home/PersonalArea.cshtml", user);
            }

            /*if (user == null)
            {
                // Обработка ситуации, когда пользователь не найден
                return NotFound();
            }*/

            return View("~/Views/Home/PersonalArea.cshtml");
        }
    }
}

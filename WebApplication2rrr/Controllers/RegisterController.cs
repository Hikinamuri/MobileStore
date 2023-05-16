using Microsoft.AspNetCore.Mvc;
using WebApplication2rrr.Models;

namespace WebApplication2rrr.Controllers
{
    public class RegisterController : Controller
    {
        private readonly MobileContext _dbContext;

        public RegisterController(MobileContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View("~/Views/Authentication/Register.cshtml");
        }

        [HttpPost]
        public ActionResult RegisterUser(User user)
        {
            if (ModelState.IsValid)
            {
                // Хэширование пароля
                string hashedPassword = HashPassword(user.Password);

                // Создание нового пользователя
                var newUser = new User
                {
                    UserName = user.UserName,
                    Password = hashedPassword,
                    Name = user.Name,
                    Sex = user.Sex,
                    Role = user.Role,
                    NumberTelephone = user.NumberTelephone
                };

                // Сохранение пользователя в базе данных
                try
                {
                    _dbContext.Users.Add(newUser);
                    _dbContext.SaveChanges();
                    // Дополнительный код после успешного сохранения
                    return RedirectToAction("Login", "Login"); // Перенаправление на другую страницу после успешной регистрации
                }
                catch (Exception ex)
                {
                    // Обработка ошибки
                    Console.WriteLine(ex.Message);
                }
            }

            return View(user);
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}

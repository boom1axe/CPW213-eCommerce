using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce.Data;
using eCommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace eCommerce.Controllers
{
    public class CartController : Controller
    {
        private readonly GameContext _context;
        private readonly IHttpContextAccessor _httpAccessor;

        public CartController(GameContext context, IHttpContextAccessor httpAccessor)
        {
            _context = context;
            _httpAccessor = httpAccessor;
        }

        public async Task<IActionResult> AddAsync(int id)
        {
            VideoGame g = await VideoGameDb.GetGameById(id, _context);

            // convert game into string
            string data = JsonConvert.SerializeObject(g);

            CartHelper.Add(_httpAccessor, g);

            return RedirectToAction("Index", "Libary");

            public IActionResult Checkout()
            {
                List<VideoGame> games = CartHelper.GetGames(_httpAccessor);
                return View(games);
            }

            // set up cookie
            //CookieOptions options = new CookieOptions()
            //{
            //    Secure = true,
            //    MaxAge = TimeSpan.FromDays(365) // A whole year
            //};

            //_httpAccessor.HttpContext.Response.Cookies.Append("CartCookie", data, options);

            
        }
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP2.Models;

namespace TP2.Controllers
{
    public class GenreController : Controller
    {
        private readonly ApplicationdbContext _db;

        public GenreController(ApplicationdbContext db)
        {
            _db = db;
        }
        // GET: GenreController
        public ActionResult Index()
        {
            return View();
        }


    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieShop.Models.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _context;

        public MoviesController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var allMovies = _context.Movies.Include(n => n.Cinema).OrderBy(n => n.Name).ToList();
            return View(allMovies);
        }

        public IActionResult Create()
        {
            return View();
        }

    }
}

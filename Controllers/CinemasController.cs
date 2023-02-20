using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieShop.Models;
using MovieShop.Models.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace MovieShop.Controllers
{
    public class CinemasController : Controller
    {
        private readonly AppDbContext _context;

        public CinemasController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var allCinemas = await _context.Cinemas.ToListAsync();
            return View(allCinemas);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name, Logo, Desc")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);
            }
            await _context.Cinemas.AddAsync(cinema);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var CinemasInfo = _context.Cinemas.FirstOrDefault(x => x.Id == id);
            if (CinemasInfo is null)
            {
                return View("NotFound");
            }
            return View(CinemasInfo);
        }

        public IActionResult Edit(int id)
        {
            var CinemasInfo = _context.Cinemas.FirstOrDefault(x => x.Id == id);
            if (CinemasInfo is null)
            {
                return View("NotFound");
            }
            return View(CinemasInfo);
        }

        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> UpdateCinema(int id, Cinema newCinema)
        {
            _context.Update(newCinema);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int id)
        {
            var CinemasInfo = _context.Cinemas.FirstOrDefault(x => x.Id == id);
            if (CinemasInfo is null)
            {
                return View("NotFound");
            }
            return View(CinemasInfo);
        }


        public async Task<IActionResult> DeleteCinema(int id)
        {
            var CinemasInfo = await _context.Cinemas.FirstOrDefaultAsync(n => n.Id == id);

            if (CinemasInfo is null)
            {
                return View("NotFound");
            }
            _context.Cinemas.Remove(CinemasInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }





    }
}

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
    public class ActorsController : Controller
    {
        private readonly AppDbContext _context;

        public ActorsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var allActors = await _context.Actors.ToListAsync();
            return View(allActors);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName, ProfilePictureURL, Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var ActorInfo = _context.Actors.FirstOrDefault(x => x.Id == id);
            if(ActorInfo is null)
            {
                return View("NotFound");
            }
            return View(ActorInfo);
        }

        public IActionResult Edit(int id)
        {
            var ActorInfo = _context.Actors.FirstOrDefault(x => x.Id == id);
            if (ActorInfo is null)
            {
                return View("NotFound");
            }
            return View(ActorInfo);
        }

        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> UpdateActor(int id, Actor newActor)
        {
             _context.Actors.Update(newActor);
            await _context.SaveChangesAsync();
             return RedirectToAction(nameof(Index));
            
        }


        public IActionResult Delete(int id)
        {
            var ActorInfo = _context.Actors.FirstOrDefault(x => x.Id == id);
            if (ActorInfo is null)
            {
                return View("NotFound");
            }
            return View(ActorInfo);
        }

        
        public async Task<IActionResult> DeleteActor(int id)
        {
            var ActorInfo = await _context.Actors.FirstOrDefaultAsync(n => n.Id == id);

            if (ActorInfo is null)
            {
                return View("NotFound");
            }
            _context.Actors.Remove(ActorInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        



    }
}

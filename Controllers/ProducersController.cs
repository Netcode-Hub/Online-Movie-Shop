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
    public class ProducersController : Controller
    {
        private readonly AppDbContext _context;

        public ProducersController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var allProducers = await _context.Producers.ToListAsync();
            return View(allProducers);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName, ProfilePictureURL, Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _context.Producers.AddAsync(producer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var ProducerInfo = _context.Producers.FirstOrDefault(x => x.Id == id);
            if (ProducerInfo is null)
            {
                return View("NotFound");
            }
            return View(ProducerInfo);
        }

        public IActionResult Edit(int id)
        {
            var ProducerInfo = _context.Producers.FirstOrDefault(x => x.Id == id);
            if (ProducerInfo is null)
            {
                return View("NotFound");
            }
            return View(ProducerInfo);
        }

        [HttpPost, ActionName("Edit")]

        public async Task<IActionResult> UpdateAsync(int id, Producer newProducer)
        {
            _context.Update(newProducer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            //return View(newActor);
        }


        public IActionResult Delete(int id)
        {
            var ProducerInfo = _context.Producers.FirstOrDefault(x => x.Id == id);
            if (ProducerInfo is null)
            {
                return View("NotFound");
            }
            return View(ProducerInfo);
        }


        public async Task<IActionResult> DeleteActor(int id)
        {
            var ProducerInfo = await _context.Producers.FirstOrDefaultAsync(n => n.Id == id);

            if (ProducerInfo is null)
            {
                return View("NotFound");
            }
            _context.Producers.Remove(ProducerInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }





    }
}

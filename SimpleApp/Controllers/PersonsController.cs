using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleApp.Database.Interfaces;
using SimpleApp.Database.Models;

namespace SimpleApp.Controllers
{
    public class PersonsController : Controller
    {
        private readonly IPersonRepository personRepository;

        public PersonsController(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        // GET: Persons
        public async Task<IActionResult> Index()
        {
            return View(await personRepository.Query().ToListAsync());
        }

        // GET: Persons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var persons = await personRepository.Query()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (persons == null)
            {
                return NotFound();
            }

            return View(persons);
        }

        // GET: Persons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Persons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Imie,Nazwisko,Opis")] Persons persons)
        {
                personRepository.Insert(persons);
                return RedirectToAction(nameof(Index));
        }

        // GET: Persons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var persons = await personRepository.Query(x => x.Id == id).FirstOrDefaultAsync();
            if (persons == null)
            {
                return NotFound();
            }
            return View(persons);
        }

        // POST: Persons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Imie,Nazwisko,Opis,Id")] Persons persons)
        {
            if (id != persons.Id)
            {
                return NotFound();
            }
                try
                {
                    personRepository.Update(persons);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonsExists(persons.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
        }

        // GET: Persons/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var persons = personRepository.Query(x => x.Id == id).FirstOrDefault();
            if (persons == null)
            {
                return NotFound();
            }

            return View(persons);
        }

        // POST: Persons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var persons = await personRepository.Query(x => x.Id == id).FirstOrDefaultAsync();
            if (persons != null)
            {
                personRepository.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool PersonsExists(int id)
        {
          var result = personRepository.Query(x => x.Id == id).FirstOrDefaultAsync();
          return result != null;
        }
    }
}

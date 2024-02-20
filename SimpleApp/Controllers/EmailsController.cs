using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SimpleApp.Database.Interfaces;
using SimpleApp.Database.Models;

namespace SimpleApp.Controllers
{
    public class EmailsController : Controller
    {
        private readonly IEmailRepository emailRepository;
        private readonly IPersonRepository personRepository;

        public EmailsController(IEmailRepository emailRepository, IPersonRepository personRepository)
        {
            this.emailRepository = emailRepository;
            this.personRepository = personRepository;
        }

        // GET: Emails
        public async Task<IActionResult> Index()
        {
            var simpleAppContext = emailRepository.Query().Include(e => e.Person);
            return View(await simpleAppContext.ToListAsync());
        }

        // GET: Emails/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            var emails = await emailRepository.Query(m => m.Id == id)
                .Include(e => e.Person)
                .FirstOrDefaultAsync();
            if (emails == null)
            {
                return NotFound();
            }

            return View(emails);
        }

        // GET: Emails/Create
        public IActionResult Create()
        {
            ViewData["PersonId"] = new SelectList(personRepository.Query(), "Id", "Imie");
            return View();
        }

        // POST: Emails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Email,PersonId,Id")] Emails emails)
        {
            if (ModelState.IsValid)
            {
                emailRepository.Insert(emails);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Emails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var emails = await emailRepository.Query(x => x.Id == id).FirstOrDefaultAsync();
            if (emails == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(personRepository.Query(), "Id", "Imie", emails.PersonId);
            return View(emails);
        }

        // POST: Emails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Email,PersonId,Id")] Emails emails)
        {
            if (id != emails.Id)
            {
                return NotFound();
            }
                try
                {
                    emailRepository.Update(emails);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmailsExists(emails.Id))
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

        // GET: Emails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var emails = await emailRepository.Query(x => x.Id == id)
                .Include(e => e.Person)
                .FirstOrDefaultAsync();
            if (emails == null)
            {
                return NotFound();
            }

            return View(emails);
        }

        // POST: Emails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var emails = await emailRepository.Query(x => x.Id == id).FirstOrDefaultAsync();
            if (emails != null)
            {
                emailRepository.Delete(emails.Id);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool EmailsExists(int id)
        {
            var result = emailRepository.Query(x => x.Id == id).FirstOrDefaultAsync();
            return result != null;
        }
    }
}

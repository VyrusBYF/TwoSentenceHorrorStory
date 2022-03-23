using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TwoSentenceHorrorStory.Data;
using TwoSentenceHorrorStory.Models;

namespace TwoSentenceHorrorStory.Controllers
{
    public class SentencesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SentencesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sentences
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sentence.ToListAsync());
        }

        // GET: Sentences/ShowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }


        // POST: Sentences/ShowSearchResults
        public async Task<IActionResult> ShowSearchResults(string SearchPhrase)
        {
            return View("Index", await _context.Sentence.Where(s => s.IntroSentence.Contains(SearchPhrase)).ToListAsync());
        }
        // POST: Sentences/ShowStory
        public async Task<IActionResult> ShowStory()
        {
            Random randStoryId = new Random();
            int rec = randStoryId.Next(1,_context.Sentence.Count());
            return View(await _context.Sentence.Where(s => s.Id == rec).ToListAsync());
        }

        // GET: Sentences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sentence = await _context.Sentence
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sentence == null)
            {
                return NotFound();
            }

            return View(sentence);
        }

        [Authorize]
        // GET: Sentences/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sentences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IntroSentence,PostSentence")] Sentence sentence)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sentence);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sentence);
        }

        [Authorize]
        // GET: Sentences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sentence = await _context.Sentence.FindAsync(id);
            if (sentence == null)
            {
                return NotFound();
            }
            return View(sentence);
        }

        // POST: Sentences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IntroSentence,PostSentence")] Sentence sentence)
        {
            if (id != sentence.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sentence);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SentenceExists(sentence.Id))
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
            return View(sentence);
        }

        [Authorize]
        // GET: Sentences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sentence = await _context.Sentence
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sentence == null)
            {
                return NotFound();
            }

            return View(sentence);
        }
        [Authorize]
        // POST: Sentences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sentence = await _context.Sentence.FindAsync(id);
            _context.Sentence.Remove(sentence);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SentenceExists(int id)
        {
            return _context.Sentence.Any(e => e.Id == id);
        }
    }
}

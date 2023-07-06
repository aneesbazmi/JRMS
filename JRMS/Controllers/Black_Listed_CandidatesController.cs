using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EntityFramework;
using JRMS.DAL;

namespace JRMS.Controllers
{
    public class Black_Listed_CandidatesController : Controller
    {
        private readonly JMSDbContext _context;


        public Black_Listed_CandidatesController(JMSDbContext context)
        {
            _context = context;
        }

        // GET: Black_Listed_Candidates
        public async Task<IActionResult> Index()
        {
            var jMSDbContext = _context.black_listed_candidates.Include(b => b.Applicant);
            return View(await jMSDbContext.ToListAsync());
        }

        // GET: Black_Listed_Candidates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.black_listed_candidates == null)
            {
                return NotFound();
            }

            var black_Listed_Candidates = await _context.black_listed_candidates
                .Include(b => b.Applicant)
                .FirstOrDefaultAsync(m => m.Black_Listed_CandidatesId == id);
            if (black_Listed_Candidates == null)
            {
                return NotFound();
            }

            return View(black_Listed_Candidates);
        }

        // GET: Black_Listed_Candidates/Create
        public IActionResult Create()
        {
            ViewData["ApplicantId"] = new SelectList(_context.applicants, "ApplicantId", "Applicant_Gender");
            return View();
        }

        // POST: Black_Listed_Candidates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Black_Listed_CandidatesId,ApplicantId")] Black_Listed_Candidates black_Listed_Candidates)
        {
            if (ModelState.IsValid)
            {
                _context.Add(black_Listed_Candidates);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicantId"] = new SelectList(_context.applicants, "ApplicantId", "Applicant_Gender", black_Listed_Candidates.ApplicantId);
            return View(black_Listed_Candidates);
        }

        // GET: Black_Listed_Candidates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.black_listed_candidates == null)
            {
                return NotFound();
            }

            var black_Listed_Candidates = await _context.black_listed_candidates.FindAsync(id);
            if (black_Listed_Candidates == null)
            {
                return NotFound();
            }
            ViewData["ApplicantId"] = new SelectList(_context.applicants, "ApplicantId", "Applicant_Gender", black_Listed_Candidates.ApplicantId);
            return View(black_Listed_Candidates);
        }

        // POST: Black_Listed_Candidates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Black_Listed_CandidatesId,ApplicantId")] Black_Listed_Candidates black_Listed_Candidates)
        {
            if (id != black_Listed_Candidates.Black_Listed_CandidatesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(black_Listed_Candidates);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Black_Listed_CandidatesExists(black_Listed_Candidates.Black_Listed_CandidatesId))
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
            ViewData["ApplicantId"] = new SelectList(_context.applicants, "ApplicantId", "Applicant_Gender", black_Listed_Candidates.ApplicantId);
            return View(black_Listed_Candidates);
        }

        // GET: Black_Listed_Candidates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.black_listed_candidates == null)
            {
                return NotFound();
            }

            var black_Listed_Candidates = await _context.black_listed_candidates
                .Include(b => b.Applicant)
                .FirstOrDefaultAsync(m => m.Black_Listed_CandidatesId == id);
            if (black_Listed_Candidates == null)
            {
                return NotFound();
            }

            return View(black_Listed_Candidates);
        }

        // POST: Black_Listed_Candidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.black_listed_candidates == null)
            {
                return Problem("Entity set 'JMSDbContext.black_listed_candidates'  is null.");
            }
            var black_Listed_Candidates = await _context.black_listed_candidates.FindAsync(id);
            if (black_Listed_Candidates != null)
            {
                _context.black_listed_candidates.Remove(black_Listed_Candidates);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Black_Listed_CandidatesExists(int id)
        {
          return (_context.black_listed_candidates?.Any(e => e.Black_Listed_CandidatesId == id)).GetValueOrDefault();
        }
    }
}

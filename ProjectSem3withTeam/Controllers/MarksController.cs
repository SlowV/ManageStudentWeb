using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectSem3withTeam.Models;

namespace ProjectSem3withTeam.Controllers
{
    public class MarksController : Controller
    {
        private readonly ProjectSem3withTeamContext _context;

        public MarksController(ProjectSem3withTeamContext context)
        {
            _context = context;
        }

        // GET: Marks
        public async Task<IActionResult> Index()
        {
            var projectSem3withTeamContext = _context.Mark.Include(m => m.Student).Include(m => m.Subject).Include(m => m.Teacher);
            return View(await projectSem3withTeamContext.ToListAsync());
        }

        // GET: Marks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mark = await _context.Mark
                .Include(m => m.Student)
                .Include(m => m.Subject)
                .Include(m => m.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mark == null)
            {
                return NotFound();
            }

            return View(mark);
        }

        // GET: Marks/Create
        public IActionResult Create()
        {
            ViewData["StudentRollNumber"] = new SelectList(_context.Student, "RollNumber", "RollNumber");
            ViewData["SubjectId"] = new SelectList(_context.Subject, "Id", "Id");
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "Id", "Id");
            return View();
        }

        // POST: Marks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SubjectId,StudentRollNumber,SubjectMark,TeacherId,CreatedAt,UpdatedAt")] Mark mark)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mark);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentRollNumber"] = new SelectList(_context.Student, "RollNumber", "RollNumber", mark.StudentRollNumber);
            ViewData["SubjectId"] = new SelectList(_context.Subject, "Id", "Id", mark.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "Id", "Id", mark.TeacherId);
            return View(mark);
        }

        // GET: Marks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mark = await _context.Mark.FindAsync(id);
            if (mark == null)
            {
                return NotFound();
            }
            ViewData["StudentRollNumber"] = new SelectList(_context.Student, "RollNumber", "RollNumber", mark.StudentRollNumber);
            ViewData["SubjectId"] = new SelectList(_context.Subject, "Id", "Id", mark.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "Id", "Id", mark.TeacherId);
            return View(mark);
        }

        // POST: Marks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SubjectId,StudentRollNumber,SubjectMark,TeacherId,CreatedAt,UpdatedAt")] Mark mark)
        {
            if (id != mark.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mark);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarkExists(mark.Id))
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
            ViewData["StudentRollNumber"] = new SelectList(_context.Student, "RollNumber", "RollNumber", mark.StudentRollNumber);
            ViewData["SubjectId"] = new SelectList(_context.Subject, "Id", "Id", mark.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "Id", "Id", mark.TeacherId);
            return View(mark);
        }

        // GET: Marks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mark = await _context.Mark
                .Include(m => m.Student)
                .Include(m => m.Subject)
                .Include(m => m.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mark == null)
            {
                return NotFound();
            }

            return View(mark);
        }

        // POST: Marks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mark = await _context.Mark.FindAsync(id);
            _context.Mark.Remove(mark);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarkExists(int id)
        {
            return _context.Mark.Any(e => e.Id == id);
        }
    }
}

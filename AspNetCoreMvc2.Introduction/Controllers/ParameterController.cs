using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspNetCoreMvc2.Introduction.DataSources;
using AspNetCoreMvc2.Introduction.DataSources.Entities;

namespace AspNetCoreMvc2.Introduction.Controllers
{
    public class ParameterController : Controller
    {
        private readonly UylmzDbContext _context;

        public ParameterController(UylmzDbContext context)
        {
            _context = context;
        }

        // GET: Parameter
        public async Task<IActionResult> Index()
        {
            return View(await _context.Parameter.ToListAsync());
        }

        // GET: Parameter/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parameter = await _context.Parameter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parameter == null)
            {
                return NotFound();
            }

            return View(parameter);
        }

        // GET: Parameter/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Parameter/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Key,Value,Description")] Parameter parameter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parameter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parameter);
        }

        // GET: Parameter/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parameter = await _context.Parameter.FindAsync(id);
            if (parameter == null)
            {
                return NotFound();
            }
            return View(parameter);
        }

        // POST: Parameter/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Key,Value,Description")] Parameter parameter)
        {
            if (id != parameter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parameter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParameterExists(parameter.Id))
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
            return View(parameter);
        }

        // GET: Parameter/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parameter = await _context.Parameter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parameter == null)
            {
                return NotFound();
            }

            return View(parameter);
        }

        // POST: Parameter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parameter = await _context.Parameter.FindAsync(id);
            _context.Parameter.Remove(parameter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParameterExists(int id)
        {
            return _context.Parameter.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Company.Models;

namespace Company.Controllers
{
    public class empsController : Controller
    {
        private readonly employeeContext _context;

        public empsController(employeeContext context)
        {
            _context = context;
        }

        // GET: emps
        public async Task<IActionResult> Index()
        {
            return View(await _context.emp.ToListAsync());
        }

        // GET: emps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emp = await _context.emp
                .FirstOrDefaultAsync(m => m.empid == id);
            if (emp == null)
            {
                return NotFound();
            }

            return View(emp);
        }

        // GET: emps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: emps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("empid,name,city")] emp emp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emp);
        }

        // GET: emps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emp = await _context.emp.FindAsync(id);
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }

        // POST: emps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("empid,name,city")] emp emp)
        {
            if (id != emp.empid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!empExists(emp.empid))
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
            return View(emp);
        }

        // GET: emps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emp = await _context.emp
                .FirstOrDefaultAsync(m => m.empid == id);
            if (emp == null)
            {
                return NotFound();
            }

            return View(emp);
        }

        // POST: emps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emp = await _context.emp.FindAsync(id);
            _context.emp.Remove(emp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool empExists(int id)
        {
            return _context.emp.Any(e => e.empid == id);
        }
    }
}

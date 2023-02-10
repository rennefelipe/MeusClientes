using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MeusClientes.Data;
using MeusClientes.EF;

namespace MeusClientes.Controllers
{
    public class HistoricoSuportesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HistoricoSuportesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HistoricoSuportes
        public async Task<IActionResult> Index()
        {
            return View(await _context.HistoricoSuporte.ToListAsync());
        }

        // GET: HistoricoSuportes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historicoSuporte = await _context.HistoricoSuporte
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historicoSuporte == null)
            {
                return NotFound();
            }

            return View(historicoSuporte);
        }

        // GET: HistoricoSuportes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HistoricoSuportes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Equipamento,Data,Anotacao")] HistoricoSuporte historicoSuporte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historicoSuporte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(historicoSuporte);
        }

        // GET: HistoricoSuportes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historicoSuporte = await _context.HistoricoSuporte.FindAsync(id);
            if (historicoSuporte == null)
            {
                return NotFound();
            }
            return View(historicoSuporte);
        }

        // POST: HistoricoSuportes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Equipamento,Data,Anotacao")] HistoricoSuporte historicoSuporte)
        {
            if (id != historicoSuporte.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historicoSuporte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistoricoSuporteExists(historicoSuporte.Id))
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
            return View(historicoSuporte);
        }

        // GET: HistoricoSuportes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historicoSuporte = await _context.HistoricoSuporte
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historicoSuporte == null)
            {
                return NotFound();
            }

            return View(historicoSuporte);
        }

        // POST: HistoricoSuportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var historicoSuporte = await _context.HistoricoSuporte.FindAsync(id);
            _context.HistoricoSuporte.Remove(historicoSuporte);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistoricoSuporteExists(int id)
        {
            return _context.HistoricoSuporte.Any(e => e.Id == id);
        }
    }
}

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
    public class DadoContatoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DadoContatoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DadoContatoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.DadoContato.ToListAsync());
        }

        // GET: DadoContatoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadoContato = await _context.DadoContato
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dadoContato == null)
            {
                return NotFound();
            }

            return View(dadoContato);
        }

        // GET: DadoContatoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DadoContatoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Celular,Telefone,Email")] DadoContato dadoContato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dadoContato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dadoContato);
        }

        // GET: DadoContatoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadoContato = await _context.DadoContato.FindAsync(id);
            if (dadoContato == null)
            {
                return NotFound();
            }
            return View(dadoContato);
        }

        // POST: DadoContatoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Celular,Telefone,Email")] DadoContato dadoContato)
        {
            if (id != dadoContato.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dadoContato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DadoContatoExists(dadoContato.Id))
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
            return View(dadoContato);
        }

        // GET: DadoContatoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadoContato = await _context.DadoContato
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dadoContato == null)
            {
                return NotFound();
            }

            return View(dadoContato);
        }

        // POST: DadoContatoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dadoContato = await _context.DadoContato.FindAsync(id);
            _context.DadoContato.Remove(dadoContato);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DadoContatoExists(int id)
        {
            return _context.DadoContato.Any(e => e.Id == id);
        }
    }
}

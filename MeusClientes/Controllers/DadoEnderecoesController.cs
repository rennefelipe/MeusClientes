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
    public class DadoEnderecoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DadoEnderecoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DadoEnderecoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.DadoEndereco.ToListAsync());
        }

        // GET: DadoEnderecoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadoEndereco = await _context.DadoEndereco
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dadoEndereco == null)
            {
                return NotFound();
            }

            return View(dadoEndereco);
        }

        // GET: DadoEnderecoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DadoEnderecoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Endereco,Bairro,Cidade,CEP")] DadoEndereco dadoEndereco)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dadoEndereco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dadoEndereco);
        }

        // GET: DadoEnderecoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadoEndereco = await _context.DadoEndereco.FindAsync(id);
            if (dadoEndereco == null)
            {
                return NotFound();
            }
            return View(dadoEndereco);
        }

        // POST: DadoEnderecoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Endereco,Bairro,Cidade,CEP")] DadoEndereco dadoEndereco)
        {
            if (id != dadoEndereco.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dadoEndereco);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DadoEnderecoExists(dadoEndereco.Id))
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
            return View(dadoEndereco);
        }

        // GET: DadoEnderecoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadoEndereco = await _context.DadoEndereco
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dadoEndereco == null)
            {
                return NotFound();
            }

            return View(dadoEndereco);
        }

        // POST: DadoEnderecoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dadoEndereco = await _context.DadoEndereco.FindAsync(id);
            _context.DadoEndereco.Remove(dadoEndereco);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DadoEnderecoExists(int id)
        {
            return _context.DadoEndereco.Any(e => e.Id == id);
        }
    }
}

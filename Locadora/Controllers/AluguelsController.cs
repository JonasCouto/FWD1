using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Locadora.Data;
using Locadora.Models;

namespace Locadora.Controllers
{
    public class AluguelsController : Controller
    {
        private readonly LocadoraContext _context;

        public AluguelsController(LocadoraContext context)
        {
            _context = context;
        }

        // GET: Aluguels
        public async Task<IActionResult> Index()
        {
            var locadoraContext = _context.Aluguel.Include(a => a.Cliente).Include(a => a.Filme);
            return View(await locadoraContext.ToListAsync());
        }

        // GET: Aluguels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluguel = await _context.Aluguel
                .Include(a => a.Cliente)
                .Include(a => a.Filme)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aluguel == null)
            {
                return NotFound();
            }

            return View(aluguel);
        }

        // GET: Aluguels/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Nome");
            ViewData["FilmeId"] = new SelectList(_context.Filme, "Id", "Nome");
            return View();
        }

        // POST: Aluguels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataLocacao,DataPrevisao,DataEntrega,ClienteId,FilmeId")] Aluguel aluguel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aluguel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Cpf", aluguel.ClienteId);
            ViewData["FilmeId"] = new SelectList(_context.Filme, "Id", "Descricao", aluguel.FilmeId);
            return View(aluguel);
        }

        // GET: Aluguels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluguel = await _context.Aluguel.FindAsync(id);
            if (aluguel == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Cpf", aluguel.ClienteId);
            ViewData["FilmeId"] = new SelectList(_context.Filme, "Id", "Descricao", aluguel.FilmeId);
            return View(aluguel);
        }

        // POST: Aluguels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataLocacao,DataPrevisao,DataEntrega,ClienteId,FilmeId")] Aluguel aluguel)
        {
            if (id != aluguel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aluguel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AluguelExists(aluguel.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Cpf", aluguel.ClienteId);
            ViewData["FilmeId"] = new SelectList(_context.Filme, "Id", "Descricao", aluguel.FilmeId);
            return View(aluguel);
        }

        // GET: Aluguels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluguel = await _context.Aluguel
                .Include(a => a.Cliente)
                .Include(a => a.Filme)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aluguel == null)
            {
                return NotFound();
            }

            return View(aluguel);
        }

        // POST: Aluguels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aluguel = await _context.Aluguel.FindAsync(id);
            _context.Aluguel.Remove(aluguel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AluguelExists(int id)
        {
            return _context.Aluguel.Any(e => e.Id == id);
        }
    }
}

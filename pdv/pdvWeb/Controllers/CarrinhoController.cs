using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using pdvInfraestrutura.Access;
using pdvInfraestrutura.Database;
using pdvInfraestrutura.Model;


namespace pdvWeb.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly pdvContext _context;

        private readonly CarrinhoAccess carrinhoAccess;
        private readonly CarrinhoItemAccess carrinhoItemAccess;

        public CarrinhoController(pdvContext context, CarrinhoAccess cAccess, CarrinhoItemAccess ciAccess)
        {
            _context = context;
            this.carrinhoAccess = cAccess;
            this.carrinhoItemAccess = ciAccess;
        }

        // GET: Carrinho
        public async Task<IActionResult> Index()
        {
            return View(await _context.Carrinhos.ToListAsync());
        }
                
        // GET: Carrinho/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrinho = await _context.Carrinhos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carrinho == null)
            {
                return NotFound();
            }

            return View(carrinho);
        }

        // GET: Carrinho/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carrinho/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataAbertura,LoginUsuarioAbertura,DataFechamento,LoginUsuarioFechamento")] Carrinho carrinho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carrinho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carrinho);
        }

        // GET: Carrinho/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrinho = await _context.Carrinhos.FindAsync(id);

            if (carrinho == null)
            {
                return NotFound();
            }

            return View(carrinho);
        }


        // GET: Carrinho/Edit/5
        public ActionResult Carrinho(int id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var Carrinho = carrinhoAccess.Ler(id);
            ViewBag.Itens = carrinhoItemAccess.Listar(id);

            return View(Carrinho);
        }


        // POST: Carrinho/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataAbertura,LoginUsuarioAbertura,DataFechamento,LoginUsuarioFechamento")] Carrinho carrinho)
        {
            if (id != carrinho.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carrinho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarrinhoExists(carrinho.Id))
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
            return View(carrinho);
        }
                
        // GET: Carrinho/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carrinho = await _context.Carrinhos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carrinho == null)
            {
                return NotFound();
            }

            return View(carrinho);
        }

        // POST: Carrinho/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carrinho = await _context.Carrinhos.FindAsync(id);
            _context.Carrinhos.Remove(carrinho);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarrinhoExists(int id)
        {
            return _context.Carrinhos.Any(e => e.Id == id);
        }
    }
}

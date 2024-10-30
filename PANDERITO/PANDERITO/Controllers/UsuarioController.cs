using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PANDERITO.Data;
using PANDERITO.Models;
using System.Threading.Tasks;

namespace PANDERITO.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsuarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Usuario
        public async Task<ActionResult> Index()
        {
            var usuarios = await _context.Usuarios.ToListAsync(); // Cambiado de "Clientes" a "Usuarios"
            return View(usuarios);
        }

        // GET: Usuario/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Usuario usuario) // Cambiado de "Cliente" a "Usuario"
        {
            if (ModelState.IsValid)
            {
                _context.Usuarios.Add(usuario); // Cambiado de "Clientes" a "Usuarios"
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, Usuario usuario) // Cambiado de "Cliente" a "Usuario"
        {
            if (id != usuario.Cedula) // Asegúrate de que Cedula sea una propiedad en Usuario
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario); // Cambiado de "Cliente" a "Usuario"
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Cedula)) // Cambiado "ClienteExists" para reflejar la nueva lógica
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
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string id, IFormCollection collection)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(string id) // Cambiado de "ClienteExists" a "UsuarioExists"
        {
            return _context.Usuarios.Any(e => e.Cedula == id);
        }
    }
}

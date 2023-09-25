using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto_Final.Data;
using Proyecto_Final.Models;
using System.Diagnostics;

namespace Proyecto_Final.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly DBContext _context;

        public HomeController(DBContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {            
            return View(await _context.Usuarios.Include(u => u.EstadoCivil).Include(u => u.Localidad).ToListAsync());
        }
        public async Task<IActionResult> ListaUsuario()
        {
            return View(await _context.Usuarios.Include(u => u.EstadoCivil).Include(u => u.Localidad).ToListAsync());
        }
        public async Task<IActionResult> Create()
        {
            ViewData["EstadoCivilId"] = new SelectList(_context.EstadoCivils, "Id", "Nombre");
            ViewData["LocalidadId"] = new SelectList(_context.Localidad, "Id", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstadoCivilId"] = new SelectList(_context.EstadoCivils, "Id", "Nombre", usuario.EstadoCivilId);
            ViewData["LocalidadId"] = new SelectList(_context.Localidad, "Id", "Nombre", usuario.LocalidadId);
            return View(usuario);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewData["EstadoCivilId"] = new SelectList(_context.EstadoCivils, "Id", "Nombre", usuario.EstadoCivilId);
            ViewData["LocalidadId"] = new SelectList(_context.Localidad, "Id", "Nombre", usuario.LocalidadId);
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var tmp = await _context.Usuarios.FindAsync(usuario.Id);
                if (tmp == null)
                {
                    return NotFound();
                }

                tmp.Cedula = usuario.Cedula;
                tmp.Nombres = usuario.Nombres;
                tmp.Apellidos = usuario.Apellidos;
                tmp.Fecha = usuario.Fecha;
                tmp.Telefono = usuario.Telefono;
                tmp.EstadoCivilId = usuario.EstadoCivilId;
                tmp.LocalidadId = usuario.LocalidadId;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstadoCivilId"] = new SelectList(_context.EstadoCivils, "Id", "Nombre", usuario.EstadoCivilId);
            ViewData["LocalidadId"] = new SelectList(_context.Localidad, "Id", "Nombre", usuario.LocalidadId);
            return View(usuario);
        }

        public async Task<IActionResult> Details(int id)
        {
            var usuario = await _context.Usuarios
                .Include(u => u.EstadoCivil)
                .Include(u => u.Localidad)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _context.Usuarios
                       .Include(u => u.EstadoCivil)
                       .Include(u => u.Localidad)
                       .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            _context.Remove(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
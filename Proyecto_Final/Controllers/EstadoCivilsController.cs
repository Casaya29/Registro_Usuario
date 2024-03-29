﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto_Final.Data;
using Proyecto_Final.Models;

namespace Proyecto_Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoCivilsController : ControllerBase
    {
        private readonly DBContext _context;

        public EstadoCivilsController(DBContext context)
        {
            _context = context;
        }

        // GET: api/EstadoCivils
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadoCivil>>> GetEstadoCivils()
        {
          if (_context.EstadoCivils == null)
          {
              return NotFound();
          }
            return await _context.EstadoCivils.ToListAsync();
        }

        // GET: api/EstadoCivils/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoCivil>> GetEstadoCivil(int id)
        {
          if (_context.EstadoCivils == null)
          {
              return NotFound();
          }
            var estadoCivil = await _context.EstadoCivils.FindAsync(id);

            if (estadoCivil == null)
            {
                return NotFound();
            }

            return estadoCivil;
        }

        // PUT: api/EstadoCivils/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadoCivil(int id, EstadoCivil estadoCivil)
        {
            if (id != estadoCivil.Id)
            {
                return BadRequest();
            }

            _context.Entry(estadoCivil).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoCivilExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EstadoCivils
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EstadoCivil>> PostEstadoCivil(EstadoCivil estadoCivil)
        {
          if (_context.EstadoCivils == null)
          {
              return Problem("Entity set 'DBContext.EstadoCivils'  is null.");
          }
            _context.EstadoCivils.Add(estadoCivil);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstadoCivil", new { id = estadoCivil.Id }, estadoCivil);
        }

        // DELETE: api/EstadoCivils/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstadoCivil(int id)
        {
            if (_context.EstadoCivils == null)
            {
                return NotFound();
            }
            var estadoCivil = await _context.EstadoCivils.FindAsync(id);
            if (estadoCivil == null)
            {
                return NotFound();
            }

            _context.EstadoCivils.Remove(estadoCivil);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstadoCivilExists(int id)
        {
            return (_context.EstadoCivils?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

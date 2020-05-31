﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookLab2.Models;

namespace BookLab2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly BookLab2Context _context;

        public CountriesController(BookLab2Context context)
        {
            _context = context;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            return await _context.Countries.ToListAsync();
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            var country = await _context.Countries.FindAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            return country;
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, Country country)
        {
            var countries = _context.Countries.Where(sg => sg.Name == country.Name).ToList().Count();
            if (countries != 0) return BadRequest("Країна з такою назвою вже існує");
            if (id != country.Id)
            {
                return BadRequest();
            }

            _context.Entry(country).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(id))
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

        // POST: api/Countries
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(Country country)
        {
            var countries = _context.Countries.Where(sg => sg.Name == country.Name).ToList().Count();
            if (countries != 0) return BadRequest("Країна з такою назвою вже існує");
            _context.Countries.Add(country);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Country>> DeleteCountry(int id)
        {
            var authors = _context.Authors.Where(b => b.CountryId == id).Include(b => b.Country).ToList();
            foreach (var b in authors)
            {
                var authorsBooks = _context.Books.Where(a => a.AuthorId == b.AuthorId).Include(a => a.Author).ToList();
                foreach (var a in authorsBooks)
                {
                    var genresBooks = _context.BookGenres.Where(a => a.BookId == a.BookId).Include(a => a.Genre).ToList();

                    _context.BookGenres.RemoveRange(genresBooks);
                }
                _context.Books.RemoveRange(authorsBooks);
            }
            _context.Authors.RemoveRange(authors);
            var country = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();

            return country;
        }

        private bool CountryExists(int id)
        {
            return _context.Countries.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Exam_Angular.Models;
using Exam_Angular.ViewModels;
using Project1.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Exam_Angular.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public CategoriesController(ApplicationContext context)
        {
            _context = context;
        }
        private int Userid => Convert.ToInt32(User.Claims.Single(x=>x.Type==ClaimTypes.NameIdentifier).Value);
        // GET: api/Categories
        [HttpGet]
        [Authorize(Roles ="User")]
        public async Task<ActionResult<IEnumerable<CategoryViewModel>>> GetContactCategory()
        {
            Console.WriteLine(Userid);
            return (from n in await _context.ContactCategory.Include(x=>x.Adder).ToListAsync() where n.Adder.Id == Userid select new CategoryViewModel { Id = n.Id, Name = n.Name, ContactsCount = _context.Contact.Include(x=>x.Category).Where(x=>x.Category.Name == n.Name).ToList().Count }).ToList();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryViewModel>> GetContactCategory(int id)
        {
            var contactCategory =  _context.ContactCategory.Include(x=>x.Adder).Where(x=>x.Id==id).First();

            if (contactCategory == null || contactCategory.Adder.Id != Userid)
            {
                return NotFound();
            }

            return new CategoryViewModel { Name = contactCategory.Name, Id = contactCategory.Id };
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactCategory(int id, CategoryViewModel contactCategory)
        {
            var Category = _context.ContactCategory.Include(x=>x.Adder).FirstOrDefault(x => x.Id == id);
            if (Category.Adder.Id != Userid) return BadRequest();
            Category.Name = contactCategory.Name;
         // _context.Entry(contactCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactCategoryExists(id))
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

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContactCategory>> PostContactCategory(CategoryViewModel contactCategory)
        {
            var user = _context.accounts.FirstOrDefault(x => x.Id == Userid);
            _context.ContactCategory.Add(new ContactCategory { Name = contactCategory.Name, Adder = user });
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContactCategory", new { id = contactCategory.Id }, contactCategory);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> DeleteContactCategory(int id)
        {
            var contactCategory = await _context.ContactCategory.FindAsync(id);
           // if (contactCategory?.Adder?.Id != Userid) return BadRequest();
            if (contactCategory == null || _context.Contact.Include(x => x.Category).Where(x => x.Category.Name == contactCategory.Name).ToList().Count != 0)
            {
                return NoContent();
            }

            _context.ContactCategory.Remove(contactCategory);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool ContactCategoryExists(int id)
        {
            return _context.ContactCategory.Any(e => e.Id == id);
        }
    }
}

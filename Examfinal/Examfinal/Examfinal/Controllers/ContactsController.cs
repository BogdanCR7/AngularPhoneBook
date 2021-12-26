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
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Exam_Angular.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class ContactsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ContactsController(ApplicationContext context)
        {
            _context = context;
        }
        private int Userid => Convert.ToInt32(User.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier).Value);
        // GET: api/Contacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactViewModel>>> GetContact()
        {
            return (from n in await _context.Contact.Include(x=>x.Category).Include(x=>x.Phones).Include(x=>x.Adder).ToListAsync()
                    where n.Adder.Id == Userid select new ContactViewModel { Category = n.Category.Name, Adress = n.Adress, Name = n.Name, Description = n.Description, Email = n.Email, Id = n.Id, PhoneNumbers = n.Phones.Select(x=>x.PhoneNumber).ToArray() }).ToList();
        }

        // GET: api/Contacts/5
        [HttpGet("{id}")]
        public ActionResult<ContactViewModel> GetContact(int id)
        {
            var contact = _context.Contact.Include(x => x.Phones).FirstOrDefault(x => x.Id == id);

            if (contact == null || contact.Adder.Id != Userid)
            {
                return NotFound();
            }

            var _contact = new ContactViewModel
            {
                Id = contact.Id,
                Adress = contact.Adress,
                Category = contact.Category.Name,
                Description = contact.Description,
                Email = contact.Email,
                Name = contact.Name,
                PhoneNumbers = contact.Phones.Select(x => x.PhoneNumber).ToArray()
            };

            return _contact;
        }

        // PUT: api/Contacts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContact(int id, ContactViewModel contact)
        {
            var c = _context.Contact.FirstOrDefault(x => x.Id == id);

            c.Name = contact.Name;
            c.Category = _context.ContactCategory.FirstOrDefault(x => x.Name == contact.Category);
            c.Adress = contact.Adress;
            c.Description = contact.Description;
            c.Email = contact.Email;
            foreach (var r in contact.PhoneNumbers)
                _context.Phone.Add(new Phone { PhoneNumber = r });
            _context.SaveChanges();
            foreach (var r in contact.PhoneNumbers)
            c.Phones.Add(_context.Phone.LastOrDefault(x => x.PhoneNumber == r));

            _context.Entry(contact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(id))
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

        // POST: api/Contacts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
       
        public async Task<ActionResult<ContactViewModel>> PostContact(ContactViewModel contact)
        {
            try
            {
                if (contact.Name?.Length < 1 || Userid == 0) return BadRequest();
                var cont = new Contact { Name = contact.Name, Email = contact.Email, Description = contact.Description, Adress = contact.Adress, Category = _context.ContactCategory.FirstOrDefault(x => x.Name == contact.Category), Adder = _context.accounts.FirstOrDefault(x => x.Id == Userid) };
                if (contact.PhoneNumbers?.Length > 0)
                {
                    foreach (var r in contact.PhoneNumbers)
                        _context.Add(new Phone { PhoneNumber = r });
                    _context.SaveChanges();
                    foreach (var r in contact.PhoneNumbers)
                        cont.Phones.Add(_context.Phone.FirstOrDefault(x => x.PhoneNumber == r));
                }
                _context.Contact.Add(cont);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            contact.Id = _context.Contact.FirstOrDefault(x => x.Name == contact.Name).Id;

            //  return CreatedAtAction("GetContact", new { id = contact.Id }, cont);
            return null;
        }

        // DELETE: api/Contacts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var contact = _context.Contact.Include(x=>x.Category).Include(x=>x.Phones).FirstOrDefault(x=>x.Id == id);
            

            _context.Phone.RemoveRange(contact.Phones);
            _context.Contact.Remove(contact);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool ContactExists(int id)
        {
            return _context.Contact.Any(e => e.Id == id);
        }

    }
}

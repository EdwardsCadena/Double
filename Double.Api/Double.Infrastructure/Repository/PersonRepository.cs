using Double.Core.DTOs;
using Double.Core.Entities;
using Double.Core.Interfaces;
using Double.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Double.Infrastructure.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DoublepContext _context;

        public PersonRepository(DoublepContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Person>> GetPersons()
        {
            return await _context.Persons.FromSqlRaw($"getPerons").ToArrayAsync();
           
        }
        public async Task<Person> GetPerson(int id)
        {
            var person = await _context.Persons.FirstOrDefaultAsync(x => x.Identifier == id);
            return person;
        }
        public async Task InsertPerson(Person person)
        {
            DateTime currentDate = DateTime.Now;
            Person registro = new Person
            {
                Name = person.Name,
                LastName = person.LastName,
                FkIdTypeIdenti = person.FkIdTypeIdenti,
                NumberIdentification = person.NumberIdentification,
                Email = person.Email,
                DateCreation= currentDate,
            };
            _context.Persons.Add(registro);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> UpdatePerson(Person person)
        {
            var result = await GetPerson(person.Identifier);
            result.Name = person.Name;
            result.LastName = person.LastName;
            result.FkIdTypeIdenti = person.FkIdTypeIdenti;
            result.NumberIdentification = person.NumberIdentification;
            result.Email = person.Email;
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> DeletePerson(int id)
        {
            var delete = await GetPerson(id);
            _context.Remove(delete);
            int row = await _context.SaveChangesAsync();
            return row > 0;
        }
    }
}

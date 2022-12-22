using Double.Core.Entities;
using Double.Core.Interfaces;
using Double.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Double.Infrastructure.Repository
{
    public class TypeIdentiRepository : ITypeIdentiRepository
    {
        private readonly DoublepContext _context;

        public TypeIdentiRepository(DoublepContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TypeIdenti>> GetTypeIdentis()
        {
            var Identis = await _context.TypeIdentis.ToListAsync();
            return Identis;
        }
        public async Task<TypeIdenti> GetTypeIdenti(int id)
        {
            var Identi = await _context.TypeIdentis.FirstOrDefaultAsync(x => x.IdTypeIdenti == id);
            return Identi;
        }
        public async Task InsertTypeIdenti(TypeIdenti typeIdenti)
        {
            _context.TypeIdentis.Add(typeIdenti);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> UpdateTypeIdenti(TypeIdenti typeIdenti)
        {
            var result = await GetTypeIdenti(typeIdenti.IdTypeIdenti);
            result.Description = typeIdenti.Description;
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> DeleteTypeIdenti(int id)
        {
            var delete = await GetTypeIdenti(id);
            _context.Remove(delete);
            int row = await _context.SaveChangesAsync();
            return row > 0;
        }
    }
}

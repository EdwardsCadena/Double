using Double.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Double.Core.Interfaces
{
    public interface ITypeIdentiRepository
    {
        Task<IEnumerable<TypeIdenti>> GetTypeIdentis();
        Task<TypeIdenti> GetTypeIdenti(int id);
        Task InsertTypeIdenti(TypeIdenti typeIdenti);
        Task<bool> UpdateTypeIdenti(TypeIdenti typeIdenti);
        Task<bool> DeleteTypeIdenti(int id);
    }
}

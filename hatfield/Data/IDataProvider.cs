using hatfield.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hatfield.Data
{
    public interface IDataProvider
    {
        Task<IEnumerable<PeopleModel>> GetPeople(string filePath);
    }
}

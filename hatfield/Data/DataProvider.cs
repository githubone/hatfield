using hatfield.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace hatfield.Data
{
    public class DataProvider : IDataProvider
    {
        public async Task<IEnumerable<Models.PeopleModel>> GetPeople(string filePath)
        {
           return await PeopleFileReader.GetPeopleData(filePath);
        }
    }
}
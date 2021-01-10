using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Database.Models;

namespace Database
{
    public interface IDatabase
    {
        public Task<IEnumerable<DocEntry>> GetDocsByContains(string condition);
    }
}

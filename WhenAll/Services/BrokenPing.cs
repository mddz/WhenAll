using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhenAll.Interfaces;

namespace WhenAll.Services
{
    public class BrokenPing : IPing
    {
        public async Task<bool> Ping()
        {
            throw new Exception("Ping Broken");
        }
    }
}

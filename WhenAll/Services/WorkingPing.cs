using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhenAll.Interfaces;

namespace WhenAll.Services
{
    public class WorkingPing : IPing
    {
        public async Task<bool> Ping()
        {
            await Task.Delay(3000);
            return true;
        }
    }
}

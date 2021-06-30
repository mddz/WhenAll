using System.Threading.Tasks;

namespace WhenAll.Interfaces
{
    public interface IPing
    {
        Task<bool> Ping();
    }
}

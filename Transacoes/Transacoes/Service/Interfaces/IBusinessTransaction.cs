using System.Threading.Tasks;

namespace Transacao.API.Service.Interfaces
{
    public interface IBusinessTransaction
    {
        Task<bool> DeleteTransaction(string id);
    }
}

using System.Threading.Tasks;
using Transacao.API.Repositories.Interfaces;
using Transacao.API.Service.Interfaces;

namespace Transacao.API.Service
{
    public class BusinessTransaction : IBusinessTransaction
    {
        private readonly ITransactionRepository _repository;
        public BusinessTransaction(ITransactionRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> DeleteTransaction(string id)
        {
            var data = await _repository.GetTransaction(id);
            if (data != null) {
                await _repository.DeleteTransaction(id);
                await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }
    }
}

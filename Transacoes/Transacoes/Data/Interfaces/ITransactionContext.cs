using Transacao.API.Entities;
using MongoDB.Driver;

namespace Transacao.API.Data.Interfaces
{
    public interface ITransactionContext
    {
        IMongoCollection<Transaction> Transactions { get; }
    }
}

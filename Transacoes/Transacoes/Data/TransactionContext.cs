using Transacao.API.Data.Interfaces;
using Transacao.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Transacao.API.Data
{
    public class TransactionContext : ITransactionContext
    {
        public TransactionContext(IConfiguration configuration)
        {            
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Transactions = database.GetCollection<Transaction>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            TransactionContextLoad.DataLoad(Transactions);
        }

        public IMongoCollection<Transaction> Transactions { get; }
    }
}

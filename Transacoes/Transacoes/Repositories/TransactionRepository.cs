using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Transacao.API.Data.Interfaces;
using Transacao.API.Entities;
using Transacao.API.Repositories.Interfaces;

namespace Transacao.API.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ITransactionContext _context;

        public TransactionRepository(ITransactionContext context) => 
            _context = context;

        public async Task<IEnumerable<Transaction>> GetTransactions() =>
            await _context.Transactions.Find(p => true).ToListAsync();

        public async Task<Transaction> GetTransaction(string id) => 
            await _context.Transactions.Find(p => p.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<Transaction>> GetTransactionByDate(DateTime date)
        {
            var filterBuilder = Builders<Transaction>.Filter;
            var filter = filterBuilder.Gte(x => x.Date, new BsonDateTime(date)) &
             filterBuilder.Lte(x => x.Date, new BsonDateTime(date.AddHours(23).AddMinutes(59).AddSeconds(59)));

            return await _context
                            .Transactions
                            .Find(filter)
                            .ToListAsync();
        }

        public async Task CreateTransaction(Transaction product) => 
            await _context.Transactions.InsertOneAsync(product);

        public async Task<bool> DeleteTransaction(string id)
        {
            FilterDefinition<Transaction> filter = Builders<Transaction>.Filter.Eq(p => p.Id, id);

            var result = await _context.Transactions.DeleteOneAsync(filter);

            return result.IsAcknowledged && result.DeletedCount > 0;
        }
    }
}

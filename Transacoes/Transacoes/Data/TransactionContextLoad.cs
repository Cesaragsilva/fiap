using Transacao.API.Entities;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Transacao.API.Data
{
    public class TransactionContextLoad
    {
        public static void DataLoad(IMongoCollection<Transaction> collection)
        {
            if(!collection.Find(f=> true).Any())
                collection.InsertMany(InsertTransactionForTests());
        }
        

        private static IEnumerable<Transaction> InsertTransactionForTests()
        {
            return new List<Transaction>()
            {
                new Transaction()
                {
                    Card = "3441",
                    Date = DateTime.UtcNow,
                    Description = "Transação efetuada para Joao LTDA",
                    Price = 980,
                    Category = "Alimentacao"
                },
                new Transaction()
                {
                    Card = "4957",
                    Date = DateTime.UtcNow.AddDays(-1),
                    Description = "Transação efetuada para Osvaldo Esportes ME",
                    Price = 130,
                    Category = "Lazer"
                },
                new Transaction()
                {
                    Card = "5575",
                    Date = DateTime.UtcNow,
                    Description = "Transação efetuada para Vanessa e Eloá Padaria ME",
                    Price = 220,
                    Category = "Alimentacao"
                },
                new Transaction()
                {
                    Card = "5526",
                    Date = DateTime.UtcNow.AddDays(-2),
                    Description = "Transação efetuada para Joao LTDA",
                    Price = 200,
                    Category = "Estudos"
                },
                new Transaction()
                {
                    Card = "3177",
                    Date = DateTime.UtcNow,
                    Description = "Transação efetuada para Pães e Doces ME",
                    Price = 10,
                    Category = "Alimentacao"
                },
                new Transaction()
                {
                    Card = "5575",
                    Date = DateTime.UtcNow.AddDays(-3),
                    Description = "Transação efetuada para Edson Ferragens MEA",
                    Price = 300,
                    Category = "Outros"
                }
            };
        }
    }
}

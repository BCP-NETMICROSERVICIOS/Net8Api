using EntregarWorker.Domain.Models;
using EntregarWorker.Domain.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntregarWorker.Infrastructure.Repositories
{
    public class EntregaRepository : IPedidoRepository
    {
        private readonly IMongoDatabase _mongoDatabase;

        public EntregaRepository(IMongoDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
        }
        public async Task<bool> Registrar(Entrega entity)
        {
            await getMongoCollection().InsertOneAsync(entity);
            return true;
        }

        private IMongoCollection<Entrega> getMongoCollection() => _mongoDatabase.GetCollection<Entrega>(nameof(Entrega));
    }
}

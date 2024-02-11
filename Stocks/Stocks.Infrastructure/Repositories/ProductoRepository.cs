using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Stocks.Domain.Models;
using Stocks.Domain.Repositories;

namespace Stocks.Infrastructure.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly IMongoDatabase _mongoDatabase;

        public ProductoRepository(IMongoDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
        }

        public async Task<bool> Adicionar(Producto entity)
        {
            await GetMongoCollection().InsertOneAsync(entity);

            return true;
        }

        public async Task<Producto> Consultar(int id)
        {
            return await GetMongoCollection().FindSync<Producto>(item => item.IdProducto == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Producto>> Consultar(string nombre)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(Producto entity)
        {
            throw new NotImplementedException();
        }

        public async  Task<bool> Modificar(Producto entity)
        {
            await GetMongoCollection().ReplaceOneAsync(item => item.IdProducto == entity.IdProducto, entity);

            return true;
        }

        private IMongoCollection<Producto> GetMongoCollection() => _mongoDatabase.GetCollection<Producto>(nameof(Producto));
    }
}

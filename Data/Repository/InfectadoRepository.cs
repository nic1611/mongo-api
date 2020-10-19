using System.Collections.Generic;
using MongoApi.Collections;
using MongoApi.Interfaces;
using MongoDB.Driver;

namespace MongoApi.Data.Repository
{
    public class InfectadoRepository : IInfectadoRepository
    {
        private readonly IMongoCollection<InfectadoCollection> _infectados;

        public InfectadoRepository(IInfectadoDataBaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _infectados = database.GetCollection<InfectadoCollection>(settings.InfectadoCollectionName);
        }

        public List<InfectadoCollection> Get() =>
            _infectados.Find(infectados => true).ToList();

        public InfectadoCollection Get(string id) =>
            _infectados.Find(infectados => infectados.id == id).FirstOrDefault();

        public InfectadoCollection Create(InfectadoCollection infectado)
        {
            _infectados.InsertOne(infectado);
            return infectado;
        }

        public void Update(string id, InfectadoCollection infectadolIn) =>
            _infectados.ReplaceOne(infectado => infectado.id == id, infectadolIn);

        public void Remove(InfectadoCollection infectadoIn) =>
            _infectados.DeleteOne(infectado => infectado.id == infectadoIn.id);

        public void Remove(string id) =>
            _infectados.DeleteOne(infectado => infectado.id == id);
    }
}
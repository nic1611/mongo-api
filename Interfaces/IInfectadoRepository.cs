using System.Collections.Generic;
using MongoApi.Collections;

namespace MongoApi.Interfaces
{
    public interface IInfectadoRepository
    {
         public List<InfectadoCollection> Get();

        public InfectadoCollection Get(string id);

        public InfectadoCollection Create(InfectadoCollection infectado);

        public void Update(string id, InfectadoCollection infectadolIn);

        public void Remove(InfectadoCollection infectadoIn);

        public void Remove(string id);
    }
}
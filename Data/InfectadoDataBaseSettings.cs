using System;

namespace MongoApi.Data
{
    public class InfectadoDataBaseSettings : IInfectadoDataBaseSettings
    {
        public string InfectadoCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IInfectadoDataBaseSettings
    {
        string InfectadoCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace BrilhaMuito.Factory.Repository
{
    public interface IRepositoryBase<TDocument>
    {
        void Save(TDocument document);

        void Update(Guid id, TDocument document);

        void Delete(Guid id);

        TDocument GetById(Guid id);

        IEnumerable<TDocument> All();

        void Set(Guid id, Dictionary<string, string> dictionary);

        void Set<TValue>(Guid id, string key, TValue value);
    }
}
using System.Collections.Generic;

namespace PsychologicalSupports.Models.Dependencies
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> List();
        T Get(long? id);
        void Create(T item);
        void Edit(T item);
        void Delete(long id);
    }

}
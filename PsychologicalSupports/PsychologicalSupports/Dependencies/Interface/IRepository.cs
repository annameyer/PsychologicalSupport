﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace PsychologicalSupports.Models.Dependencies
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> List();
        T Get(int? id);
        void Create(T item);
        void Edit(T item);
        void Delete(int id);
    }
    
}
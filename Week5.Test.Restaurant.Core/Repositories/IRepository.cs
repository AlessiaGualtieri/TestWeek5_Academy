using System;
using System.Collections.Generic;
using System.Text;

namespace Week5.Test.Restaurant.Core.Repositories
{
    public interface IRepository <T>
    {
        public IList<T> Fetch();
        public T GetByID(int id);
        public bool Add(T item);
        public bool Update(T item);
        public bool DeleteById(int id);
    }
}

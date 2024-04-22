using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietPlanner.DAO
{
    internal interface IGenericDAO<T>
    {
        void Save (T entity);
        //void Update (T entity, T newEntity);
        //T Delete (T entity);
        //void ShowAllItems();
    }
}

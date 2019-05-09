using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Model
{
    public interface IRepository<T>
    {
        T Add(T objClass);

        T GetEmployee(int id);

        IQueryable<T> GetAllEmployees();

        T Delete(int id);

        T Update(T objClass);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Model
{
    public class SQLEmployeeRepo : IEmployeeRepository
    {
        private readonly AppDBContext _appDBContext;
        public SQLEmployeeRepo(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        public Employee Add(Employee emp)
        {
            _appDBContext.Add(emp);
            _appDBContext.SaveChanges();
            return emp;
        }
            

        public IQueryable<Employee> GetAllEmployees()
        {
            return _appDBContext.Employees;
        }

        public Employee GetEmployee(int id)
        {
            return _appDBContext.Employees.Find(id);

        }

        public Employee Update(Employee objClass)
        {
           if(objClass!=null)
            {
                var emp = _appDBContext.Employees.Attach(objClass);
                emp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _appDBContext.SaveChanges();
            }
            return objClass;
        }

        public Employee Delete(int id)
        {
            var emp= _appDBContext.Employees.Find(id);
            if(emp!=null)
            {
                _appDBContext.Employees.Remove(emp);
                _appDBContext.SaveChanges();
            }
            return emp; 
        }
    }
}

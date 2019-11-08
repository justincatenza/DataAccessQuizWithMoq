using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DITestingQuiz
{
  
    

    public interface IEmployeeDataAccess
    {
        string GetEmployeeSalary(int id);
        string GetTop3Salary();
    }

    public class EmployeeDataAccess : IEmployeeDataAccess
    {
        IndeedEntities db = new IndeedEntities();
        public EmployeeDataAccess()
        {
        }

        public string GetEmployeeSalary(int id)
        {
            var user = db.Employees.SingleOrDefault(x => x.ID == id);
            return user.Salary.ToString();
        }

        public string GetTop3Salary()
        {
            var users = db.Employees.OrderByDescending(x => x.Salary).Take(3);
            foreach(var user in users)
            {
                return user.Name;
            }
            return "been returned";
            
        }
    }

    public class DataAccessFactory
    {
        public static IEmployeeDataAccess GetEmployeeDataAccessObj()
        {
            return new EmployeeDataAccess();
        }
    }

    public class EmployeeBusinessLogic
    {
        IEmployeeDataAccess _empDataAccess;

        public EmployeeBusinessLogic(IEmployeeDataAccess @object)
        {
            _empDataAccess = DataAccessFactory.GetEmployeeDataAccessObj();
        }

        public string GetEmployeeSalary(int id)
        {
            return _empDataAccess.GetEmployeeSalary(id);
        }

        public string GetTop3Salary()
        {
            return _empDataAccess.GetTop3Salary();
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            

            
        }
    }
}

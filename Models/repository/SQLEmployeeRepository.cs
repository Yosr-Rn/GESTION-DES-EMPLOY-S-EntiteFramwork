using Microsoft.EntityFrameworkCore;

namespace EntiteFramwork.Models.repository
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext context;
        public SQLEmployeeRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Employee Add(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
            return employee;
        }
        public Employee Delete(int Id)
        {
            Employee employee = context.Employees.Find(Id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
            return employee;
        }
        public IEnumerable<Employee> GetAllEmployee()
        {
            return context.Employees.ToList();
        }

        public Employee GetEmployee(int Id)
        {
            return context.Employees.Find(Id);
        }
        public Employee Update(Employee employeeChanges)
        {
            var employee = context.Employees.Attach(employeeChanges);
            employee.State = EntityState.Modified;
            context.SaveChanges();
            return employeeChanges;
        }

        /*
        public Employee Update(Employee newEmp)
        {
            var emp = context.Employees.Find(newEmp.id);
            if (emp != null)
            {
                emp.Name = newEmp.Name;
                emp.Salary = newEmp.Salary;
                emp.Departement = newEmp.Departement;
                context.SaveChanges();
            }
        }*/
    }
}

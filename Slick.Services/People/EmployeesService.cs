using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using Slick.Models.People;
using Slick.Repositories.Enities;

namespace Slick.Services.People
{
    public class EmployeesService : IEmployeesService
    {

        private readonly IEntityRepository<Employee> repo;
        public EmployeesService(IEntityRepository<Employee> repo)
        {
            this.repo = repo;
        }

        public Employee Create(Employee employee)
        {
            return repo.Add(employee);
        }

        public void Delete(Employee employee)
        {
            employee.IsDeleted = true;
            repo.Update(employee);
        }

        public IEnumerable<Employee> FindByFirstName(string firstname)
        {
            return this.repo.FindBy(e => e.FirstName == firstname).ToList();
        }

        public IEnumerable<Employee> FindByFirstName(string firstname, string sort)
        {
            if (string.IsNullOrEmpty(sort)) sort = "firstname";

            return this.repo.FindBy(e => e.FirstName == firstname).OrderBy(sort).ToList();
        }

        public IEnumerable<Employee> FindByLastName(string Lastname)
        {
            return this.repo.FindBy(e => e.LastName == Lastname).ToList();
        }

        public IEnumerable<Employee> FindByLastName(string Lastname, string sort)
        {
            if (string.IsNullOrEmpty(sort)) sort = "lastname";

            return repo.FindBy(e => e.LastName == Lastname).OrderBy(sort).ToList();
        }

        public IEnumerable<Employee> GetAll()
        {
            return repo.GetAll().Where(e => e.IsDeleted == false).ToList();
        }

        public IEnumerable<Employee> GetAll(string sort)
        {
            if (string.IsNullOrEmpty(sort)) sort = "firstname";

            return this.repo.GetAll().OrderBy(con => con.FirstName).ToList();
        }

        public Employee GetById(Guid Id)
        {
            return repo.GetById(Id);
        }

        public void Update(Employee employee)
        {
            repo.Update(employee);
        }
    }
}

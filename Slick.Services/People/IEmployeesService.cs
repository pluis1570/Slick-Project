using Slick.Models.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slick.Services.People
{
    public interface IEmployeesService
    {
        IEnumerable<Employee> GetAll();
        IEnumerable<Employee> GetAll(string sort);
        IEnumerable<Employee> FindByFirstName(string firstname);
        IEnumerable<Employee> FindByFirstName(string firstname, string sort);

        IEnumerable<Employee> FindByLastName(string Lastname);
        IEnumerable<Employee> FindByLastName(string Lastname, string sort);


        Employee GetById(Guid Id);
        Employee Create(Employee employee);
        void Update(Employee employee);
        void Delete(Employee employee);

    }
}

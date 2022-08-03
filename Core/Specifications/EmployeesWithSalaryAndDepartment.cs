using Core.Entities;
using System;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public class EmployeesWithSalaryAndDepartment : BaseSpecification<Employee>
    {
        public EmployeesWithSalaryAndDepartment(EmployeeFilteringSpecParams empParams)
                : base(x =>
                    (string.IsNullOrEmpty(empParams.Name) || x.LastName.ToLower().Contains(empParams.Name) || x.FirstName.ToLower().Contains(empParams.Name)
                        || x.SecondName.ToLower().Contains(empParams.Name))
                    && (string.IsNullOrEmpty(empParams.Department) || x.Department.Name.ToLower().Contains(empParams.Department))
                    && (string.IsNullOrEmpty(empParams.Salary) || x.Salary.Value.ToString().StartsWith(empParams.Salary))
                    && ( !(empParams.Birthdate != DateTime.MinValue) || x.Birthdate.Date == empParams.Birthdate.Date)
                    && (!( empParams.Hiredate != DateTime.MinValue) || x.Hiredate.Date == empParams.Hiredate.Date)
                )
        {
            AddInclude(x => x.Salary);
            AddInclude(x => x.Department);

            if (!string.IsNullOrEmpty(empParams.Sort))
            {
                Sort(empParams.Sort);
            }
        }

        public EmployeesWithSalaryAndDepartment(Expression<Func<Employee, bool>> criteria) : base(criteria)
        {
            AddInclude(x => x.Salary);
            AddInclude(x => x.Department);
        }

        private void Sort(string sort)
        {
            switch (sort)
            {
                case "idAsc":
                    AddOrderBy(x => x.Id);
                    break;

                case "idDesc":
                    AddOrderByDescending(x => x.Id);
                    break;

                case "nameAsc":
                    AddOrderBy(x => x.LastName);
                    break;

                case "nameDesc":
                    AddOrderByDescending(x => x.LastName);
                    break;

                case "birthdateAsc":
                    AddOrderBy(x => x.Birthdate);
                    break;

                case "birthdateDesc":
                    AddOrderByDescending(x => x.Birthdate);
                    break;

                case "hiredateAsc":
                    AddOrderBy(x => x.Hiredate);
                    break;

                case "hiredateDesc":
                    AddOrderByDescending(x => x.Hiredate);
                    break;

                case "salaryAsc":
                    AddOrderBy(x => x.Salary.Value);
                    break;

                case "salaryDesc":
                    AddOrderByDescending(x => x.Salary.Value);
                    break;

                case "deptAsc":
                    AddOrderBy(x => x.Department.Name);
                    break;

                case "deptDesc":
                    AddOrderByDescending(x => x.Department.Name);
                    break;
            }
        }
    }
}
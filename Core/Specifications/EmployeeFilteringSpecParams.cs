using System;

namespace Core.Specifications
{
    public class EmployeeFilteringSpecParams
    {
        private string _name;
        private string _department;

        public string Sort { get; set; }
        public string Name { get => _name; set => _name = value?.ToLower(); }
        public string Department { get => _department; set => _department = value?.ToLower(); }
        public string Salary { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime Hiredate { get; set; }
    }
}
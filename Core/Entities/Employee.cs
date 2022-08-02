using System;

namespace Core.Entities
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime Hiredate { get; set; }
        public Salary Salary { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
    }
}
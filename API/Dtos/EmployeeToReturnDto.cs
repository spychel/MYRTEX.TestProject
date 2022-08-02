namespace API.Dtos
{
    public class EmployeeToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Birthdate { get; set; }
        public string Hiredate { get; set; }
        public decimal Salary { get; set; }
        public string Department { get; set; }
    }
}
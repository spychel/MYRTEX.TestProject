using Core.Entities;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(EmployeeContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Departments.Any())
                {
                    var departmentsData = File.ReadAllText("../Infrastructure/Data/SeedData/departments.json");
                    var departments = JsonSerializer.Deserialize<List<Department>>(departmentsData);
                    foreach (var department in departments)
                    {
                        context.Departments.Add(department);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.Employees.Any())
                {
                    var employeesData = File.ReadAllText("../Infrastructure/Data/SeedData/employees.json");
                    JsonSerializerOptions options = new JsonSerializerOptions();
                    options.Converters.Add(new DateTimeConverterUsingDateTimeParse());
                    var employees = JsonSerializer.Deserialize<List<Employee>>(employeesData, options);

                    var salariesData = File.ReadAllText("../Infrastructure/Data/SeedData/salaries.json");
                    var salaries = JsonSerializer.Deserialize<List<Salary>>(salariesData);

                    foreach (var employee in employees)
                    {
                        employee.Salary = salaries.Where(s => s.Id == employee.Id).First();
                        context.Employees.Add(employee);
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch (System.Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message, "error has ocurred while seeding data");
            }
        }
    }
}
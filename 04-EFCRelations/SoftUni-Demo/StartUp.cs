using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var softUniContext = new SoftUniContext();

            Console.WriteLine(GetEmployeesFullInformation(softUniContext));

            Console.WriteLine(GetEmployeesWithSalaryOver50000(softUniContext));

            Console.WriteLine(GetEmployeesFromResearchAndDevelopment(softUniContext));

            Console.WriteLine(AddNewAddressToEmployee(softUniContext));

            Console.WriteLine(GetEmployeesInPeriod(softUniContext));

            Console.WriteLine(GetAddressesByTown(softUniContext));

            Console.WriteLine(RemoveTown(softUniContext));


        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(x => new
                { x.FirstName, x.LastName, x.MiddleName, x.JobTitle, x.Salary, x.EmployeeId })
                .OrderBy(x => x.EmployeeId)
                .ToList();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
            }

            var result = sb.ToString().TrimEnd();

            return result;

        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employeesAbove50000 = context.Employees
                .Where(x => x.Salary > 50000)
                .Select(x => new { x.FirstName, x.Salary })
                .OrderBy(x => x.FirstName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var employee in employeesAbove50000)
            {
                sb.AppendLine($"{employee.FirstName}-{employee.Salary:F2}");
            }

            var result = sb.ToString().TrimEnd();

            return result;
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var rndDepartment = context.Employees
                .Where(x => x.Department.Name == "Research and Development")
                .Select(x => new { x.Salary, x.FirstName, Department = x.Department.Name, x.LastName })
                .OrderBy(x => x.Salary)
                .ThenByDescending(x => x.FirstName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var employee in rndDepartment)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.Department} - ${employee.Salary:F2}");
            }

            var result = sb.ToString().TrimEnd();

            return result;
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {

            var nakov = context.Employees.FirstOrDefault(x => x.LastName == "Nakov");

            nakov.Address = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context.SaveChanges();


            var employeeAddress = context.Employees
                .Select(x => new { x.AddressId, AddressText = x.Address.AddressText })
                .OrderByDescending(x => x.AddressId)
                .Take(10)
                .ToList();

            var sb = new StringBuilder();

            foreach (var currentaddress in employeeAddress)
            {
                sb.AppendLine(currentaddress.AddressText);
            }

            var result = sb.ToString().TrimEnd();

            return result;


        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var projectEmployees = context.Employees
                .Include(x => x.EmployeesProjects)
                .ThenInclude(x => x.Project)
                .Where(x => x.EmployeesProjects.Any(p => p.Project.StartDate.Year >= 2001 &&
                p.Project.StartDate.Year <= 2003))
                .Select(x => new
                {
                    EmployeeFN = x.FirstName,
                    EmployeeLN = x.LastName,
                    ManagerFN = x.Manager.FirstName,
                    ManagerLN = x.Manager.LastName,
                    Projects = x.EmployeesProjects.Select(p => new
                    {
                        ProjectName = p.Project.Name,
                        ProjectStart = p.Project.StartDate,
                        ProjectEnd = p.Project.EndDate

                    })
                })
                .Take(10)
                .ToList();

            var sb = new StringBuilder();

            foreach (var emp in projectEmployees)
            {
                sb.AppendLine($"{emp.EmployeeFN} {emp.EmployeeLN} - Manager: {emp.ManagerFN} {emp.ManagerLN}");

                foreach (var empProj in emp.Projects)
                {

                    string projEndDate;

                    if (empProj.ProjectEnd.HasValue)
                    {
                        projEndDate = empProj.ProjectEnd.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        projEndDate = "not finished";
                    }

                    sb.AppendLine($"--{empProj.ProjectName} - {empProj.ProjectStart.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - {projEndDate} ");
                }

            }

            var result = sb.ToString().TrimEnd();

            return result;

        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var livingAddress = context.Addresses
                .Select(x => new
                {
                    AddText = x.AddressText,
                    TownName = x.Town.Name,
                    EmployeeCount = x.Employees.Count
                })
                .OrderByDescending(x => x.EmployeeCount)
                .ThenBy(x => x.TownName)
                .ThenBy(x => x.AddText)
                .Take(10)
                .ToList();

            var sb = new StringBuilder();

            foreach (var currentAddress in livingAddress)
            {
                sb.AppendLine($"{currentAddress.AddText}, {currentAddress.TownName} - {currentAddress.EmployeeCount} employees");
            }

            var result = sb.ToString().TrimEnd();

            return result;
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var town = context.Towns
                .Include(x => x.Addresses)
                .FirstOrDefault(x => x.Name == "Seattle");

            var allAddressIds = town.Addresses.Select(x => x.AddressId).ToList();

            var employees = context.Employees.Where(x => allAddressIds.Contains(x.AddressId.Value)).ToList();

            var deletedCounter = allAddressIds.Count();

            foreach (var employee in employees)
            {
                employee.AddressId = null;
            }

            foreach (var address in allAddressIds)
            {
                var addressToDelete = context.Addresses.FirstOrDefault(x => x.AddressId == address);
                context.Addresses.Remove(addressToDelete);
            }
            context.SaveChanges();

            context.Towns.Remove(town);

            context.SaveChanges();

            return $"{deletedCounter} addresses in Seattle were deleted";


                
        }

    }
}

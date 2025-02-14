using SoftUni.Data;
using SoftUni.Models;
using System.Text;

namespace SoftUni
{
	public class StartUp
	{
		static void Main(string[] args)
		{
			using (var context = new SoftUniContext())
			{
				string result = RemoveTown(context);
				Console.WriteLine(result);
			}
		}

		//3.
		public static string GetEmployeesFullInformation(SoftUniContext context)
		{
			var employees = context.Employees
				.Select(e => new
				{
					e.FirstName,
					e.LastName,
					e.MiddleName,
					e.JobTitle,
					e.Salary
				})
				.ToList();

			foreach (var employee in employees)
			{
				Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
			}
			return employees.ToString();
		}

		//4.
		public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
		{
			var employees = context.Employees
				.Select(e => new
				{
					e.FirstName,
					e.Salary
				})
				.Where(e => e.Salary > 50000)
				.OrderBy(e => e.FirstName)
				.ToList();

			var sb = new StringBuilder();
			foreach (var employee in employees)
			{
				sb.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
			}

			return sb.ToString();
		}

		//5.
		public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
		{
			var employees = context.Employees
				.Join(context.Departments,
				emp => emp.DepartmentId,
				dep => dep.DepartmentId,
				(emp, dep) => new
				{
					emp.FirstName,
					emp.LastName,
					emp.Salary,
					dep.Name
				})
				.Where(d => d.Name == "Research and Development")
				.OrderBy(d => d.Salary)
				.ThenByDescending(f => f.FirstName)
				.ToList();

			var sb = new StringBuilder();
			foreach (var employee in employees)
			{
				sb.AppendLine($"{employee.FirstName} {employee.LastName} from Research and Development - ${employee.Salary:f2}");
			}
			return sb.ToString();
		}

		//6.
		public static string AddNewAddressToEmployee(SoftUniContext context)
		{
			var newAddress = new Address
			{
				AddressText = "Vitosha 14",
				TownId = 4
			};
			context.Addresses.Add(newAddress);
			context.SaveChanges();

			var employee = context.Employees
				.FirstOrDefault(e => e.LastName == "Nakov");

			if (employee != null)
			{
				employee.Address = newAddress;
				context.SaveChanges();
			}

			var addressesText = context.Employees
				.OrderByDescending(e => e.LastName)
				.Take(10)
				.Select(e => e.Address.AddressText)
				.ToList();

			var sb = new StringBuilder();
			foreach (var address in addressesText)
			{
				sb.AppendLine(address);
			}

			return sb.ToString().TrimEnd();

		}

		//7.
		public static string GetEmployeesInPeriod(SoftUniContext context)
		{
			var employeesWithProjects = context.Employees
				.Where(emp => emp.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
				.Take(10)
				.Select(emp => new
				{
					emp.FirstName,
					emp.LastName,
					ManagerFirstName = emp.Manager,
					ManagerLastName = emp.Manager,
					Projects = emp.EmployeesProjects.Select(ep => new
					{
						ProjectName = ep.Project.Name,
						StartDate = ep.Project.StartDate.ToString("yyyy-MM-dd"),
						EndDate = ep.Project.EndDate.HasValue ? ep.Project.EndDate.Value.ToString("yyyy-MM-dd") : "not finished"
					}).ToList()
				})
				.ToList();


			var sb = new StringBuilder();
			foreach (var employee in employeesWithProjects)
			{
				sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");
				foreach (var project in employee.Projects)
				{
					sb.AppendLine($"--{project.ProjectName} - {project.StartDate} - {project.EndDate}");
				}
			}

			return sb.ToString();
		}

		//8.
		public static string GetAddressesByTown(SoftUniContext context)
		{
			var employees = context.Addresses
				.OrderByDescending(e => e.Employees.Count)
				.ThenBy(t => t.Town.Name)
				.ThenBy(a => a.AddressText)
				.Take(10)
				.Select(emp => new
				{
					emp.AddressText,
					emp.Town.Name,
					EmployeesCount = emp.Employees.Count
				})
				.ToList();

			var sb = new StringBuilder();
			foreach (var employee in employees)
			{
				sb.AppendLine($"{employee.AddressText}, {employee.Name} - {employee.EmployeesCount} employees");
			}

			return sb.ToString();
		}

		//9.
		public static string GetEmployee147(SoftUniContext context)
		{
			var employee = context.Employees
				.Where(emp => emp.EmployeeId == 147)
				.Select(emp => new
				{
					emp.FirstName,
					emp.LastName,
					emp.JobTitle,
					Projects = emp.Projects.Select(p => new
					{
						p.Name
					})
					.OrderBy(p => p.Name)
					.ToList()
				})
				.FirstOrDefault();

			var sb = new StringBuilder();
			sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

			foreach (var project in employee.Projects)
			{
				sb.AppendLine($"{project.Name}");
			}

			return sb.ToString().TrimEnd();
		}

		//10.
		public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
		{
			var departments = context.Departments
				.Where(d => d.Employees.Count() > 5)
				.OrderBy(e => e.Employees.Count)
				.ThenBy(d => d.Name)
				.Select(dep => new
				{
					dep.Name,
					dep.Manager.FirstName,
					dep.Manager.LastName,
					Employees = dep.Employees.Select(emp => new
					{
						emp.FirstName,
						emp.LastName,
						emp.JobTitle,
					})
					.OrderBy(f => f.FirstName)
					.ThenBy(l => l.LastName)
					.ToList()

				})
				.ToList();

			var sb = new StringBuilder();
			foreach (var department in departments)
			{
				sb.AppendLine($"{department.Name} - {department.FirstName} {department.LastName}");

				foreach (var employee in department.Employees)
				{
					sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
				}
			}

			return sb.ToString().TrimEnd();
		}

		//11.
		public static string GetLatestProjects(SoftUniContext context)
		{
			var projects = context.Projects
				.TakeLast(10)
				.OrderByDescending(pr => pr.StartDate)
				.Take(10)
				.OrderBy(pr => pr.Name)
				.Select(proj => new
				{
					proj.Name,
					proj.Description,
					proj.StartDate
				})
				.ToList();

			var sb = new StringBuilder();
			foreach (var project in projects)
			{
				sb.AppendLine($"{project.Name}\n{project.Description}\n{project.StartDate}");
			}

			return sb.ToString().TrimEnd();
		}

		//12.
		public static string IncreaseSalaries(SoftUniContext context)
		{
			var departmentsToIncrease = new[] { "Tool Design", "Engineering", "Marketing", "Information Services" };
			var employees = context.Employees
			   .Where(e => departmentsToIncrease.Contains(e.Department.Name))
			   .OrderBy(e => e.FirstName)
			   .ThenBy(e => e.LastName)
			   .ToList();

			foreach (var employee in employees)
			{
				employee.Salary *= 1.12m;
			}
			context.SaveChanges();


			var sb = new StringBuilder();
			foreach (var employee in employees)
			{
				sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:F2})");
			}

			return sb.ToString().TrimEnd();
		}

		//13.
		public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
		{
			var employees = context.Employees
				.Where(emp => emp.FirstName.StartsWith("Sa") || emp.FirstName.StartsWith("sa"))
				.OrderBy(emp => emp.FirstName)
				.ThenBy(emp => emp.LastName)
				.Select(emp => new
				{
					emp.FirstName,
					emp.LastName,
					emp.JobTitle,
					emp.Salary
				})
				.ToList();

			var sb = new StringBuilder();
			foreach (var employee in employees)
			{
				sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:f2})");
			}

			return sb.ToString().TrimEnd();
		}

		//14.
		public static string DeleteProjectById(SoftUniContext context)
		{
			var project = context.Projects
				.Where(prj => prj.ProjectId == 2)
				.FirstOrDefault();

			if (project != null)
			{
				context.Remove(project);
				context.SaveChanges();
			}

			var projects = context.Projects
				.Take(10)
				.Select(prj => prj.Name)
				.ToList();

			var sb = new StringBuilder();
			foreach (var projectName in projects)
			{
				sb.AppendLine($"{projectName}");
			}

			return sb.ToString().TrimEnd();
		}

		//15.
		public static string RemoveTown(SoftUniContext context)
		{
			int counter = 0;
			
			var addresses = context.Addresses
				.Where(add => add.Town.Name == "Seattle")
				.ToList();

			if (addresses.Any())
			{
				foreach (var address in addresses)
				{
					var employeesWithAddress = context.Employees
						.Where(e => e.AddressId == address.AddressId)
						.ToList();

					foreach (var employee in employeesWithAddress)
					{
						employee.AddressId = null;
					}
				}

				counter++;
				context.SaveChanges();
				context.Addresses.RemoveRange(addresses);
				context.SaveChanges();
			}


			var seattle = context.Towns
	   .FirstOrDefault(twn => twn.Name == "Seattle");

			if (seattle != null)
			{
				context.Towns.Remove(seattle);
				context.SaveChanges(); 
			}

			return $"{counter} addresses in Seattle were deleted";
		}
	}
}

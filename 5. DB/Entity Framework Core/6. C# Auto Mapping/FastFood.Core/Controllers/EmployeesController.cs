namespace FastFood.Core.Controllers
{
    using System;
	using System.Linq;
	using AutoMapper;
	using AutoMapper.QueryableExtensions;
	using Data;
	using FastFood.Core.ViewModels.Positions;
	using FastFood.Models;
	using Microsoft.AspNetCore.Mvc;
    using ViewModels.Employees;

    public class EmployeesController : Controller
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public EmployeesController(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterEmployeeInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            var employee = this.mapper.Map<Employee>(model);
            context.Employees.Add(employee);
            context.SaveChanges();

            return RedirectToAction("All", "Employees");
        }

        public IActionResult All()
        {
            var configuration = this.context.Employees
                .ProjectTo<PositionsAllViewModel>(mapper.ConfigurationProvider)
                .ToList();

            return this.View(configuration);
        }
    }
}

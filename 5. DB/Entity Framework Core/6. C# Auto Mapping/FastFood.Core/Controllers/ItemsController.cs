﻿namespace FastFood.Core.Controllers
{
    using System;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
	using FastFood.Core.ViewModels.Positions;
	using FastFood.Models;
	using Microsoft.AspNetCore.Mvc;
    using ViewModels.Items;

    public class ItemsController : Controller
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public ItemsController(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            var categories = this.context.Categories
                .ProjectTo<CreateItemViewModel>(mapper.ConfigurationProvider)
                .ToList();

            return this.View(categories);
        }

        [HttpPost]
        public IActionResult Create(CreateItemInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            var item = this.mapper.Map<Item>(model);
            this.context.Items.Add(item);
            this.context.SaveChanges();

			return this.RedirectToAction("All", "Items");
		}

        public IActionResult All()
        {
            try
            {
                var items = this.context.Items
                    .ProjectTo<PositionsAllViewModel>(mapper.ConfigurationProvider)
                    .ToList();

                return this.View(items);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return RedirectToAction("Error", "Home");
            }
        }
    }
}

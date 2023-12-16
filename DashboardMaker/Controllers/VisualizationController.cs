﻿using DashboardMaker.Data;
using DashboardMaker.Models;
using Microsoft.AspNetCore.Mvc;

namespace DashboardMaker.Controllers
{
	[Route("/Visualization")]
	public class VisualizationController : Controller
	{
		private readonly ApplicationDbContext _context;

		public VisualizationController(ApplicationDbContext context)
		{
			_context = context;
		}

		[HttpGet("Create")]
		public IActionResult CreateVisualization()
		{
			return View("VisualizationForm", new Visualization());
		}

		[HttpGet("Edit/{id}")]
		public IActionResult UpdateVisualization(int id)
		{
			var visualization = _context.Visualizations.Find(id);

			if (visualization == null) { return NotFound(); }

			return View("VisualizationForm", visualization);
		}
	}
}
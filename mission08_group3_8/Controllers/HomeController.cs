﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using mission08_group3_8.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace mission08_group3_8.Controllers
{
    public class HomeController : Controller
    {

        private TaskContext TaskContext { get; set; }

        public HomeController(TaskContext tasks)
        {
            TaskContext = tasks;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Quadrant()
        {
            var tasks = TaskContext.responses.Include(x => x.Category).ToList();
            return View(tasks);
        }

        [HttpGet]
        public IActionResult TaskForm()
        {
            ViewBag.Categories = TaskContext.categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult TaskForm(ApplicationResponse ar)
        {
            if (ModelState.IsValid)
            {
                TaskContext.Add(ar);
                TaskContext.SaveChanges();

                return RedirectToAction("Quadrant");
            }
            else
            {
                ViewBag.Categories = TaskContext.categories.ToList();

                return View(ar);
            }
        }

        [HttpGet]
        public IActionResult Delete(int taskid)
        {
            var task = TaskContext.responses.Single(x => x.TaskID == taskid);
            return View(task);
        }


        [HttpPost]
        public IActionResult Delete(ApplicationResponse ar)
        {
            TaskContext.responses.Remove(ar);
            TaskContext.SaveChanges();
            return RedirectToAction("Quadrant");
        }

        [HttpGet]
        public IActionResult Edit(int taskid)
        {
            ViewBag.Categories = TaskContext.categories.ToList();

            var application = TaskContext.responses.Single(x => x.TaskID == taskid);

            return View("TaskForm", application);
        }

        [HttpPost]
        public IActionResult Edit(ApplicationResponse ar)
        {
            if (ModelState.IsValid)
            {
                TaskContext.Update(ar);
                TaskContext.SaveChanges();

                return RedirectToAction("Quadrant");
            }
            else
            {
                ViewBag.Categories = TaskContext.categories.ToList();
                return View("Quadrant");
            }

        }
    }
}

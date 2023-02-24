using Microsoft.AspNetCore.Mvc;
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

        private TaskContext TaskResponse { get; set; }
        //constructor
        public HomeController(TaskContext taskEntry)
        {

            TaskResponse = taskEntry;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        //[HttpGet]
        public IActionResult Quadrant()
        {
            var entries = TaskResponse.Responses
                .Include(x => x.Category)
                //.OrderBy(x => x.Title)
                .ToList();
            return View(entries);
        }
        
        [HttpGet]
        public IActionResult TaskForm()
        {
            ViewBag.Categories = TaskResponse.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult TaskForm(ApplicationResponse ar)
        {
            if (ModelState.IsValid)
            {
                if(ar.Completed == false)
                {
                    TaskResponse.Add(ar);
                    TaskResponse.SaveChanges();
                    //return View("Confirmation", ar);
                    return RedirectToAction("Quadrant");
                }
                else
                {
                    ViewBag.Categories = TaskResponse.Categories.ToList();
                    return View();
                }
                
            }
            else
            {
                ViewBag.Categories = TaskResponse.Categories.ToList();
                return View();
            }
        }


        [HttpGet]
        public IActionResult Edit(int taskid)
        {
            ViewBag.Categories = TaskResponse.Categories.ToList();
            var entry = TaskResponse.Responses.Single(x => x.TaskID == taskid);
            return View("TaskForm", entry);
        }

        [HttpPost]
        public IActionResult Edit(ApplicationResponse editedentry)
        {
            if (ModelState.IsValid)
            {
                TaskResponse.Update(editedentry);
                TaskResponse.SaveChanges();
                return RedirectToAction("Quadrant");

            }
            else
            {
                ViewBag.Categories = TaskResponse.Categories.ToList();
                return View("Quadrant");
            }
        }

        [HttpGet]
        public IActionResult Delete(int taskid)
        {

            var entry = TaskResponse.Responses.Single(x => x.TaskID == taskid);
            return View(entry);

        }
        [HttpPost]
        public IActionResult Delete(ApplicationResponse removetask)
        {
            TaskResponse.Responses.Remove(removetask);
            TaskResponse.SaveChanges();
            return RedirectToAction("Quadrant");
        }

    }
}


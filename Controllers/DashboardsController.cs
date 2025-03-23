using Microsoft.AspNetCore.Mvc;
using RETRA_HOTEL_SYSTEM_2.Data;
using RETRA_HOTEL_SYSTEM_2.ViewModels;
using RETRA_HOTEL_SYSTEM_2.Models;
using System;
using System.Linq;

namespace RETRA_HOTEL_SYSTEM_2.Controllers
{
    public class DashboardsController : Controller
    {
        private readonly AppDbContext _context;

        public DashboardsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Admin()
        {
            return View();
        }

        // GET: CreateUser (renders the form)
        public IActionResult CreateUser()
        {
            return View();
        }

        // POST: CreateUser (handles form submission)
        [HttpPost]
        public IActionResult CreateUser(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Map EmployeeViewModel to Models.Employee
                    var employee = new Models.Employee
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        PhoneNumber = model.PhoneNumber,
                        HireDate = model.HireDate,
                        Salary = model.Salary,
                        Department = model.Department,
                        Role = model.Role,
                        CompanyId = model.CompanyId
                    };

                    _context.Employees.Add(employee);
                    _context.SaveChanges();

                    // Handle AJAX requests
                    if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                    {
                        return Json(new { success = true, message = "Employee Successfully Added!" });
                    }
                    else
                    {
                        TempData["SuccessMessage"] = "Employee Successfully Added!";
                        return RedirectToAction("Admin");
                    }
                }
                catch (Exception ex)
                {
                    // Log the error
                    Console.WriteLine($"Error creating user: {ex.Message}");

                    // Handle AJAX requests
                    if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                    {
                        return Json(new { success = false, message = ex.Message });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Failed to create user account. Please try again.");
                        return View(model);
                    }
                }
            }

            // Handle AJAX requests
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return Json(new { success = false, message = "Invalid data submitted." });
            }
            else
            {
                return View(model);
            }
        }
        // GET: CreateRoom (renders the form)
        public IActionResult CreateRoom()
        {
            return View();
        }

        public IActionResult ViewEmployees()
        {
            var employees = _context.Employees.ToList();
            return View(employees);
        }

        public IActionResult ViewUserAccounts()
        {
            var userAccounts = _context.UserAccounts.ToList();
            return View(userAccounts);
        }

        [HttpPost]
        public IActionResult CreateRoom(RoomViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Map RoomViewModel to Models.Room
                    var room = new Models.Room
                    {
                        RoomNumber = model.RoomNumber,
                        Floor = model.Floor,
                        RoomType = model.RoomType,
                        BedType = model.BedType,
                        PricePerNight = model.PricePerNight,
                        Status = model.Status,
                        MaxOccupancy = model.MaxOccupancy,
                        Amenities = model.Amenities,
                        ImageUrl = model.ImageUrl
                    };

                    _context.Rooms.Add(room);
                    _context.SaveChanges();

                    return Json(new { success = true, message = "Room Successfully Added!" });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = ex.Message });
                }
            }

            return Json(new { success = false, message = "Invalid data submitted." });
        }

        public IActionResult ViewRooms()
        {
            var rooms = _context.Rooms.ToList();
            return View(rooms);
        }

    }
}
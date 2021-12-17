﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rocket_Elevators_REST_API.Models;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rocket_Elevators_REST_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InterventionController : Controller
    {
        // GET: /<controller>/
        private readonly armanadibiContext _context;
        public InterventionController(armanadibiContext context)
        {
            _context = context;
        }

        [Produces("application/json")]
        [HttpGet]
        public async Task<IActionResult> GetPending()
        {
            try
            {
                var pending_intervention = _context.Interventions.Where(b => b.Status == "Pending");

                return Ok(pending_intervention);
            }
            catch
            {
                return BadRequest();
            }
        }
        [Produces("application/json")]
        [HttpPut]
        public async Task<IActionResult> PostStatus(Intervention input)
        {
            try
            {   if(input.Status == "InProgress")
                {
                    var change_status = _context.Interventions.Where(b => b.Id == input.Id).FirstOrDefault();
                    var current_status = change_status.Status;
                    change_status.Status = input.Status;
                    change_status.InterventionStart = DateTime.Now;
                    _context.SaveChanges();
                    return Ok("Status has been successfully changed");
                }else if(input.Status == "Completed")
                {
                    var change_status = _context.Interventions.Where(b => b.Id == input.Id).FirstOrDefault();
                    var current_status = change_status.Status;
                    change_status.Status = input.Status;
                    change_status.InterventionEnd = DateTime.Now;
                    _context.SaveChanges();
                    return Ok("Status has been successfully changed");


                }
                else
                {
                    return Ok("Something went wrong. Please verify the request body");
                }
               
            }
            catch
            {
                return BadRequest();
            }

            
        }

        [Produces("application/json")]
        [HttpPost("insert")]
        public async Task<IActionResult> InsertIntervention(Intervention input)
        {
            try
            {

                Intervention new_intervention = new Intervention();
                new_intervention.UserId = input.UserId;
                new_intervention.BuildingId = input.BuildingId;
                new_intervention.CustomerId = input.CustomerId;
                new_intervention.BatteryId = input.BatteryId;
                new_intervention.ColumnId = input.ColumnId;
                new_intervention.ElevatorId = input.ElevatorId;
                new_intervention.Report = input.Report;
                new_intervention.EmployeeId = input.EmployeeId;
                new_intervention.Status = "Pending";
                new_intervention.Result = "Pending";
                new_intervention.CreatedAt =  DateTime.Now;
                new_intervention.UpdatedAt = DateTime.Now;
                _context.Interventions.Add(new_intervention);
                _context.SaveChanges();


                return Ok("Your Suba has been successfully change");
                

            }
            catch
            {
                return BadRequest();
            }


        }





        [Produces("application/json")]
        [HttpGet("building/{id}")]
        public async Task<IActionResult> getBuilding(long id)
        {
            var building = _context.Buildings.Where(b => b.CustomerId == id).ToList();
            return Ok(building);
        }
        [Produces("application/json")]
        [HttpGet("battery/{id}")]
        public async Task<IActionResult> getBattery(long id)
        {
            var battery = _context.Batteries.Where(b => b.BuildingId == id).ToList();
            return Ok(battery);
        }

        [Produces("application/json")]
        [HttpGet("column/{id}")]
        public async Task<IActionResult> getColumn(long id)
        {
            var columns = _context.Columns.Where(b => b.BatteryId == id).ToList();
            return Ok(columns);
        }

        [Produces("application/json")]
        [HttpGet("elevator/{id}")]
        public async Task<IActionResult> getElevator(long id)
        {
            var elevator = _context.Elevators.Where(b => b.ColumnId == id).ToList();
            return Ok(elevator);
        }

        [Produces("application/json")]
        [HttpGet("employee")]
        public async Task<IActionResult> getEmployee(long id)
        {
            var employee = _context.Employees.ToList();
            return Ok(employee);
        }

    }
}

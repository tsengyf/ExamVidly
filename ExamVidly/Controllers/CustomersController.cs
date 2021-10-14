﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExamVidly.Models;
using ExamVidly.ViewModels;
using Microsoft.Ajax.Utilities;
using Microsoft.Owin.Security;

namespace ExamVidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var customers = _context.Customers.ToList();

            return View(customers);
        }

        // GET: Customers/Detail
        public ActionResult Details(int Id)
        {

            var customer = _context.Customers.FirstOrDefault(m => m.Id == Id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

    }
}
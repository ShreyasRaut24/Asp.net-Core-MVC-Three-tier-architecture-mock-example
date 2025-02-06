﻿using System.Runtime.CompilerServices;
using Demo.BusinessLayer.IRepository;
using Demo.BusinessLayer.Model;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PresentationLayer.Controllers
{
    public class CompanyController : Controller
    {
        ICompanyRepository _companyRepository;
        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public IActionResult Company()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Company company)
        {
            _companyRepository.Create(company);
            return RedirectToAction("Company");
        }
    }
}

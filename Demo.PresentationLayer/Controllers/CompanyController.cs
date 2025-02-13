using System.Runtime.CompilerServices;
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
            var comapnies = _companyRepository.List();

            return View(comapnies);
        }

        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Company company)
        {
            _companyRepository.Create(company);
            return RedirectToAction("Company");
        }

        public IActionResult Delete(int id)
        {
            _companyRepository.Delete(id);
            return RedirectToAction("Company");
        }
        public IActionResult CompanyView(int id)
        {
            var company = _companyRepository.GetById(id);
            return View(company);
        }

        public IActionResult Update(int id)
        {
            var company = _companyRepository.GetById(id);
            return View(company);
        }
        [HttpPost]
        public IActionResult Update(Company company)
        {
            _companyRepository.Update(company);
            return RedirectToAction("Company");
        }
    }
}

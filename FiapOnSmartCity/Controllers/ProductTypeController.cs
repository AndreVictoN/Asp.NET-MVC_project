using FiapOnSmartCity.Models;
using FiapOnSmartCity.DAL;
using Microsoft.AspNetCore.Mvc;
using FiapOnSmartCity.Controllers.Filters;

namespace FiapOnSmartCity.Controllers;

[LogFilter]
public class ProductTypeController : Controller
{
    private readonly ProductTypeDAL _productTypeDAL;

    public ProductTypeController()
    {
        //_productTypeDAL = new ProductTypeDAL(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build());
        _productTypeDAL = new ProductTypeDAL();
    }

    [HttpGet]
    public ActionResult Index()
    {
        IList<ProductType> typesList = _productTypeDAL.GetAll();

        return View(typesList);
    }

    [HttpGet]
    public ActionResult Create()
    {
        return View(new ProductType());
    }

    [HttpPost]
    public ActionResult Create(ProductType productType)
    {
        if(ModelState.IsValid)
        {
            _productTypeDAL.Create(productType);

            TempData["SuccessMessage"] = "Product Type created successfully!";
            return RedirectToAction("Index", "ProductType");
        }
        else
        {
            return View(productType);
        }
    }

    [HttpGet]
    public ActionResult Update(int id)
    {
        ProductType productType = _productTypeDAL.GetById(id);
        return View(productType);
    }

    [HttpPost]
    public ActionResult Update(ProductType productType)
    {
        if(ModelState.IsValid)
        {
            _productTypeDAL.Update(productType);

            TempData["SuccessMessage"] = "Product Type updated successfully!";
            return RedirectToAction("Index", "ProductType");
        }
        else
        {
            return View(productType);
        }
    }

    [HttpGet]
    public ActionResult Details(int id)
    {
        ProductType productType = _productTypeDAL.GetById(id);
        return View(productType);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id)
    {
        _productTypeDAL.Delete(id);

        TempData["SuccessMessage"] = "Product Type deleted successfully!";
        return RedirectToAction("Index", "ProductType");
    }
}

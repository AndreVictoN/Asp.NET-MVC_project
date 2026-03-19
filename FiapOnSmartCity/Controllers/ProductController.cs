using FiapOnSmartCity.DAL;
using FiapOnSmartCity.Models;
using Microsoft.AspNetCore.Mvc;

namespace FiapOnSmartCity.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new ProductTypeDAL().GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        try
        {
            ProductTypeDAL dal = new ProductTypeDAL();
            ProductType productType = dal.GetById(id);

            return Ok(productType);
        } catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public IActionResult Post([FromBody] ProductType productType)
    {
        try
        {
            ProductTypeDAL dal = new ProductTypeDAL();
            dal.Create(productType);

            return CreatedAtAction(nameof(Get), new { id = productType.id }, productType);
        } catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            ProductTypeDAL dal = new ProductTypeDAL();
            dal.Delete(id);

            return Ok();
        } catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpPut]
    public IActionResult Put([FromBody] ProductType productType)
    {
        try
        {
            ProductTypeDAL dal = new ProductTypeDAL();
            dal.Update(productType);
            
            return Ok();
        } catch (Exception)
        {
            return BadRequest();
        }
    }
}
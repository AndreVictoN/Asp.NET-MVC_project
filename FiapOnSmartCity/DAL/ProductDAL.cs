using Oracle.ManagedDataAccess.Client;
using FiapOnSmartCity.Models;
using FiapOnSmartCity.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace FiapOnSmartCity.DAL;

public class ProductDAL
{
    private readonly string? _connectionString;

    public ProductDAL()
    {
        _connectionString = Environment.GetEnvironmentVariable("LocalConnection");
    }

    public Product GetById(int id)
    {
        ContextClass context = new ContextClass();
        Product? product = context.Product.Include(product => product.productType).FirstOrDefault(p => p.id == id);
        
        return product;   
    }

    public IList<Product> GetByType(int productTypeId)
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        return new ContextClass().ProductType.Include(p => p.products).FirstOrDefault(p => p.id == productTypeId).products;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }
}